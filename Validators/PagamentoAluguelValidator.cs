using FluentValidation;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class PagamentoAluguelValidator : AbstractValidator<PagamentoAluguel>
    {
        public PagamentoAluguelValidator()
        {
            // Validação para ContratoId
            RuleFor(x => x.ContratoId)
                .NotEmpty().WithMessage("O ID do contrato é obrigatório.");

            // Validação para PeriodoInicio
            RuleFor(x => x.PeriodoInicio)
                .NotEmpty().WithMessage("O início do período é obrigatório.")
                .LessThanOrEqualTo(x => x.PeriodoFim)
                .WithMessage("O início do período não pode ser maior que o fim do período.");

            // Validação para PeriodoFim
            RuleFor(x => x.PeriodoFim)
                .NotEmpty().WithMessage("O fim do período é obrigatório.")
                .GreaterThanOrEqualTo(x => x.PeriodoInicio)
                .WithMessage("O fim do período não pode ser menor que o início do período.");

            // Validação para ValorPago
            RuleFor(x => x.ValorPago)
                .GreaterThan(0).When(x => x.ValorPago.HasValue)
                .WithMessage("O valor pago deve ser maior que zero.");

            // Validação para StatusPagamento
            RuleFor(x => x.StatusPagamento)
                .NotEmpty().WithMessage("O status do pagamento é obrigatório.")
                .MaximumLength(20).WithMessage("O status do pagamento deve ter no máximo 20 caracteres.")
                .Must(x => x == "em dia" || x == "em atraso")
                .WithMessage("O status do pagamento deve ser 'em dia' ou 'em atraso'.");

            // Validação para DataVencimentoAluguel
            RuleFor(x => x.DataVencimentoAluguel)
                .NotEmpty().WithMessage("A data de vencimento do aluguel é obrigatória.")
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("A data de vencimento do aluguel não pode ser no passado.");

            // Validação para DataPagamento
            RuleFor(x => x.DataPagamento)
                .GreaterThanOrEqualTo(x => x.PeriodoInicio)
                .When(x => x.DataPagamento.HasValue)
                .WithMessage("A data de pagamento não pode ser anterior ao início do período.")
                .LessThanOrEqualTo(DateTime.Now)
                .When(x => x.DataPagamento.HasValue)
                .WithMessage("A data de pagamento não pode ser no futuro.");
        }
    }
}
