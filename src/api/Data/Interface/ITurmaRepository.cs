using Domain.ViewModel;

namespace Data.Interface
{
    public interface ITurmaRepository
    {
        Task<int> PostAsync(string Nome, bool Ativo, int Ano, int CursoId);
        Task<IEnumerable<TurmaViewModel>> ListarTurmasAsync();
        Task<bool> ExisteTurma(string Nome);
    }
}
