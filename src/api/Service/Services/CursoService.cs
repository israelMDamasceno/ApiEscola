using AutoMapper;
using Data.Interface;
using Domain.ViewModel;
using Service.Interfaces;

namespace Service.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;
        private IMapper _mapper;
        public CursoService(ICursoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<ResultDefault> PostAsync(string Nome, bool Ativo)
        {
            var result = new ResultDefault();
            var existeNome = await _repository.ExisteCurso(Nome);
            if (existeNome)
                result.Result = false;

            int Id = _mapper.Map<int>(await _repository.PostAsync(Nome, Ativo));
            if (Id > 0)
                result.Result = true;
            return result;
        }

        public async Task<IEnumerable<CursoViewModel>> ListarCursosAsync()
        {
            return _mapper.Map<IEnumerable<CursoViewModel>>(await _repository.ListarCursosAsync());

        }
    }
}
