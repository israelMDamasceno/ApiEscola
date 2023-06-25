using Domain.ViewModel;

namespace Service.Interfaces
{
    public interface ITurmaService
    {
        Task<ResultDefault> PostAsync(string Nome, bool Ativo, int Ano, int CursoId);
        Task<IEnumerable<TurmaViewModel>> ListarTurmasAsync();
    }
}
