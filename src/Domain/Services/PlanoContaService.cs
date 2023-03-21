using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain.Entities;
using myfinance_web_dotnet.Domain.Services.Interfaces;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Domain.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _dbContext;

        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PlanoContaModel> GetAll()
        {
            var dbSet = _dbContext.PlanoConta;
            List<PlanoContaModel> PlanoContaModelList = new List<PlanoContaModel>();

            foreach (var item in dbSet)
            {
                PlanoContaModelList.Add(new PlanoContaModel
                {
                    Id = item.Id,
                    Description = item.Descricao,
                    Type = item.Tipo
                });
            }
            return PlanoContaModelList;
        }

        public PlanoContaModel Get(int id)
        {
            var dbSet = _dbContext.PlanoConta.Where(x => x.Id.Equals(id)).First();
            return new PlanoContaModel
            {
                Id = dbSet.Id,
                Description = dbSet.Descricao,
                Type = dbSet.Tipo
            };
        }

        public void Save(PlanoContaModel PlanoContaModel)
        {
            var dbSet = _dbContext.PlanoConta;
            var entity = new PlanoConta()
            {
                Id = PlanoContaModel.Id,
                Descricao = PlanoContaModel.Description,
                Tipo = PlanoContaModel.Type
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
            var PlanoConta = _dbContext.PlanoConta.Where(x => x.Id.Equals(id)).First();
            _dbContext.Attach(PlanoConta);
            _dbContext.Remove(PlanoConta);
            _dbContext.SaveChanges();
        }
    }
}