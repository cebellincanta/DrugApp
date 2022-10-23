namespace DrugovichApp.Domain.DTO;

public class UsuarioDTO : BaseDTO<Guid>
{    
    public string NomeUsuario { get; set; }
    public string Senha { get; set; }
    public Guid GerenteId{ get; set; }
    public GerenteDTO Gerente{ get; set; }
}