using Microsoft.AspNetCore.Mvc;
using Repository.Command;
using Repository.Enums;
using Repository.Service;
using Repository.ViewModel;

namespace Escola.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _service;
        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioCommand command)
        {
            var result = _service.UsuarioLogado(command);
           
            if (result.Result == null)
                return Ok(new { success = true, data = "Você digitou usuário ou senha errada" });

            if (result.Result.TipoUsuarioId == ETipoUsuario.Aluno)
                return RedirectToAction("Aluno", result.Result);

            else
                return RedirectToAction("Secretaria", result.Result);
        }
        [HttpGet]
        public IActionResult Aluno(UsuarioViewModel model)
        {

            return View(model);
        }

        [HttpGet]
        public IActionResult Secretaria(UsuarioViewModel model)
        {

            return View(model);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult CriarTurma()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CriarTurma(CriarTurmaCommand command)
        {

            return View();
        }
        public IActionResult CriarCurso()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CriarCurso(CriarCursoCommand command)
        {
            var result = _service.CriarNovoCurso(command);
            return RedirectToAction("ListarCurso");
        }
        [HttpGet]
        public IActionResult ListarCurso()
        {
            var result =  _service.ListarCursos();
            var list = new List<CursoViewModel>();
            list.AddRange(result.Result.ToList());
            return View(list);
        }
        public IActionResult ListarTurma()
        {
            return View();
        }
        public IActionResult ListarAlunoTurma()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(InsertUsuarioCommand command)
        {
            command.TipoUsuarioId = Repository.Enums.ETipoUsuario.Aluno;
            command.Ativo = true;
            var result = _service.CriarNovoUsuario(command);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int Id)
        {
            var model = new EditarUsuarioCommand();
            var retornoApi = _service.BuscarUsuario(Id);
            model.UsuarioId = Id;
            model.NomeUsuario = retornoApi.Result.NomeUsuario;
            model.Nome = retornoApi.Result.Nome;
            model.Senha = "";
            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(EditarUsuarioCommand command)
        {
            var result = _service.Editar(command);
            var retornoApi = _service.BuscarUsuario(command.UsuarioId);
            if (result.Result.TipoUsuarioId == ETipoUsuario.Aluno)
                return RedirectToAction("Aluno", result.Result);

            else
                return RedirectToAction("Secretaria", result.Result);

        }

        [HttpPost]
        public IActionResult Inativar(int Id, bool Ativo)
        {
            var result = _service.InativarAtivar(Id, Ativo);
            return Index();
        }
    }
}
