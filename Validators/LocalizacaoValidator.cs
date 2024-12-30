using FluentValidation;
using imobcrm.DTOs;

namespace imobcrm.Validators;
public class LocalizacaoValidator : AbstractValidator<LocalizacaoDTO>
{
   public LocalizacaoValidator()
    {
        // Validação para Cidade
        RuleFor(x => x.Cidade)
            .NotEmpty().WithMessage("A cidade é obrigatória.")
            .MaximumLength(100).WithMessage("A cidade deve ter no máximo 100 caracteres.");

        // Validação para Estado
        RuleFor(x => x.Estado)
            .NotEmpty().WithMessage("O estado é obrigatório.")
            .MaximumLength(100).WithMessage("O estado deve ter no máximo 100 caracteres.");

        // Validação para Bairro
        RuleFor(x => x.Bairro)
            .MaximumLength(100).WithMessage("O bairro deve ter no máximo 100 caracteres.");
    }
}
