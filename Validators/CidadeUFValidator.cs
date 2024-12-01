using FluentValidation;
using imobcrm.DTOs.Locations;

namespace imobcrm.Validators;
public class CidadeUFValidator : AbstractValidator<CidadeUFDTO>
{
    public CidadeUFValidator()
    {
        // Validação para Cidade
        RuleFor(x => x.Cidade)
            .NotEmpty().WithMessage("A cidade é obrigatória.")
            .MaximumLength(50).WithMessage("A cidade deve ter no máximo 50 caracteres.");

        // Validação para Estado
        RuleFor(x => x.Estado)
            .NotEmpty().WithMessage("O estado é obrigatório.")
            .MaximumLength(50).WithMessage("O estado deve ter no máximo 50 caracteres.");
    }
}
