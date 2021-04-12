﻿using FAM.GestaoProjetos.Domain.Interfaces;
using FAM.GestaoProjetos.Domain.Models;
using FAM.GestaoProjetos.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Infra.Repositories
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
    {
        protected readonly GestaoProjetosContext Db;
        protected readonly DbSet<TModel> DbSet;

        public BaseRepository(GestaoProjetosContext context)
        {
            Db = context;
            DbSet = Db.Set<TModel>();
        }

        public virtual async Task<List<TModel>> BuscarTodos() =>
          await DbSet.ToListAsync();

        public async Task<TModel> Criar(TModel model)
        {
            var t = DbSet.Add(model);
            await SaveChanges();

            return t.Entity;
        }

        public async Task<int> SaveChanges() =>
            await Db.SaveChangesAsync();

        public void Dispose() =>
            Db?.Dispose();


    }
}