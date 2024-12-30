using FluentValidation;
using imobcrm.Models;
using System;

namespace imobcrm.Validators
{
    public class PagamentoAluguelValidator : AbstractValidator<PagamentoAluguel>
    {
        public PagamentoAluguelValidator()
        {
            RuleFor(x => x.PagamentoAluguelId)
                .NotEmpty().WithMessage("O ID do pagamento do aluguel é obrigatório.");

            RuleFor(x => x.ContratoId)
                .NotEmpty().WithMessage("O ID do contrato é obrigatório.");

            RuleFor(x => x.PeriodoInicio)
                .NotEmpty().WithMessage("O início do período é obrigatório.");

            RuleFor(x => x.PeriodoFim)
                .NotEmpty().WithMessage("O fim do período é obrigatório.")
                .GreaterThanOrEqualTo(x => x.PeriodoInicio)
                .WithMessage("O fim do período não pode ser menor que o início do período.");

            RuleFor(x => x.ValorPago)
                .GreaterThan(0).When(x => x.ValorPago.HasValue)
                .WithMessage("O valor pago deve ser maior que zero.");

            RuleFor(x => x.StatusPagamento)
                .NotEmpty().WithMessage("O status do pagamento é obrigatório.")
                .MaximumLength(50).WithMessage("O status do pagamento deve ter no máximo 50 caracteres.")
                .Must(x => x == "Em dia" || x == "Em atraso" || x == "Indefinido")
                .WithMessage("O status do pagamento deve ser 'em dia', 'em atraso' ou 'Indefinido'.");

            RuleFor(x => x.DataVencimentoAluguel)
                .NotEmpty().WithMessage("A data de vencimento do aluguel é obrigatória.");

            RuleFor(x => x.DataPagamento)
                .GreaterThanOrEqualTo(x => x.PeriodoInicio)
                .When(x => x.DataPagamento.HasValue)
                .WithMessage("A data de pagamento não pode ser anterior ao início do período.");

            RuleFor(x => x.UltimaEdicao)
                .LessThanOrEqualTo(DateTime.Now)
                .When(x => x.UltimaEdicao.HasValue)
                .WithMessage("A última edição não pode ser no futuro.");
        }
    }
}
