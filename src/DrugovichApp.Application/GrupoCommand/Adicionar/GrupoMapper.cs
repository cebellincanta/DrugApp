using DrugovichApp.Domain.Entities;

namespace DrugovichApp.Application.GrupoCommand.Adicionar;

public static class GrupoMapper
{
    public static Grupo ToGrupo(GrupoRequest request)
    {
       var grupo = new Grupo
       {
            Nome = request.Nome
       };

       return grupo;
    }  
}