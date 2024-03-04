using JimHalpert.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace JimHalpert.Repository.Context
{
    public class ContextManager : IContextManager
    {
        private const string CONTEXT_KEY = "ContextManager.Context";
        private readonly IHttpContextAccessor context;
        private readonly IConfiguration configuration;

        public ContextManager(IHttpContextAccessor context,
                              IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public string GetConnectionString => configuration.GetConnectionString("JimHalpertContext");

        public JimHalpertContext GetContext()
        {
            if (context.HttpContext == null)
                return new JimHalpertContext();

            if (context.HttpContext.Items[CONTEXT_KEY] == null)
            {
                context.HttpContext.Items[CONTEXT_KEY] = new JimHalpertContext();
            }

            return context.HttpContext.Items[CONTEXT_KEY] as JimHalpertContext;
        }
    }
}