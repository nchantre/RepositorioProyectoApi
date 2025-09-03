using Inventario.Aplicacion.Comandos;
using Inventario.Dominio.Repositorio;
using MediatR;

namespace Inventario.Aplicacion.Hadlers
{
    public class UserUpdateHandler : IRequestHandler<UserUpdateCommand, bool>
    {

        private readonly IUserRepository _iuserRepository;

        public UserUpdateHandler(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        public async Task<bool> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _iuserRepository.GetById(request.Request.EmployeeNumber);
            request.Request.EmployeeNumber = user.EmployeeNumber;

            return await _iuserRepository.Update(request.Request);

        }
           
    }
}
