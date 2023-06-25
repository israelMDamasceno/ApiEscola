using AutoMapper;
using Data.Interface;
using Domain.ViewModel;
using Service.Interfaces;

namespace Service.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _repository;
        private IMapper _mapper;
        public TurmaService(ITurmaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<ResultDefault> PostAsync(string Nome, bool Ativo, int Ano, int CursoId)
        {
            var result = new ResultDefault();
            var existeNome = await _repository.ExisteTurma(Nome);
            if (existeNome)
                result.Result = false;

            int Id = _mapper.Map<int>(await _repository.PostAsync(Nome, Ativo, Ano, CursoId));
            if (Id > 0)
                result.Result = true;
            return result;
        }

        public async Task<IEnumerable<TurmaViewModel>> ListarTurmasAsync()
        {
            return _mapper.Map<IEnumerable<TurmaViewModel>>(await _repository.ListarTurmasAsync());

        }
    }
}
