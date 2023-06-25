using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _service;
        public TurmaController(ITurmaService service)
        {
            _service = service;
        }

        [HttpPost("v1/CriarTurma")]
        public async Task<IActionResult> NovoTurma(string Nome, bool Ativo, int Ano, int CursoId)
        {
            return Ok(new { success = true, data = _service.PostAsync(Nome, Ativo, Ano, CursoId).Result });
        }
        [HttpGet("v1/ListarTurmas")]
        public async Task<IActionResult> ListarTurmas()
        {
            var cursos = await _service.ListarTurmasAsync();

            return Ok(new { success = true, data = cursos.ToArray() });
        }
    }
}
