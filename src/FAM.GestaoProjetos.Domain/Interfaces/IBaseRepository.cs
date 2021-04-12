﻿using FAM.GestaoProjetos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Domain.Interfaces
{
    public interface IBaseRepository<TModel> : IDisposable where TModel : BaseModel
    {
        Task<List<TModel>> BuscarTodos();
        Task<TModel> Criar(TModel model);
    }
}