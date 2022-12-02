using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Domain.Interfaces.Repositories
{
    public interface ICongregacaoRepository
    {
        public Task<IEnumerable<Congregacao>> GetAll();
        public Task<Congregacao> GetByID(int id);
        public void Add(Congregacao congregacao);
        public void Update(Congregacao congregacao);
        public bool Remove(int id);
    }
}
