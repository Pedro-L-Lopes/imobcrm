﻿using AutoMapper;
using imobcrm.DTOs;
using imobcrm.Errors;
using imobcrm.Models;
using imobcrm.Repository.Interfaces;
using imobcrm.Services.Interfaces;
using System.Net;

namespace imobcrm.Services;
public class ImovelService : IImovelService
{
    private readonly IUnityOfWork _uof;
    private readonly IMapper _mapper;

    public ImovelService(IUnityOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task InsertProperty(ImovelDTO imovelDTO)
    {
        // Verifica se o cliente existe
        //var clientExists = await _uof.ClienteRepository
        //    .GetByIdAsync(imovelDTO.ProprietarioId);
        //if (clientExists == null)
        //{
        //    throw new CustomException(HttpStatusCode.NotFound, "Cliente não encontrado.");
        //}

        // Verifica se a localização existe
        //var locationExists = await _uof.LocalizacaoRepository
        //    .GetByIdAsync(imovelDTO.LocalizacaoId);
        //if (locationExists == null)
        //{
        //    throw new CustomException(HttpStatusCode.NotFound, "Localização não encontrada.");
        //}

        var property = new Imovel
        {
            ProprietarioId = imovelDTO.ProprietarioId,
            Finalidade = imovelDTO.Finalidade,
            TipoImovel = imovelDTO.TipoImovel,
            Valor = imovelDTO.Valor,
            SiteCod = imovelDTO.SiteCod,
            ValorCondominio = imovelDTO.ValorCondominio,
            Area = imovelDTO.Area,
            Observacoes = imovelDTO.Observacoes,
            Descricao = imovelDTO.Descricao,
            Quartos = imovelDTO.Quartos,
            Suites = imovelDTO.Suites,
            Banheiros = imovelDTO.Banheiros,
            SalasEstar = imovelDTO.SalasEstar,
            SalasJantar = imovelDTO.SalasJantar,
            Varanda = imovelDTO.Varanda,
            Garagem = imovelDTO.Garagem,
            ValorAutorizacao = imovelDTO.ValorAutorizacao,
            TipoAutorizacao = imovelDTO.TipoAutorizacao,
            DataAutorizacao = imovelDTO.DataAutorizacao,
            Rua = imovelDTO.Rua,
            Numero = imovelDTO.Numero,
            Cep = imovelDTO.Cep,
            LocalizacaoId = imovelDTO.LocalizacaoId
        };

        await _uof.ImovelRepository.InsertProperty(property);
    }

}