using myfinance_web_dotnet.Domain.Entities;

namespace myfinance_web_dotnet.Models
{
    public class LogExclusaoModel
    {
        public int? Id { get; set; }
        public DateTime DateNow { get; set; }
        public string? Operation { get; set; }
        public string? History { get; set; }
        public string? Table { get; set; }
        public int? IdRegister { get; set; }

        public LogExclusaoModel() { }
        
    }
}