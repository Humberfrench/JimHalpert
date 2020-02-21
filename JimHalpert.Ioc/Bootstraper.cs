using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;

namespace JimHalpert.Ioc
{
    using Application.Interface;
    using Application.Services;
    using Domain.Inteface.Service;
    using Domain.Inteface.Repository;
    using Repository;
    using Repository.Context;
    using Repository.Interfaces;
    using Repository.UnitOfWork;
    using Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    public static class Bootstraper
    {
        public static void Initializer(IServiceCollection services, IConfiguration configuration)
        {


            //Services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IContextManager, ContextManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IConfiguration, ConfigurationSection>();
            //services.AddScoped<IConfiguration, ConfigurationRoot>();
            //services.AddScoped<IConfigurationProvider, ConfigurationProvider>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            #region Estado
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IEstadoServiceApp, EstadoServiceApp>();
            #endregion

            #region Cliente
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteServiceApp, ClienteServiceApp>();
            #endregion

            #region Servicos
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IServicoService, ServicoService>();
            services.AddScoped<IServicoServiceApp, ServicoServiceApp>();
            #endregion

            #region Cidade
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<ICidadeServiceApp, CidadeServiceApp>();
            #endregion

            #region Tipo de Cliente
            services.AddScoped<ITipoDeClienteRepository, TipoDeClienteRepository>();
            services.AddScoped<ITipoDeClienteService, TipoDeClienteService>();
            services.AddScoped<ITipoDeClienteServiceApp, TipoDeClienteServiceApp>();
            #endregion

            #region Tipo de Pessoa
            services.AddScoped<ITipoDePessoaRepository, TipoDePessoaRepository>();
            services.AddScoped<ITipoDePessoaService, TipoDePessoaService>();
            services.AddScoped<ITipoDePessoaServiceApp, TipoDePessoaServiceApp>();
            #endregion

            services.AddDbContext<JimHalpertContext>(options => options.UseSqlServer(configuration.GetConnectionString("RedDragonContext")));

        }
    }
}
