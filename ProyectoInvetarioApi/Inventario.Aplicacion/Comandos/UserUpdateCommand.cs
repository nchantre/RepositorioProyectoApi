using Inventario.Dominio.Entidades;
using MediatR;

namespace Inventario.Aplicacion.Comandos
{

    public record UserUpdateCommand(User Request) : IRequest<bool>;
    
}
