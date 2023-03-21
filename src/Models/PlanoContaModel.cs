using myfinance_web_dotnet.Domain.Entities;

namespace myfinance_web_dotnet.Models
{
    public class PlanoContaModel
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }

        public PlanoContaModel() { }
        
    }
}