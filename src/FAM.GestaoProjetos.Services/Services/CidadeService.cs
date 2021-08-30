using AutoMapper;
using FAM.GestaoProjetos.Application.Utils;
using FAM.GestaoProjetos.Application.Validations;
using FAM.GestaoProjetos.Application.ViewModels;
using FAM.GestaoProjetos.Application.ViewModels.Cidade;
using FAM.GestaoProjetos.Domain.Interfaces;
using FAM.GestaoProjetos.Domain.Models;
using FAM.GestaoProjetos.Services.Interfaces;
using System;
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

        public async Task<PagedViewModel<CidadeViewModel>> BuscarTodos()
        {
            return _map.Map<PagedViewModel<CidadeViewModel>>(await _repository.Buscar(null, null));
        }

        public async Task<CidadeViewModel> BurcarPorId(Guid id)
        {
            return _map.Map<CidadeViewModel>(await buscarPorId(id));
        }

        public async Task<CidadeViewModel> Criar(CriarCidadeViewModel viewModel)
        {
            Validate(new CidadeValidation(), viewModel);

            var model = new Cidade(viewModel.nome);
            return _map.Map<CidadeViewModel>(await _repository.Criar(model));
        }

        public async Task<CidadeViewModel> Alterar(CriarCidadeViewModel viewModel, Guid id)
        {
            var model = await buscarPorId(id);

            var newViewModel = new CidadeViewModel(id, viewModel.nome, model.Ativo);

            var newModel = _map.Map<Cidade>(newViewModel);
            return _map.Map<CidadeViewModel>(await _repository.Alterar(newModel));
        }

        public async Task Inativar(Guid id)
        {
            var model = await buscarPorId(id);

            var newViewModel = new CidadeViewModel(id, model.Nome, false);

            var newModel = _map.Map<Cidade>(newViewModel);
            await _repository.Alterar(newModel);
            return;
        }

        public async Task<CidadeViewModel> Ativar(Guid id)
        {
            var model = await buscarPorId(id);

            var newViewModel = new CidadeViewModel(id, model.Nome, true);

            var newModel = _map.Map<Cidade>(newViewModel);
            return _map.Map<CidadeViewModel>(await _repository.Alterar(newModel));
        }

        private async Task<Cidade> buscarPorId(Guid id)
        {
            var model = await _repository.BuscarPorId(id);

            if (model == null) EntityNotFound("Cidade não cadastrada");

            return model;
        }

        public void Dispose() =>
           _repository.Dispose();
    }
}
