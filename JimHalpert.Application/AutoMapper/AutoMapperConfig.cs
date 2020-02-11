using AutoMapper;

namespace JimHalpert.Application.AutoMapper
{
    using Domain.Entity;
    using JimHalpert.Application.ViewModel;

    public static class AutoMapperConfig
    {
        public static MapperConfiguration Config;

        public static void RegisterMappings()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Aviao, AviaoViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<Cliente, ClienteViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<Servico, ServicoViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<Tarefa, TarefaViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<TarefaItem, TarefaItemViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<TipoDeCliente, TipoDeClienteViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<TipoDePessoa, TipoDePessoaViewModel>().MaxDepth(2).ReverseMap();
            }
            );
        }
    }
}