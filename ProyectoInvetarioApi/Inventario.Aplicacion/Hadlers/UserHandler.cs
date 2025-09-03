using Inventario.Aplicacion.Comandos;
using Inventario.Dominio.Repositorio;
using MediatR;



namespace Inventario.Aplicacion.Hadlers
{
    public class UserHandler: IRequestHandler<UserCommand, bool>
    {
        private readonly IUserRepository _iuserRepository;

        public UserHandler(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        public async Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
           => await _iuserRepository.Save(request.Request);

    }
}
