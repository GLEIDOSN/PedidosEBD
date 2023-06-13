using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.Interfaces;
using Pedidos.Domain.Dtos;
using Pedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedidos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var listaUsuarios = await usuarioService.GetUsuarios();
            if (listaUsuarios.Any())
                return Ok(listaUsuarios);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var usuario = await usuarioService.GetByID(id);
            if (usuario == null)
                return NotFound();
            else
                return Ok(usuario);
        }

        [HttpGet]
        [Route("GetByNome")]
        public async Task<ActionResult<Usuario>> GetByNome(string nome)
        {
            var usuario = await usuarioService.GetByNome(nome);
            if (usuario == null)
                return NotFound();
            else
                return Ok(usuario);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(Usuario usuario)
        {
            try
            {
                usuarioService.Add(usuario);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao tentar inserir registro: " + e.Message);
            }
            return Ok("Registro salvo com Sucesso!");
        }

        [HttpPost]
        [Route("Nova-conta")]
        public async Task<ActionResult> NovaConta(NovoUsuarioDto novoUsuarioDto)
        {
            _ = novoUsuarioDto ?? throw new ArgumentNullException(nameof(novoUsuarioDto));

            var usuarioExistente = await usuarioService.GetByNome(novoUsuarioDto.NomeUsuario);

            var errors = new List<string>();

            if (usuarioExistente != null)
                errors.Add($"Usuário já existente com este nome ({novoUsuarioDto.NomeUsuario}).");

            if (novoUsuarioDto.Password != novoUsuarioDto.RePassword)
                errors.Add("Senhas digitadas não conferem.");

            if (String.IsNullOrEmpty(novoUsuarioDto.NomeUsuario))
                errors.Add("Nome do usuário não pode ser vazio.");

            if (errors.Count > 0)
                return BadRequest(errors);

            var usuario = new Usuario
            {
                NomeUsuario = novoUsuarioDto.NomeUsuario,
                Password = novoUsuarioDto.Password,
                Ativo = false,
            };

            usuarioService.Add(usuario);
            return Ok("Registro salvo com Sucesso!");
        }

        [HttpGet]
        [Route("Login")]
        public async Task<ActionResult<Usuario>> Login (string nome, string senha)
        {
            var usuario = await usuarioService.Login(nome, senha);

            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return Unauthorized("Usuário encontrado.");
            }
        }


        [HttpPut]
        [Route("Put")]
        public ActionResult Put(Usuario usuario)
        {
            try
            {
                usuarioService.Update(usuario);
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
                encontrouRegistro = usuarioService.Remove(id);
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
