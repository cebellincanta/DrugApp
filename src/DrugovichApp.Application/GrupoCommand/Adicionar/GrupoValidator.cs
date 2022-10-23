using FluentValidation;

namespace DrugovichApp.Application.GrupoCommand.Adicionar;

public class GrupoValidator : AbstractValidator<GrupoRequest>
{
    public GrupoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Informe o nome do Grupo")
            .NotNull()
            .WithMessage("Informe o nome do Grupo");
    }
}