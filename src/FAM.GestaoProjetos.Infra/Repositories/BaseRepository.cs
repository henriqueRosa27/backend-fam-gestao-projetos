using FAM.GestaoProjetos.Domain.Interfaces;
using FAM.GestaoProjetos.Domain.Models;
using FAM.GestaoProjetos.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
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

        public virtual async Task<TModel> BuscarPorId(Guid id) =>
          await DbSet.FirstOrDefaultAsync(c => c.Id.Equals(id));

        public async Task<TModel> Criar(TModel model)
        {
            var t = DbSet.Add(model);
            await SaveChanges();

            return t.Entity;
        }

        public async Task<TModel> Alterar(TModel model)
        {
            var t = DbSet.Update(model);
            await SaveChanges();

            return t.Entity;
        }

        public async Task<int> SaveChanges() =>
            await Db.SaveChangesAsync();

        public void Dispose() =>
            Db?.Dispose();
    }
}
