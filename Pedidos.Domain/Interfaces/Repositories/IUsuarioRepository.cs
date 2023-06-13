using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<IEnumerable<Usuario>> GetAll();
        public Task<Usuario> GetByID(int id);
        public Task<Usuario> GetByNome(string nome);
        public Task<Usuario> Login(string usuario, string senha);
        public void Add(Usuario usuario);
        public void Update(Usuario usuario);
        public bool Remove(int id);
    }
}
