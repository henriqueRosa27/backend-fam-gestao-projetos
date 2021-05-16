using System;

namespace FAM.GestaoProjetos.Application.ViewModels.Cidade
{
    public class CidadeViewModel : BaseViewModel
    {
        public CidadeViewModel()
        { }

        public CidadeViewModel(Guid id, string nome, bool ativo)
        {
            this.id = id;
            this.nome = nome;
            this.ativo = ativo;
        }

        public string nome { get; set; }
        public bool ativo { get; set; }
    }
}
