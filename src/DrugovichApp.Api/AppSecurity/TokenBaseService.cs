using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DrugovichApp.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace DrugovichApp.Api.AppSecurity;

public static class TokenBaseService
{
    public static string Generate(Usuario usuario)
    {

        var token = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, usuario.NomeUsuario), new Claim(ClaimTypes.Role, usuario.Gerente.Nivel) }),
            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

        };

        var tokenGenereted = token.CreateToken(tokenDescriptor);
        return token.WriteToken(tokenGenereted);
    }


}