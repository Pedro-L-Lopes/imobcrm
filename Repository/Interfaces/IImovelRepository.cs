using imobcrm.Models;

namespace imobcrm.Repository.Interfaces;
public interface IImovelRepository
{
    Task<Imovel> InsertProperty(Imovel imovel);
}
