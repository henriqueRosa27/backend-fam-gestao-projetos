using AutoMapper;
using FAM.GestaoProjetos.Application.ViewModels;
using FAM.GestaoProjetos.Application.ViewModels.Cidade;
using FAM.GestaoProjetos.Domain.Models;
using FAM.GestaoProjetos.Domain.Models.Agregates;

namespace FAM.GestaoProjetos.Application.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PagedModel<Cidade>, PagedViewModel<CidadeViewModel>>();
            CreateMap<Cidade, CidadeViewModel>();
        }
    }
}
