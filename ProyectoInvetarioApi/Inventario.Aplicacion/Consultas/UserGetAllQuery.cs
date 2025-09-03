using Inventario.Dominio.Entidades;
using MediatR;

namespace Inventario.Aplicacion.Consultas
{
    public class UserGetAllQuery : IRequest<List<User>> { }
}
