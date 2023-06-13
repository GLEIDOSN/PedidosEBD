using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Interfaces.Repositories;
using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidosEBD.Infra.Data.Repository
{
    public class CongregacaoRepository : ICongregacaoRepository
    {
        public readonly PedidosEBDContext context;

        public CongregacaoRepository(PedidosEBDContext context)
        {
            this.context = context;
        }

        public void Add(Congregacao congregacao)
        {
            context.Add(congregacao);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Congregacao>> GetAll()
        {
            return await context.Congregacoes.ToListAsync();
        }

        public async Task<Congregacao> GetByID(int id)
        {
            return await context.Congregacoes.FindAsync(id);
        }

        public bool Remove(int id)
        {
            var congregacao = context.Congregacoes.Find(id);
            if (congregacao == null)
                return false;
            else
            {
                context.Remove(congregacao);
                context.SaveChanges();
                return true;
            }
        }

        public void Update(Congregacao congregacao)
        {
            context.Update(congregacao);
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
