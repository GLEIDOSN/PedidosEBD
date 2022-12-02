using Pedidos.Application.Interfaces;
using Pedidos.Domain.Interfaces.Repositories;
using Pedidos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Application.Services
{
    public class CongregacaoService : ICongregacaoService
    {
        private readonly ICongregacaoRepository congregacaoRepository;

        public CongregacaoService(ICongregacaoRepository congregacaoRepository)
        {
            this.congregacaoRepository = congregacaoRepository;
        }

        public void Add(Congregacao congregacao)
        {
            congregacaoRepository.Add(congregacao);
        }

        public async Task<Congregacao> GetByID(int id)
        {
            return await congregacaoRepository.GetByID(id);
        }

        public async Task<IEnumerable<Congregacao>> GetCongregacoes()
        {
            return await congregacaoRepository.GetAll();
        }

        public bool Remove(int id)
        {
            return congregacaoRepository.Remove(id);
        }

        public void Update(Congregacao congregacao)
        {
            congregacaoRepository.Update(congregacao);
        }
    }
}
