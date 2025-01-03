﻿namespace imobcrm.Repository.Interfaces;
public interface IUnityOfWork
{
    IClienteRepository ClienteRepository { get; }
    ILocalizacaoRepository LocalizacaoRepository { get; }
    IImovelRepository ImovelRepository { get; }
    IVisitaRepository VisitaRepository{ get; }
    IContratoAluguelRepository ContratoAluguelRepository { get; }
    Task Commit();
}
