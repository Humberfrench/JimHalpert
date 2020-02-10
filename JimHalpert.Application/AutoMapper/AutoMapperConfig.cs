using AutoMapper;

namespace JimHalpert.Application.AutoMapper
{
    using Domain.Entity;
    using JimHalpert.Application.ViewModel;

    //using Domain.ObjectValue;

    public static class AutoMapperConfig
    {
        public static MapperConfiguration Config;

        public static void RegisterMappings()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Aviao, AviaoViewModel>().MaxDepth(2).ReverseMap();
            }
            );
        }
    }
}