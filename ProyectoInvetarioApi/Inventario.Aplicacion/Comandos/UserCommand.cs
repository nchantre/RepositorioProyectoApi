using Inventario.Dominio.Entidades;
using MediatR;

namespace Inventario.Aplicacion.Comandos
{
    public record UserCommand(User Request): IRequest<bool>;
   
}
