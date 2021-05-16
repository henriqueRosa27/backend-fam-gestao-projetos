using FAM.GestaoProjetos.Application.ViewModels.Cidade;
using FAM.GestaoProjetos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CidadeViewModel>> BuscarPorId(Guid id)
        {
            return await _service.BurcarPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<CidadeViewModel>> Criar([FromBody] CriarCidadeViewModel viewModel)
        {
            return await _service.Criar(viewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CidadeViewModel>> Alterar([FromBody] CriarCidadeViewModel viewModel, [FromRoute]Guid id)
        {
            return await _service.Alterar(viewModel, id);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CidadeViewModel>> Inativar([FromRoute] Guid id)
        {
            await _service.Inativar(id);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult<CidadeViewModel>> Ativar([FromRoute] Guid id)
        {
            return await _service.Ativar(id);
        }
    }
}
