using System.Collections.Generic;

namespace FAM.GestaoProjetos.Application.ViewModels
{
    public class ErroValidacaoViewModel
    {
        public ErroValidacaoViewModel(List<string> erros, List<ErroDetalhado> errosDetalhados)
        {
            Erros = erros;
            ErrosDetalhados = errosDetalhados;
        }

        public List<string> Erros { get; set; }

        public List<ErroDetalhado> ErrosDetalhados { get; set; }
    }

    public class ErroDetalhado
    {
        public ErroDetalhado(string erro, string propriedade, string tipo)
        {
            Erro = erro;
            Propriedade = propriedade;
            Tipo = tipo;
        }

        public string Erro { get; set; }

        public string Propriedade { get; set; }

        public string Tipo { get; set; }
    }

}
