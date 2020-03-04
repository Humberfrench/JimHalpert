using AutoMapper;

namespace JimHalpert.Application.AutoMapper
{
    using Domain.Entity;
    using JimHalpert.Application.ObjectValue;
    using JimHalpert.Application.ViewModel;

    public static class AutoMapperConfig
    {
        public static MapperConfiguration Config;

        public static void RegisterMappings()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cidade, CidadeViewModel>().MaxDepth(1).ReverseMap();
                cfg.CreateMap<CidadeValue, CidadeValueViewModel>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Cliente, ClienteViewModel>().MaxDepth(1).ReverseMap();
                cfg.CreateMap<Estado, EstadoViewModel>().MaxDepth(1).ReverseMap();
                cfg.CreateMap<Mes, MesViewModel>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<NotaFiscal, NotaFiscalViewModel>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<StatusNotaFiscal, StatusNotaFiscalViewModel>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Servico, ServicoViewModel>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<Tarefa, TarefaViewModel>().MaxDepth(1).ReverseMap();
                cfg.CreateMap<TarefaItem, TarefaItemViewModel>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<TipoDeCliente, TipoDeClienteViewModel>().MaxDepth(0).ReverseMap();
                cfg.CreateMap<TipoDePessoa, TipoDePessoaViewModel>().MaxDepth(0).ReverseMap();
            }
            );
        }
    }
}