using System.Text.Json.Serialization;

namespace DrugovichApp.Domain.VO;

public sealed class ValidacaoErro
{
    public ValidacaoErro(string campo, string mensagem)
    {
        Campo = campo;
        Mensagem = mensagem;
    }

    [JsonPropertyName("campo")]
    public string Campo { get; init;}
    [JsonPropertyName("mensagem")]
    public string Mensagem { get; init; }

}