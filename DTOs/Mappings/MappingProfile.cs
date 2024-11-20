using AutoMapper;
using imobcrm.Models;

namespace imobcrm.DTOs.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cliente, ClienteDTO>().ReverseMap();
        CreateMap<ContaExtra, ContaExtraDTO>().ReverseMap();
        CreateMap<ContratoAluguel, ContratoAluguelDTO>().ReverseMap();
        CreateMap<Imovel, ImovelDTO>().ReverseMap();
        CreateMap<Localizacao, LocalizacaoDTO>().ReverseMap();
        CreateMap<PagamentoAluguel, PagamentoAluguelDTO>().ReverseMap();
        CreateMap<Visita, VisitaDTO>().ReverseMap();
    }
}
