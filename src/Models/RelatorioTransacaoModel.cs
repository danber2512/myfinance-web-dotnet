using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_dotnet.Models
{
    public class TransacoesRelatorioModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TransacaoModel> Transacoes { get; set; }
        public int CountIncomeTransacoes { get; set; }
        public int CountExpensesTransacoes { get; set; }

        public TransacoesRelatorioModel()
        {
            Transacoes = new List<TransacaoModel>();
        }
    }
}