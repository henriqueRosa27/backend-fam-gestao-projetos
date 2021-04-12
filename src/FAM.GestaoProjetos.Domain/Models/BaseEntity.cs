using System;

namespace FAM.GestaoProjetos.Domain.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
