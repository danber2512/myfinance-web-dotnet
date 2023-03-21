namespace myfinance_web_dotnet.Domain.Entities
{
    public class LogExclusao
    {
        public int? Id { get; set; }
        public DateTime Data { get; set; }
        public string? Operacao { get; set; }
        public string? Historico { get; set; }
        public string? Tabela { get; set; }
        public int? IdRegistro { get; set; }
    }
}