using AutoMapper;
using Data.Interface;
using Domain.Command;
using Domain.ViewModel;
using Service.Interfaces;

namespace Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private IMapper _mapper;
        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<UsuarioViewModel> GetBuscarUsuarioLogado(UsuarioCommand command)
        {
            return _mapper.Map<UsuarioViewModel>(await _repository.GetBuscarUsuarioLogado(command));
        }
        public async Task<UsuarioViewModel> GetBuscarUsuario(int UsuarioId)
        {
            return _mapper.Map<UsuarioViewModel>(await _repository.GetBuscarUsuario(UsuarioId));
        }


        public async Task<ResultDefault> PostAsync(InsertUsuarioCommand command)
        {
            var result = new ResultDefault();
            var existeNome = await _repository.ExisteNome(command.Nome);
            if (existeNome)
                result.Result = false;

            var existeUsuario = await _repository.ExisteUsuario(command.NomeUsuario);
            if (existeUsuario)
                 result.Result = false;

            int Id = _mapper.Map<int>(await _repository.PostAsync(command));
            if (Id > 0)
                result.Result = true;
            return result;
        }

        public async Task<ResultDefault> PutAsync(EditarUsuarioCommand command)
        {
            var result = new ResultDefault();
            var existeNome = await _repository.ExisteNome(command.Nome);
            if (existeNome)
                result.Result = false;

            var existeUsuario = await _repository.ExisteUsuario(command.NomeUsuario);

            if (existeUsuario)
                result.Result = false;


            int Id = _mapper.Map<int>(await _repository.PutAsync(command));
            if (Id > 0)
                result.Result = true;
            return result;
        }

        public async Task PutAtivarInativarAsync(int id, bool Ativo)
        {
            throw new NotImplementedException();
        }
    }
}
