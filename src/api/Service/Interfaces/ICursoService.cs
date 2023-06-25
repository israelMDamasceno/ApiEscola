using Domain.ViewModel;

namespace Service.Interfaces
{
    public interface ICursoService
    {
        Task<ResultDefault> PostAsync(string Nome, bool Ativo);
        Task<IEnumerable<CursoViewModel>> ListarCursosAsync();
    }
}
