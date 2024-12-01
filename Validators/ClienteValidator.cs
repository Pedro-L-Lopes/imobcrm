using FluentValidation;
using imobcrm.DTOs;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteDTO>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(c => c.TipoCliente)
                .NotEmpty().WithMessage("O tipo de cliente não pode ser vazio.")
                .Must(x => x == "Pessoa Fisica" || x == "Pessoa Juridica")
                .WithMessage("O tipo de cliente deve ser Pessoa Fisica ou Pessoa Juridica.");

            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("O e-mail informado é inválido.")
                .MaximumLength(100).WithMessage("O e-mail deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Telefone)
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-\d{4}$").WithMessage("O formato do telefone é inválido.");

            RuleFor(c => c.CpfCnpj)
                .Matches(@"^\d{11}$|^\d{14}$").WithMessage("O CPF deve ter 11 dígitos ou o CNPJ deve ter 14 dígitos.");

            RuleFor(c => c.Sexo)
                .Must(s => s == null || s == 'M' || s == 'F')
                .WithMessage("O sexo deve ser 'M' para Masculino ou 'F' para Feminino.");

            RuleFor(c => c.DataNascimento)
                .LessThan(DateTime.UtcNow).WithMessage("A data de nascimento não pode ser no futuro.");
        }
    }
}
