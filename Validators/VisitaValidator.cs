using FluentValidation;
using imobcrm.DTOs;

namespace imobcrm.Validators
{
    public class VisitaValidator : AbstractValidator<VisitaDTO>
    {
        public VisitaValidator()
        {
            RuleFor(x => x.VisitaId)
                .NotEmpty().WithMessage("O ID da visita é obrigatório.");

            RuleFor(x => x.DataHora)
                .NotEmpty().WithMessage("A data e hora da visita são obrigatórias.");

            RuleFor(x => x.Situacao)
                .NotEmpty().WithMessage("A situação da visita é obrigatória.")
                .MaximumLength(25).WithMessage("A situação da visita deve ter no máximo 25 caracteres.")
                .Must(situacao => new[]
                {
                    "pendente", "confirmada", "cancelada", "reagendada", "em_andamento",
                    "concluida", "nao_compareceu", "em_atendimento"
                }.Contains(situacao))
                .WithMessage("A situação da visita deve ser um dos valores permitidos.");

            RuleFor(x => x.Codigo)
                .GreaterThan(0).WithMessage("O código da visita deve ser maior que zero.");

            RuleFor(x => x.ClienteId)
                .NotEmpty().WithMessage("O ID do cliente é obrigatório.");

            RuleFor(x => x.ImovelId)
                .NotEmpty().WithMessage("O ID do imóvel é obrigatório.");

            RuleFor(x => x.Observacao)
                .MaximumLength(500).WithMessage("A observação deve ter no máximo 500 caracteres.");

            RuleFor(x => x.UltimaEdicao)
                .GreaterThanOrEqualTo(x => x.DataHora)
                .When(x => x.UltimaEdicao.HasValue)
                .WithMessage("A última edição não pode ser anterior à data e hora da visita.");
        }
    }
}
