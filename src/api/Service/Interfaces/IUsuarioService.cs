using Domain.Command;
using Domain.ViewModel;

namespace Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioViewModel> GetBuscarUsuarioLogado(UsuarioCommand command);
        Task<UsuarioViewModel> GetBuscarUsuario(int UsuarioId);
        Task<ResultDefault> PostAsync(InsertUsuarioCommand usuario);
        Task<ResultDefault> PutAsync(EditarUsuarioCommand usuario);
        Task PutAtivarInativarAsync(int id, bool Ativo);
    }
}
