using MediatR;

namespace Inventario.Aplicacion.Comandos
{
    public class UserDeleteCommand : IRequest<bool>
    {
        public string? EmployeeNumber { get; set; }
    }
}
