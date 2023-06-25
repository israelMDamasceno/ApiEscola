using Domain.Command;
using Domain.Enums;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;
        public CursoController(ICursoService service)
        {
            _service = service;
        }

        [HttpPost("v1/CriarCurso")]
        public async Task<IActionResult> NovoCurso(string Nome, bool Ativo)
        {
            return Ok(new { success = true, data = _service.PostAsync(Nome,Ativo).Result });
        }
        [HttpGet("v1/ListarCursos")]
        public async Task<IActionResult> ListarCursos()
        {
            var cursos = await _service.ListarCursosAsync();

            return Ok(new { success = true, data = cursos.ToArray() });
        }
    }
}
