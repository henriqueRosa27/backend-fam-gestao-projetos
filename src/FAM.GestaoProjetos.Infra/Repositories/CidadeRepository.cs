using FAM.GestaoProjetos.Domain.Interfaces;
using FAM.GestaoProjetos.Domain.Models;
using FAM.GestaoProjetos.Infra.Context;

namespace FAM.GestaoProjetos.Infra.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(GestaoProjetosContext context): base(context)
        { }
    }
}
