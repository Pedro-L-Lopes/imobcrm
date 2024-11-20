using FluentValidation;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado é inválido.")
                .MaximumLength(100).WithMessage("O e-mail deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-\d{4}$").WithMessage("O formato do telefone é inválido.");

            RuleFor(c => c.CpfCnpj)
                .NotEmpty().WithMessage("O CPF/CNPJ é obrigatório.")
                .Matches(@"^\d{11}$|^\d{14}$").WithMessage("O CPF deve ter 11 dígitos ou o CNPJ deve ter 14 dígitos.");

            RuleFor(c => c.Sexo)
                .NotEmpty().WithMessage("O sexo é obrigatório.")
                .Must(s => s == 'M' || s == 'F').WithMessage("O sexo deve ser 'M' para Masculino ou 'F' para Feminino.");

            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.UtcNow).WithMessage("A data de nascimento não pode ser no futuro.");

            RuleFor(c => c.DataCriacao)
                .NotEmpty().WithMessage("A data de criação é obrigatória.");
        }
    }
}
