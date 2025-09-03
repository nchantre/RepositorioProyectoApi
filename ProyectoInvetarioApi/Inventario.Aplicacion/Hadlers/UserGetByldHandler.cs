using Inventario.Aplicacion.Consultas;
using Inventario.Dominio.Entidades;
using Inventario.Dominio.Repositorio;
using MediatR;

namespace Inventario.Aplicacion.Hadlers
{
    public class UserGetByldHandler : IRequestHandler<UserGetByldQuery, User>
    {

        private readonly IUserRepository _iuserRepository;

        public UserGetByldHandler(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        public async Task<User> Handle(UserGetByldQuery query, CancellationToken cancellationToken)
        {
            var rt = await _iuserRepository.GetById(query.EmployeeNumber);
            return rt;

        }


    }
}
