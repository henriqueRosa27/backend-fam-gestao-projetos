using FAM.GestaoProjetos.Domain.Models;
using FAM.GestaoProjetos.Domain.Models.Agregates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Infra.Repositories
{
    public static class Pagination
    {
        public static async Task<PagedModel<TModel>> Paginar<TModel>(
            this IQueryable<TModel> query,
            int page,
            int limit) where TModel : BaseModel
        {
            var paged = new PagedModel<TModel>();

            page = (page < 0) ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            paged.TotalItems = await query.CountAsync();

            var startRow = (page - 1) * limit;

            paged.Items = await query
                      .Skip(startRow)
                      .Take(limit)
                      .ToListAsync();

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;
        }
    }
}
