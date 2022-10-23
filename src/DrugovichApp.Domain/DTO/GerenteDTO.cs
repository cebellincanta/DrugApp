namespace DrugovichApp.Domain.DTO;

public class GerenteDTO : BaseDTO<Guid>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Nivel { get; set; }
    public UsuarioDTO Usuario{ get; set; }
}