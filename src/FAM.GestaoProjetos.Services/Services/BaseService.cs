using FAM.GestaoProjetos.Application.Utils;
using FAM.GestaoProjetos.Application.ViewModels;
using FluentValidation;
using System.Collections.Generic;
using System.Text.Json;

namespace FAM.GestaoProjetos.Services.Services
{
    public abstract class BaseService
    {
        protected void Validate<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE>
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return;

            var erros = new List<string>();
            var errosDetalhados = new List<ErroDetalhado>();

            foreach (var error in validator.Errors)
            {
                erros.Add(error.ErrorMessage);
                errosDetalhados.Add(new ErroDetalhado(error.ErrorMessage, error.PropertyName, error.ErrorCode));
            }

            throw CustomException.ValidationError(JsonSerializer.Serialize(new ErroValidacaoViewModel(erros, errosDetalhados)));
        }

        protected void EntityNotFound(string mensagem)
        {
            throw CustomException.EntityNotFound(JsonSerializer.Serialize(new { erro = mensagem }));
        }
    }
}
