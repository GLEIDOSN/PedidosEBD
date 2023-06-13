using Pedidos.Application.Interfaces;
using Pedidos.Domain.Interfaces.Repositories;
using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
    
        public void Add(Usuario usuario)
        {
            usuarioRepository.Add(usuario);
        }

        public async Task<Usuario> GetByID(int id)
        {
            return await usuarioRepository.GetByID(id);
        }

        public async Task<Usuario> GetByNome(string nome)
        {
            return await usuarioRepository.GetByNome(nome);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await usuarioRepository.GetAll();
        }

        public async Task<Usuario> Login(string usuario, string senha)
        {
            return await usuarioRepository.Login(usuario, senha);
        }

        public bool Remove(int id)
        {
            return usuarioRepository.Remove(id);
        }

        public void Update(Usuario usuario)
        {
            usuarioRepository.Update(usuario);
        }
    }
}
