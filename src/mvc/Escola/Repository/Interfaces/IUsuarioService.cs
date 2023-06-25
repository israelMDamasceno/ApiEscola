using Refit;
using Repository.Command;
using Repository.ViewModel;

namespace Repository.Interfaces
{
    public interface IUsuarioService
    {
        [Get("/Usuario/v1/BuscarUsuario/{UsuarioId}")]
        Task<ResponseApi<UsuarioViewModel>> BuscarUsuario(int UsuarioId);

        [Post("/Usuario/v1/BuscarUsuario")]
        Task<ResponseApi<UsuarioViewModel>> UsuarioLogado(UsuarioCommand command);

        [Post("/Usuario/v1/CriarUsuario")]
        Task<ResponseApi<int>> NovoUsuario(string Nome, string NomeUsuario, string Senha, int TipoUsuarioId, bool Ativo);

        [Post("/Usuario/v1/EditarUsuario")]
        Task<ResponseApi<UsuarioViewModel>> Editar(int UsuarioId, string Nome, string NomeUsuario, string Senha, int TipoUsuarioId, bool Ativo);

        [Post("/Usuario/v1/InativarAtivar")]
        Task<ResponseApi<UsuarioViewModel>> InativarAtivar(int id, bool Ativo);
        [Post("/Curso/v1/CriarCurso")]
        Task<ResponseApi<int>> NovoCurso(string Nome, bool Ativo);
        
        [Get("/Curso/v1/ListarCursos")]
        Task<ResponseApi<IEnumerable<CursoViewModel>>> ListarCursos();

        [Post("/Turma/v1/CriarTurma")]
        Task<ResponseApi<int>> NovoTurma(string Nome, bool Ativo, int Ano, int CursoId);

        [Get("/Turma/v1/ListarTurmas")]
        Task<ResponseApi<IEnumerable<TurmaViewModel>>> ListarTurmas();
    }
}
