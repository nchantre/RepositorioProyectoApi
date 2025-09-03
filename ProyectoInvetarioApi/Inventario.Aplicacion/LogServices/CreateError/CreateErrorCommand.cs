namespace Inventario.Aplicacion.LogServices.CreateError
{
    public class CreateErrorCommand
    {
        public int SeverityID { get; set; }
        public string? Descripcion { get; set; }
        public string? UserID  { get; set; }
        public string? TransactionID { get; set; }
        public string? Code { get; set; }
        public string? Component { get; set; }
        public string? Machine { get; set; }
        public DateTime Date { get; set; }

    }
}
