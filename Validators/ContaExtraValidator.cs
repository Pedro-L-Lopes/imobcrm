using FluentValidation;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class ContaExtraValidator : AbstractValidator<ContaExtra>
    {
        public ContaExtraValidator()
        {
            // Validação para o ContratoId
            RuleFor(x => x.ContratoId)
                .NotEmpty().WithMessage("O ID do contrato é obrigatório.");

            // Validação para TipoConta
            RuleFor(x => x.TipoConta)
                .NotEmpty().WithMessage("O tipo da conta é obrigatório.")
                .MaximumLength(50).WithMessage("O tipo da conta deve ter no máximo 50 caracteres.");

            // Validação para CodigoConta
            RuleFor(x => x.CodigoConta)
                .MaximumLength(50).WithMessage("O código da conta deve ter no máximo 50 caracteres.");

            // Validação para DataVencimento
            RuleFor(x => x.DataVencimento)
                .NotEmpty().WithMessage("A data de vencimento é obrigatória.")
                .Must(date => date.Date >= DateTime.UtcNow.Date).WithMessage("A data de vencimento não pode ser no passado.");

            // Validação para StatusPagamento
            RuleFor(x => x.StatusPagamento)
                .NotEmpty().WithMessage("O status do pagamento é obrigatório.")
                .MaximumLength(20).WithMessage("O status do pagamento deve ter no máximo 20 caracteres.")
                .Must(status => status == "em dia" || status == "em atraso")
                .WithMessage("O status do pagamento deve ser 'em dia' ou 'em atraso'.");

            // Validação para Valor
            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");

            // Validação para DataPagamento
            RuleFor(x => x.DataPagamento)
                .GreaterThanOrEqualTo(x => x.DataVencimento)
                .When(x => x.DataPagamento.HasValue)
                .WithMessage("A data de pagamento não pode ser anterior à data de vencimento.");
        }
    }
}
