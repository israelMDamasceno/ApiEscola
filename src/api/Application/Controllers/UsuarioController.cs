using Domain.Command;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }
        [HttpGet("v1/BuscarUsuario/{UsuarioId}")]
        public async Task<IActionResult> BuscarUsuario(int UsuarioId)
        {
            return Ok(new { success = true, data = await _service.GetBuscarUsuario(UsuarioId) });
        }

        [HttpPost("v1/BuscarUsuario")]
        public async Task<IActionResult>UsuarioLogado(UsuarioCommand command)
        {
            return Ok(new { success = true, data = await _service.GetBuscarUsuarioLogado(command)});
        }

        [HttpPost("v1/CriarUsuario")]
        public async Task<IActionResult> NovoUsuario(string Nome, string NomeUsuario, string Senha, int TipoUsuarioId, bool Ativo)
        {
            var command = new InsertUsuarioCommand() { Nome = Nome, NomeUsuario = NomeUsuario, Senha = Senha, TipoUsuarioId = ETipoUsuario.Aluno, Ativo = Ativo};
            return Ok(new { success = true, data = _service.PostAsync(command) });
        }

        [HttpPost("v1/EditarUsuario")]
        public async Task<IActionResult> EditarUsuario(int UsuarioId, string Nome, string NomeUsuario, string Senha, int TipoUsuarioId, bool Ativo)
        {
            var command = new EditarUsuarioCommand() { UsuarioId= UsuarioId, Nome = Nome, NomeUsuario = NomeUsuario, Senha = Senha, TipoUsuarioId = ETipoUsuario.Aluno, Ativo = Ativo };
            return Ok(new { success = true, data = _service.PutAsync(command) });
        }

    }
}
