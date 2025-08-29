using Inventario.Dominio.Entidades;

namespace Inventario.Dominio.Repositorio
{
    public interface IUserRepository
    {

        public  Task<bool> Save(User request);
        public  Task<IEnumerable<User>> GetAll();

        public Task<bool> Update(User request);


    }
}
