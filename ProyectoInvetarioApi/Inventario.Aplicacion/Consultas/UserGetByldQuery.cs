using Inventario.Dominio.Entidades;
using MediatR;

namespace Inventario.Aplicacion.Consultas
{
    public class UserGetByldQuery: IRequest<User>
    {
        public string? EmployeeNumber { get; set; }

    }
}
