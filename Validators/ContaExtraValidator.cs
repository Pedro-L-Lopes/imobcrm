using FluentValidation;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class ContaExtraValidator : AbstractValidator<ContaExtra>
    {
        public ContaExtraValidator()
        {
            RuleFor(x => x.IdContaExtra)
                .NotEmpty().WithMessage("O ID da conta extra é obrigatório.");

            RuleFor(x => x.Codigo)
                .GreaterThan(0).WithMessage("O código deve ser maior que zero.");

            RuleFor(x => x.ContratoId)
                .NotEmpty().WithMessage("O ID do contrato é obrigatório.");

            RuleFor(x => x.TipoConta)
                .NotEmpty().WithMessage("O tipo da conta é obrigatório.")
                .MaximumLength(100).WithMessage("O tipo da conta deve ter no máximo 100 caracteres.");

            RuleFor(x => x.CodigoConta)
                .MaximumLength(50).WithMessage("O código da conta deve ter no máximo 50 caracteres.");

            RuleFor(x => x.StatusPagamento)
                .NotEmpty().WithMessage("O status do pagamento é obrigatório.")
                .MaximumLength(50).WithMessage("O status do pagamento deve ter no máximo 50 caracteres.")
                .Must(status => new[] { "Pendente", "Pago", "Atrasado", "Cancelado", "Em revisão" }.Contains(status))
                .WithMessage("O status do pagamento deve ser um dos valores permitidos: pendente, Pago, Atrasado, Cancelado, Em revisão.");

            RuleFor(x => x.Valor)
                .GreaterThan(0).WithMessage("O valor deve ser maior que zero.");

            RuleFor(x => x.Observacoes)
                .NotEmpty().WithMessage("As observações são obrigatórias.")
                .MaximumLength(500).WithMessage("As observações devem ter no máximo 500 caracteres.");

            RuleFor(x => x.Recorrente)
                .NotNull().WithMessage("O campo 'Recorrente' é obrigatório.")
                .When(x => x.DataPagamento.HasValue)
                .WithMessage("Se houver data de pagamento, a recorrência deve ser especificada.");

        }
    }
}
