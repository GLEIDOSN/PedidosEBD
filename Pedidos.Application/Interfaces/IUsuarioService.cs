using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Application.Interfaces
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<Usuario>> GetUsuarios();
        public Task<Usuario> GetByID(int id);
        public Task<Usuario> GetByNome(string nome);
        public Task<Usuario> Login(string usuario, string senha);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        bool Remove(int id);
    }
}
