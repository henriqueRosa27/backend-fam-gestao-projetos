using AutoMapper;
using FAM.GestaoProjetos.Application.Validations;
using FAM.GestaoProjetos.Application.ViewModels.Cidade;
using FAM.GestaoProjetos.Domain.Interfaces;
using FAM.GestaoProjetos.Domain.Models;
using FAM.GestaoProjetos.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Services.Services
{
    public class CidadeService : BaseService, ICidadeService
    {
        protected readonly ICidadeRepository _repository;
        protected readonly IMapper _map;

        public CidadeService(ICidadeRepository repository, IMapper map)
        {
            _repository = repository;
            _map = map;
        }

        public async Task<List<CidadeViewModel>> BuscarTodos()
        {            
            return _map.Map<List<CidadeViewModel>>(await _repository.BuscarTodos());
        }

        public async Task<CidadeViewModel> Criar(CidadeViewModel viewModel)
        {
            Validate(new CidadeValidation(), viewModel);

            var model = new Cidade(viewModel.nome);
            return _map.Map<CidadeViewModel>(await _repository.Criar(model));
        }

        public void Dispose() =>
           _repository.Dispose();
    }
}
