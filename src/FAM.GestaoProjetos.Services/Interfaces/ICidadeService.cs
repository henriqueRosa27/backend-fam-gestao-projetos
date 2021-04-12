﻿using FAM.GestaoProjetos.Application.ViewModels.Cidade;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Services.Interfaces
{
    public interface ICidadeService : IDisposable
    {
        Task<List<CidadeViewModel>> BuscarTodos();
        Task<CidadeViewModel> Criar(CidadeViewModel viewModel);
    }
}