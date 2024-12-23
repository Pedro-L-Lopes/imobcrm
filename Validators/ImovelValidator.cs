﻿using FluentValidation;
using imobcrm.DTOs;
using imobcrm.Models;

namespace imobcrm.Validators
{
    public class ImovelValidator : AbstractValidator<ImovelDTO>
    {
        public ImovelValidator()
        {
            // Validação para ProprietarioId
            RuleFor(x => x.ProprietarioId)
                .NotEmpty().WithMessage("O ID do proprietário é obrigatório.");

            // Validação para Finalidade
            RuleFor(x => x.Finalidade)
                .NotEmpty().WithMessage("A finalidade é obrigatória.")
                .MaximumLength(20).WithMessage("A finalidade deve ter no máximo 20 caracteres.");

            // Validação para TipoImovel
            RuleFor(x => x.TipoImovel)
                .NotEmpty().WithMessage("O tipo de imóvel é obrigatório.")
                .MaximumLength(45).WithMessage("O tipo de imóvel deve ter no máximo 45 caracteres.");

            // Validação para Situacao
            RuleFor(x => x.Situacao)
                .NotEmpty().WithMessage("A situação é obrigatória.")
                .MaximumLength(45).WithMessage("A situcação deve ter no máximo 45 caracteres.");

            // Validação para Valor
            RuleFor(x => x.Valor)
                .GreaterThanOrEqualTo(0).WithMessage("O valor deve ser maior ou igual a zero.");

            // Validação para SiteCod
            RuleFor(x => x.SiteCod)
                .MaximumLength(15).WithMessage("O código pode ter no máximo 15 digitos");

            // Validação para ValorCondominio
            RuleFor(x => x.ValorCondominio)
                .GreaterThanOrEqualTo(0).When(x => x.ValorCondominio.HasValue)
                .WithMessage("O valor do condomínio, se informado, deve ser maior ou igual a zero.");

            // Validação para Área
            RuleFor(x => x.Area)
                .GreaterThan(0).When(x => x.Area.HasValue)
                .WithMessage("A área, se informada, deve ser maior que zero.");

            // Validação para Observacoes
            RuleFor(x => x.Observacoes)
                .MaximumLength(255).WithMessage("As observações devem ter no máximo 255 caracteres.");

            // Validação para Descricao
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória")
                .MaximumLength(255).WithMessage("A descrição deve ter no máximo 255 caracteres.");

            // Validação para ValorAutorizacao
            RuleFor(x => x.ValorAutorizacao)
                .GreaterThanOrEqualTo(0).When(x => x.ValorAutorizacao.HasValue)
                .WithMessage("O valor de autorização, se informado, deve ser maior ou igual a zero.");

            // Validação para TipoAutorizacao
            RuleFor(x => x.TipoAutorizacao)
                .MaximumLength(20).WithMessage("O tipo de autorização deve ter no máximo 20 caracteres.");

            // Validação para DataAutorizacao
            RuleFor(x => x.DataAutorizacao)
                .LessThanOrEqualTo(DateTime.UtcNow).When(x => x.DataAutorizacao.HasValue)
                .WithMessage("A data de autorização não pode estar no futuro.");

            // Validação para EnderecoId
            RuleFor(x => x.LocalizacaoId)
                .NotEmpty().WithMessage("O ID da localização é obrigatório.");

            // Validação para Rua
            RuleFor(x => x.Rua)
                .MaximumLength(100).WithMessage("A rua deve ter no máximo 100 caracteres.");

            // Validação para Numero
            RuleFor(x => x.Numero)
                .MaximumLength(50).WithMessage("O número deve ter no máximo 50 caracteres.");
        }
    }
}
