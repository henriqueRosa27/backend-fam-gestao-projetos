namespace FAM.GestaoProjetos.Domain.Models
{
    public  class Cidade : BaseModel
    {
        public Cidade(string nome, bool ativo = true)
        {
            Nome = nome;
            Ativo = ativo;
        }

        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        // Relacionamentos
    }
}
