using FAM.GestaoProjetos.Domain.Models;
using FAM.GestaoProjetos.Domain.Models.Agregates;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Domain.Interfaces
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        public Task<PagedModel<Cidade>> Buscar(string nome, bool? ativo);
    }
}
