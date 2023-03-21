using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public DateTime DataTransacao { get; set; }
        public Decimal Value { get; set; }
        public String? History { get; set; }
        public int PlanoContaId { get; set; }
        public String PlanoContaType {get; set;}
        public PlanoContaModel PlanoContaTransacao { get; set; }
        public IEnumerable<SelectListItem>? PlanoContas { get; set; }
    }
}