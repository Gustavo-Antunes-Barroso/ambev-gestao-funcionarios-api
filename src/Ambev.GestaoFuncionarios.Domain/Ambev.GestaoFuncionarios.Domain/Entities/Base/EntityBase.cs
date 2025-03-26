namespace Ambev.GestaoFuncionarios.Domain.Entities.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            if(Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }

            if(DataCriacao == DateTime.MinValue)
            {
                DataCriacao = DateTime.Now;
            }

            if(DataAtualizacao == DateTime.MinValue)
            {
                DataAtualizacao = DateTime.Now;
            }
        }
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
