using System.Text.Json.Serialization;
using DrugovichApp.Domain.VO;

namespace DrugovichApp.Domain.Response;

public sealed class ErroResponse
{
    public ErroResponse(string code, List<ValidacaoErro> listError)
    {
        Code = code;
        this.listError = listError;
    }

    [JsonPropertyName("code")]
    public string Code { get; init;}
    [JsonPropertyName("mensagem")]
    public List<ValidacaoErro> listError { get; init; }

}