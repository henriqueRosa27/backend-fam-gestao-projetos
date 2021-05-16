using FAM.GestaoProjetos.Application.ViewModels.Cidade;
using FluentValidation;

namespace FAM.GestaoProjetos.Application.Validations
{
    public class CidadeValidation : AbstractValidator<CriarCidadeViewModel>
    {
        public CidadeValidation()
        {
            RuleFor(c => c.nome)
                .NotEmpty().WithMessage("Por favor, preencha o nome")
                .Length(2, 50).WithMessage("O nome deve conter entre 2 e 50 caracteres");
        }
    }
}
