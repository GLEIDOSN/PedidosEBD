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
    public class CargosController : Controller
    {
        private readonly ICargoService cargoService;

        public CargosController(ICargoService cargoService)
        {
            this.cargoService = cargoService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetAll()
        {
            var listaCargos = await cargoService.GetCargos();
            if (listaCargos.Any())
                return Ok(listaCargos);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Cargo>> GetById(int id)
        {
            var cargo = await cargoService.GetByID(id);
            if (cargo == null)
                return NotFound();
            else
                return Ok(cargo);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(Cargo cargo)
        {
            try 
            {
                cargoService.Add(cargo);
            }
            catch(Exception e)
            {
                return BadRequest("Erro ao tentar inserir registro: " + e.Message);
            }            
            return Ok("Registro salvo com Sucesso!");
        }

        [HttpPut]
        [Route("Put")]
        public ActionResult Put(Cargo cargo)
        {
            try
            {
                cargoService.Update(cargo);
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
                encontrouRegistro = cargoService.Remove(id);
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
