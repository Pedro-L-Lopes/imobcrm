using FluentValidation;
using imobcrm.DTOs;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class ImovelValidator : AbstractValidator<ImovelDTO>
    {
        public ImovelValidator()
        {
            RuleFor(x => x.ProprietarioId)
                .NotEmpty().WithMessage("O ID do proprietário é obrigatório.");
            
            RuleFor(x => x.LocalizacaoId)
                .NotEmpty().WithMessage("O a localização é obrigatória.");

            RuleFor(x => x.Finalidade)
                .NotEmpty().WithMessage("A finalidade é obrigatória.")
                .MaximumLength(50).WithMessage("A finalidade deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Destinacao)
                .NotEmpty().WithMessage("A destinação é obrigatória.")
                .MaximumLength(50).WithMessage("A destinação deve ter no máximo 50 caracteres.");

            RuleFor(x => x.TipoImovel)
                .NotEmpty().WithMessage("O tipo de imóvel é obrigatório.")
                .MaximumLength(45).WithMessage("O tipo de imóvel deve ter no máximo 45 caracteres.");

            RuleFor(x => x.Situacao)
                .NotEmpty().WithMessage("A situação é obrigatória.")
                .MaximumLength(50).WithMessage("A situcação deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Valor)
                .GreaterThanOrEqualTo(0).WithMessage("O valor deve ser maior ou igual a zero.");

            RuleFor(x => x.SiteCod)
                .MaximumLength(20).WithMessage("O código pode ter no máximo 20 digitos");

            RuleFor(x => x.ValorCondominio)
                .GreaterThanOrEqualTo(0).When(x => x.ValorCondominio.HasValue)
                .WithMessage("O valor do condomínio, se informado, deve ser maior ou igual a zero.");

            RuleFor(x => x.Area)
                .GreaterThan(0).When(x => x.Area.HasValue)
                .WithMessage("A área, se informada, deve ser maior que zero.");

            RuleFor(x => x.Observacoes)
                .MaximumLength(1000).WithMessage("As observações devem ter no máximo 1000 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória")
                .MaximumLength(1000).WithMessage("A descrição deve ter no máximo 1000 caracteres.");

            RuleFor(x => x.AvaliacaoValor)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor da avaliação, se informado, deve ser maior ou igual a zero.");

            RuleFor(x => x.ValorAutorizacao)
                .GreaterThanOrEqualTo(0).When(x => x.ValorAutorizacao.HasValue)
                .WithMessage("O valor de autorização, se informado, deve ser maior ou igual a zero.");

            RuleFor(x => x.TipoAutorizacao)
                .MaximumLength(30).WithMessage("O tipo de autorização deve ter no máximo 30 caracteres.");

            RuleFor(x => x.DataAutorizacao)
                .LessThanOrEqualTo(DateTime.UtcNow).When(x => x.DataAutorizacao.HasValue)
                .WithMessage("A data de autorização não pode estar no futuro.");

            RuleFor(x => x.Rua)
                .MaximumLength(100).WithMessage("A rua deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Numero)
                .MaximumLength(50).WithMessage("O número deve ter no máximo 50 caracteres.");
            
            RuleFor(x => x.Cep)
                .MaximumLength(15).WithMessage("O CEP deve ter no máximo 15 caracteres.");
        }
    }
}
