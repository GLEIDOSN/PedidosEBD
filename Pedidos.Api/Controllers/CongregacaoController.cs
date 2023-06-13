using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.Interfaces;
using Pedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedidos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CongregacaoController : Controller
    {
        private readonly ICongregacaoService congregacaoService;

        public CongregacaoController(ICongregacaoService congregacaoService)
        {
            this.congregacaoService = congregacaoService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Congregacao>>> GetAll()
        {
            var listaCongregacoes = await congregacaoService.GetCongregacoes();
            if (listaCongregacoes.Any())
                return Ok(listaCongregacoes);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Congregacao>> GetById(int id)
        {
            var congregacao = await congregacaoService.GetByID(id);
            if (congregacao == null)
                return NotFound();
            else
                return Ok(congregacao);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(Congregacao congregacao)
        {
            try
            {
                congregacaoService.Add(congregacao);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao tentar inserir registro: " + e.Message);
            }
            return Ok("Registro salvo com Sucesso!");
        }

        [HttpPut]
        [Route("Put")]
        public ActionResult Put(Congregacao congregacao)
        {
            try
            {
                congregacaoService.Update(congregacao);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao tentar atualizar registro: " + e.Message);
            }
            return Ok("Registro atualizado com Sucesso!");
        }

        [HttpDelete]
        [Route("Remove")]
        public ActionResult Remove(int id)
        {
            bool encontrouRegistro;
            try
            {
                encontrouRegistro = congregacaoService.Remove(id);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao tentar deletar registro: " + e.Message);
            }
            if (encontrouRegistro)
                return Ok("Registro removido com Sucesso!");
            else
                return NotFound("Registro não encontrado!");
        }
    }
}
