using FluentValidation;

namespace DrugovichApp.Application.ClienteCommand.Adicionar;

public class ClienteValidator : AbstractValidator<ClienteRequest>
{
    public ClienteValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Informe o nome do Cliente")
            .NotNull()
            .WithMessage("Informe o nome do Cliente");

        RuleFor(x => x.Cnpj)
            .NotEmpty()
            .WithMessage("Informe o CNPJ do Cliente")
            .NotNull()
            .WithMessage("Informe o CNPJ do CLiente")
            .MinimumLength(14)
            .WithMessage("O Cnpj deve ter 14 caracteres")
            .MaximumLength(14)
            .WithMessage("O Cnpj deve ter 14 caracteres");

        RuleFor(x => x.DataFundacao)
            .NotEmpty()
            .WithMessage("Informe o Data Fundação do Cliente")
            .NotNull()
            .WithMessage("Informe o Data Fundação do Cliente")
            .GreaterThan(DateTime.Now)
            .WithMessage("A data de fundação não pode ser maior que dia de hoje.");
        
        RuleFor(x => x.GrupoId)
            .NotEmpty()
            .WithMessage("Informe o Grupo do Cliente")
            .NotNull()
            .WithMessage("Informe o Grupo do Cliente");
    }
}