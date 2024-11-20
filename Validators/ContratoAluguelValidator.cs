using FluentValidation;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class ContratoAluguelValidator : AbstractValidator<ContratoAluguel>
    {
        public ContratoAluguelValidator()
        {
            // Validação para ContratoId
            RuleFor(x => x.ContratoId)
                .NotEmpty().WithMessage("O ID do contrato é obrigatório.");

            // Validação para ImovelId
            RuleFor(x => x.ImovelId)
                .NotEmpty().WithMessage("O ID do imóvel é obrigatório.");

            // Validação para LocadorId
            RuleFor(x => x.LocadorId)
                .NotEmpty().WithMessage("O ID do locador é obrigatório.");

            // Validação para LocatarioId
            RuleFor(x => x.LocatarioId)
                .NotEmpty().WithMessage("O ID do locatário é obrigatório.");

            // Validação para ValorContrato
            RuleFor(x => x.ValorContrato)
                .GreaterThanOrEqualTo(0).WithMessage("O valor do contrato deve ser maior ou igual a zero.");

            // Validação para ValorCondominio
            RuleFor(x => x.ValorCondominio)
                .GreaterThanOrEqualTo(0).WithMessage("O valor do condomínio deve ser maior ou igual a zero.");

            // Validação para OutrosValores
            RuleFor(x => x.OutrosValores)
                .GreaterThanOrEqualTo(0).WithMessage("Outros valores devem ser maiores ou iguais a zero.");

            // Validação para InicioContrato
            RuleFor(x => x.InicioContrato)
                .NotEmpty().WithMessage("A data de início do contrato é obrigatória.")
                .Must(date => date.Date >= DateTime.UtcNow.Date)
                .WithMessage("A data de início do contrato não pode estar no passado.");

            // Validação para FimContrato
            RuleFor(x => x.FimContrato)
                .GreaterThan(x => x.InicioContrato)
                .When(x => x.FimContrato.HasValue)
                .WithMessage("A data de fim do contrato deve ser posterior à data de início.");

            // Validação para VencimentoAluguel
            RuleFor(x => (int)x.VencimentoAluguel)
                .InclusiveBetween(1, 31)
                .WithMessage("O vencimento do aluguel deve estar entre 1 e 31.");

            // Validação para StatusContrato
            RuleFor(x => x.StatusContrato)
                .NotEmpty().WithMessage("O status do contrato é obrigatório.")
                .MaximumLength(20).WithMessage("O status do contrato deve ter no máximo 20 caracteres.")
                .Must(status => status == "ativo" || status == "inativo" || status == "rescindido")
                .WithMessage("O status do contrato deve ser 'ativo', 'inativo' ou 'rescindido'.");

            // Validação para UltimaRenovacao
            RuleFor(x => x.UltimaRenovacao)
                .GreaterThanOrEqualTo(x => x.InicioContrato)
                .When(x => x.UltimaRenovacao.HasValue)
                .WithMessage("A última renovação não pode ser anterior à data de início do contrato.");

            // Validação para TempoContrato
            RuleFor(x => x.TempoContrato)
                .GreaterThanOrEqualTo((byte)0).WithMessage("O tempo do contrato deve ser maior ou igual a zero.");

            // Validação para DataCriacao
            RuleFor(x => x.DataCriacao)
                .NotEmpty().WithMessage("A data de criação do contrato é obrigatória.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de criação não pode ser no futuro.");
        }
    }
}
