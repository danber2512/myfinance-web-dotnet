using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain.Entities;
using myfinance_web_dotnet.Domain.Services.Interfaces;
using myfinance_web_dotnet.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Domain.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _dbContext;

        public TransacaoService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TransacaoModel> GetAll()
        {
            var dbSet = _dbContext.Transacao.Include(x => x.PlanoConta);
            List<TransacaoModel> TransacaoList = new List<TransacaoModel>();

            foreach (var item in dbSet)
            {
                TransacaoList.Add(new TransacaoModel
                {
                    Id = item.Id,
                    DataTransacao = item.Data,
                    History = item.Historico,
                    Value = item.Valor,
                    PlanoContaTransacao =
                        new PlanoContaModel
                        {
                            Id = item.PlanoConta.Id,
                            Description = item.PlanoConta.Descricao,
                            Type = item.PlanoConta.Tipo
                        },
                    PlanoContaId = (int)item.PlanoConta.Id,
                });
            }
            return TransacaoList;
        }

        public TransacaoModel Get(int id)
        {
            var dbSet = _dbContext.Transacao
                .Where(x => x.Id.Equals(id))
                .First();

            return new TransacaoModel
            {
                Id = dbSet.Id,
                DataTransacao = dbSet.Data,
                History = dbSet.Historico,
                Value = dbSet.Valor,
                PlanoContaId = dbSet.PlanoContaId
            };
        }

        public void Save(TransacaoModel Transacao)
        {
            var dbSet = _dbContext.Transacao;

            var entity = new Transacao()
            {
                Id = Transacao.Id,
                Data = Transacao.DataTransacao,
                Historico = Transacao.History,
                Valor = Transacao.Value,
                PlanoContaId = Transacao.PlanoContaId
            };

            if (entity.Id == null)
            {
                dbSet.Add(entity);
            }
            else
            {
                dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var PlanoConta = _dbContext.Transacao
                .Where(x => x.Id.Equals(id))
                .First();

            DateTime myDateTime = DateTime.Now;
            var dbLog = _dbContext.LogExclusao;
            var entity = new LogExclusao (){
                Data = myDateTime,
                Operacao = "E",
                Tabela = "transacao",
                Historico = PlanoConta.Historico,
                IdRegistro = id
            };
            dbLog.Add(entity);
            _dbContext.Attach(PlanoConta);
            _dbContext.Remove(PlanoConta);
            _dbContext.SaveChanges();
        }

        public TransacoesRelatorioModel GetAllByPeriod(DateTime startDate, DateTime endDate)
        {

            var dbSet = _dbContext.Transacao
                .Include(x => x.PlanoConta)
                .Where(x => x.Data >= startDate.Date && x.Data <= endDate.Date);

            List<TransacaoModel> TransacaoList = new List<TransacaoModel>();

            foreach (var item in dbSet)
            {
                TransacaoList.Add(new TransacaoModel
                {
                    Id = item.Id,
                    DataTransacao = item.Data,
                    History = item.Historico,
                    Value = item.Valor,
                    PlanoContaTransacao =
                        new PlanoContaModel
                        {
                            Id = item.PlanoConta.Id,
                            Description = item.PlanoConta.Descricao,
                            Type = item.PlanoConta.Tipo
                        },
                    PlanoContaId = (int)item.PlanoConta.Id,
                    PlanoContaType = item.PlanoConta.Tipo
                });
            }

            TransacoesRelatorioModel relatorios = new TransacoesRelatorioModel();
            relatorios.StartDate = startDate;
            relatorios.EndDate = endDate;
            relatorios.Transacoes = TransacaoList;
            relatorios.CountIncomeTransacoes = TransacaoList
                .Where(x => x.PlanoContaType.Equals("R"))
                .ToList()
                .Count();
            relatorios.CountExpensesTransacoes = TransacaoList
                .Where(x => x.PlanoContaType.Equals("D"))
                .ToList()
                .Count();
            return relatorios;
        }
    }
}