using Inventario.Aplicacion.Consultas;
using Inventario.Dominio.Entidades;
using Inventario.Dominio.Repositorio;
using MediatR;

namespace Inventario.Aplicacion.Hadlers
{
    public class UserGetAllHandler: IRequestHandler<UserGetAllQuery, List<User>>
    {
        private readonly IUserRepository _iuserRepository;

        public UserGetAllHandler(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        public async Task<List<User>> Handle(UserGetAllQuery query, CancellationToken cancellationToken)
        {
            var rt = await _iuserRepository.GetAll();
            return rt.ToList();

        }
         
    }
}
