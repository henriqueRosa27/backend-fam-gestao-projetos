using FAM.GestaoProjetos.Domain.Interfaces;
using FAM.GestaoProjetos.Domain.Models;
using FAM.GestaoProjetos.Domain.Models.Agregates;
using FAM.GestaoProjetos.Infra.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Infra.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(GestaoProjetosContext context): base(context)
        { }

        public async Task<PagedModel<Cidade>> Buscar(string nome, bool? ativo)
        {
            var query = Db.Cidades.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(c => c.Nome.Contains(nome));
            }

            if (ativo.HasValue)
            {
                query = query.Where(c => c.Ativo.Equals(ativo));
            }

            var result = await query.Paginar(1, 1);

            return result;
        }
    }
}
