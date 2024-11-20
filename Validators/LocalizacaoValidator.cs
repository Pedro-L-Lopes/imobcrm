using FluentValidation;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class LocalizacaoValidator : AbstractValidator<Localizacao>
    {
        public LocalizacaoValidator()
        {
            // Validação para Cep
            RuleFor(x => x.Cep)
                .MaximumLength(10).WithMessage("O CEP deve ter no máximo 10 caracteres.")
                .Matches(@"^\d{5}-?\d{3}$").When(x => !string.IsNullOrEmpty(x.Cep))
                .WithMessage("O CEP deve estar no formato válido (ex.: 12345-678).");

            // Validação para Bairro
            RuleFor(x => x.Bairro)
                .MaximumLength(50).WithMessage("O bairro deve ter no máximo 50 caracteres.");

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
}
