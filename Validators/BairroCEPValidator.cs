using FluentValidation;
using imobcrm.DTOs.Locations;

namespace imobcrm.Validators;
public class BairroCEPValidator : AbstractValidator<BairroCEPDTO>
{
    public BairroCEPValidator()
    {
        // Validação para Cep
        RuleFor(x => x.Cep)
            .MinimumLength(2)
            .MaximumLength(10).WithMessage("O CEP deve ter no máximo 10 caracteres.")
            .Matches(@"^\d{5}-?\d{3}$").When(x => !string.IsNullOrEmpty(x.Cep))
            .WithMessage("O CEP deve estar no formato válido (ex.: 12345-678).");
        Console.WriteLine("Rdodu aqui");
        // Validação para Bairro
        RuleFor(x => x.Bairro)
            .NotEmpty().WithMessage("O bairro é obrigatório")
            .MaximumLength(50).WithMessage("O bairro deve ter no máximo 50 caracteres.");
    }

}
