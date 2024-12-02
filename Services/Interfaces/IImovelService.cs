using imobcrm.DTOs;

namespace imobcrm.Services.Interfaces;

public interface IImovelService
{
    Task InsertProperty(ImovelDTO imovelDTO);
}
