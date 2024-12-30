using FluentValidation;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class ContratoAluguelValidator : AbstractValidator<ContratoAluguel>
    {
        public ContratoAluguelValidator()
        {
            RuleFor(x => x.ContratoId)
                .NotEmpty().WithMessage("O ID do contrato é obrigatório.");

            RuleFor(x => x.ImovelId)
                .NotEmpty().WithMessage("O ID do imóvel é obrigatório.");

            RuleFor(x => x.LocadorId)
                .NotEmpty().WithMessage("O ID do locador é obrigatório.");

            RuleFor(x => x.LocatarioId)
                .NotEmpty().WithMessage("O ID do locatário é obrigatório.");

            RuleFor(x => x.ValorContrato)
                .GreaterThanOrEqualTo(0).WithMessage("O valor do contrato deve ser maior ou igual a zero.");

            RuleFor(x => x.ValorCondominio)
                .GreaterThanOrEqualTo(0).WithMessage("O valor do condomínio deve ser maior ou igual a zero.");

            RuleFor(x => x.InicioContrato)
                .NotEmpty().WithMessage("A data de início do contrato é obrigatória.");

            RuleFor(x => x.FimContrato)
                .GreaterThan(x => x.InicioContrato)
                .When(x => x.FimContrato.HasValue)
                .WithMessage("A data de fim do contrato deve ser posterior à data de início.");

            RuleFor(x => (int)x.VencimentoAluguel)
                .InclusiveBetween(1, 30)
                .WithMessage("O vencimento do aluguel deve estar entre 1 e 30.");

            RuleFor(x => x.StatusContrato)
                .NotEmpty().WithMessage("O status do contrato é obrigatório.")
                .MaximumLength(20).WithMessage("O status do contrato deve ter no máximo 20 caracteres.")
                .Must(status => status == "Ativo" || status == "Inativo" || status == "Rescindido" || status == "Moderação")
                .WithMessage("O status do contrato deve ser 'ativo', 'inativo', 'rescindido' ou 'Moderação'.");

            RuleFor(x => x.UltimaRenovacao)
                .GreaterThanOrEqualTo(x => x.InicioContrato)
                .When(x => x.UltimaRenovacao.HasValue)
                .WithMessage("A última renovação não pode ser anterior à data de início do contrato.");

            RuleFor(x => x.TempoContrato)
                .GreaterThanOrEqualTo((byte)0).WithMessage("O tempo do contrato deve ser maior ou igual a zero.");

            RuleFor(x => x.DataCriacao)
                .NotEmpty().WithMessage("A data de criação do contrato é obrigatória.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de criação não pode ser no futuro.");
        }
    }
}
