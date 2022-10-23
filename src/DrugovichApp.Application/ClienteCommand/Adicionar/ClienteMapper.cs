using DrugovichApp.Domain.Entities;

namespace DrugovichApp.Application.ClienteCommand.Adicionar;

public static class ClienteMapper
{
    public static Cliente ToCliente(ClienteRequest request)
    {
       var cliente = new Cliente
       {
            Nome = request.Nome,
            Cnpj = request.Cnpj,
            DataFundacao = request.DataFundacao,
            GrupoId = request.GrupoId
       };

       return cliente;
    }  
}