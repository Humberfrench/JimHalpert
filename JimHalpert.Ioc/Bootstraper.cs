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
            services.AddScoped<IAviaoRepository, AviaoRepository>();
            services.AddScoped<IAviaoService, AviaoService>();
            services.AddScoped<IAviaoServiceApp, AviaoServiceApp>();

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

            services.AddDbContext<JimHalpertContext>(options => options.UseSqlServer(configuration.GetConnectionString("RedDragonContext")));

        }
    }
}
