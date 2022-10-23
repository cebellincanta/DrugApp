namespace DrugovichApp.Domain.DTO;

public class ClienteDTO : BaseDTO<Guid>
{
    public string Cnpj { get; set; }
    public string Nome { get; set; }
    public DateTime DataFundacao { get; set; }
    public Guid GrupoId { get; set; }
    public GrupoDTO Grupo { get; set; }
}