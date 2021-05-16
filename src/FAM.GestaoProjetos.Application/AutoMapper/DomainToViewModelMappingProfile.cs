using AutoMapper;
using FAM.GestaoProjetos.Application.ViewModels.Cidade;
using FAM.GestaoProjetos.Domain.Models;

namespace FAM.GestaoProjetos.Application.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cidade, CidadeViewModel>();
        }
    }
}
