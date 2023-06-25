using Domain.Command;
using Domain.ViewModel;

namespace Data.Interface
{
    public interface ICursoRepository
    {
        Task<bool> ExisteCurso(string Nome);
        Task<int> PostAsync(string Nome, bool Ativo);
        Task<IEnumerable<CursoViewModel>> ListarCursosAsync();
    }
}
