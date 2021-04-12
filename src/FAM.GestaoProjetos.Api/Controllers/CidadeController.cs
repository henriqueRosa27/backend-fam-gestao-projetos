using FAM.GestaoProjetos.Application.ViewModels.Cidade;
using FAM.GestaoProjetos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FAM.GestaoProjetos.Api.Controllers
{
    [ApiController]
    [Route("api/cidades")]
    public class CidadeController : ControllerBase
    {
        protected readonly ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CidadeViewModel>>> BuscarTodos()
        {
            return await _service.BuscarTodos();
        }

        [HttpPost]
        public async Task<ActionResult<CidadeViewModel>> Criar([FromBody] CidadeViewModel viewModel)
        {
            return await _service.Criar(viewModel);
        }
    }
}
