using FAM.GestaoProjetos.Application.ViewModels.Cidade;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Services.Interfaces
{
    public interface ICidadeService : IDisposable
    {
        Task<List<CidadeViewModel>> BuscarTodos();
        Task<CidadeViewModel> BurcarPorId(Guid id);
        Task<CidadeViewModel> Criar(CriarCidadeViewModel viewModel);
        Task<CidadeViewModel> Alterar(CriarCidadeViewModel viewModel, Guid id);
        Task Inativar(Guid id);
        Task<CidadeViewModel> Ativar(Guid id);
    }
}
