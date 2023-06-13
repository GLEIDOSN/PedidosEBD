using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Interfaces.Repositories;
using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosEBD.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PedidosEBDContext context;

        public UsuarioRepository(PedidosEBDContext context)
        {
            this.context = context;
        }

        public void Add(Usuario usuario)
        {
            context.Add(usuario);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByID(int id)
        {
            return await context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> GetByNome(string nome)
        {
            return await context.Usuarios.Where(x => x.NomeUsuario == nome).FirstOrDefaultAsync();
        }

        public async Task<Usuario> Login(string usuario, string senha)
        {
            return await context.Usuarios.Where(x => x.NomeUsuario == usuario && x.Password == senha).FirstOrDefaultAsync();
        }

        public bool Remove(int id)
        {
            var usuario = context.Usuarios.Find(id);
            if (usuario == null)
                return false;
            else
            {
                context.Usuarios.Remove(usuario);
                context.SaveChanges();
                return true;
            }
        }

        public void Update(Usuario usuario)
        {
            context.Update(usuario);
            try
            {
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
