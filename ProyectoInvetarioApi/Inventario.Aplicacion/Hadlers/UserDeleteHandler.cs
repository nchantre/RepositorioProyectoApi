using Inventario.Aplicacion.Comandos;
using Inventario.Dominio.Repositorio;
using MediatR;

namespace Inventario.Aplicacion.Hadlers
{
    public class UserDeleteHandler : IRequestHandler<UserDeleteCommand, bool>
    {
        private readonly IUserRepository _iuserRepository;

        public UserDeleteHandler(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        public async Task<bool> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var rt = await _iuserRepository.Delete(request.EmployeeNumber);
            return rt;

        }



    }
}
