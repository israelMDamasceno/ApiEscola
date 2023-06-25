using Domain.Command;
using Domain.ViewModel;

namespace Data.Interface
{
    public interface IUsuarioRepository
    {
        Task<UsuarioViewModel> GetBuscarUsuarioLogado(UsuarioCommand command);
        Task<UsuarioViewModel> GetBuscarUsuario(int UsuarioId);
        Task<int> PostAsync(InsertUsuarioCommand usuario);
        Task<int> PutAsync(EditarUsuarioCommand usuario);
        Task<bool> ExisteNome(string Nome);
        Task<bool> ExisteUsuario(string Usuario);
        Task<int> PutAtivarInativarAsync(int id, bool Ativo);
    }
}
