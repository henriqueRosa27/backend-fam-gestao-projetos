using FAM.GestaoProjetos.Application.Utils;
using FluentValidation;
using System.Text.Json;

namespace FAM.GestaoProjetos.Services.Services
{
    public abstract class BaseService
    {
        protected void Validate<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE>
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return;

            throw CustomException.ValidationError(JsonSerializer.Serialize(validator.Errors));
        }
    }
}
