namespace Inventario.Dominio.Entidades
{
    public class User
    {
        public string EmployeeNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string AP { get; set; } = null!;
        public string AM { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? AccessKey { get; set; }
        public string Position { get; set; } = null!;
        public string Department { get; set; } = null!;

     
    }
}
