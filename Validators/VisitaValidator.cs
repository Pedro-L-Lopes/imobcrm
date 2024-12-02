using FluentValidation;
using imobcrm.DTOs;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class VisitaValidator : AbstractValidator<VisitaDTO>
    {
        public VisitaValidator()
        {
            // Validação para DataHora
            RuleFor(x => x.DataHora)
                .NotEmpty().WithMessage("A data e hora da visita são obrigatórias.")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("A data e hora da visita não podem ser no passado.");

            // Validação para Situacao
            RuleFor(x => x.Situacao)
                .MaximumLength(50).WithMessage("A situação deve ter no máximo 50 caracteres.")
                .Must(x => x == null || x == "confirmada" || x == "cancelada")
                .WithMessage("A situação deve ser 'confirmada' ou 'cancelada', ou estar vazia.");

            // Validação para Codigo
            RuleFor(x => x.Codigo)
                .GreaterThan(0).WithMessage("O código deve ser maior que zero.");

            // Validação para ClienteId
            RuleFor(x => x.ClienteId)
                .NotEmpty().WithMessage("O ID do cliente é obrigatório.")
                .Must(x => x != Guid.Empty).WithMessage("O ID do cliente deve ser válido.");

            // Validação para ImovelId
            RuleFor(x => x.ImovelId)
                .NotEmpty().WithMessage("O ID do imóvel é obrigatório.")
                .Must(x => x != Guid.Empty).WithMessage("O ID do imóvel deve ser válido.");

            // Validação para Observacao
            RuleFor(x => x.Observacao)
                .MaximumLength(100).WithMessage("A observação deve ter no máximo 100 caracteres.");
        }
    }
}
