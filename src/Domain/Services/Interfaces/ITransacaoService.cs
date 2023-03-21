using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Domain.Services.Interfaces
{
    public interface ITransacaoService
    {
        List<TransacaoModel> GetAll();
        TransacaoModel Get(int id);
        void Save(TransacaoModel TransacaoModel);
        void Delete(int id);
        TransacoesRelatorioModel GetAllByPeriod(DateTime dataInicio, DateTime dataFim);
    }
}