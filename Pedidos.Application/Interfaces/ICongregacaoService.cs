using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Application.Interfaces
{
    public interface ICongregacaoService
    {
        public Task<IEnumerable<Congregacao>> GetCongregacoes();
        public Task<Congregacao> GetByID(int id);
        void Add(Congregacao congregacao);
        void Update(Congregacao congregacao);
        bool Remove(int id);
    }
}
