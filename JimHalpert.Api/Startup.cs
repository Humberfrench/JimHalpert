using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace JimHalpert.Api
{
    using static JimHalpert.Ioc.Bootstraper;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.MaxDepth = 8;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

            services.AddControllers().AddNewtonsoftJson(
                x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.MaxDepth = 2;
                });

            services.AddSwaggerGen(options =>
            {
                //options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                //    Description = "JWT Authorization header using the Bearer scheme."
                //});
                //options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                //{
                //    {
                //    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                //    {
                //        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                //        {
                //            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                //            Id = "Bearer"
                //        }
                //    },
                //    new string[] {}
                //    }
                //});
                options.EnableAnnotations();
                options.DescribeAllParametersInCamelCase();
            });


            services.Configure<IISOptions>(options => options.AutomaticAuthentication = true);


            Initializer(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger(c => c.SerializeAsV2 = true);

            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet("/themes/3.x/theme-feeling-blue.css");
                //c.InjectStylesheet("/themes/3.x/theme-flattop.css");
                //c.InjectStylesheet("/themes/3.x/theme-monokai.css");
                //c.InjectStylesheet("/themes/3.x/theme-muted.css");
                //c.InjectStylesheet("/themes/3.x/theme-material.css");
                //c.InjectStylesheet("/themes/3.x/theme-newspaper.css");
                //c.InjectStylesheet("/themes/3.x/theme-outline.css");
                c.EnableTryItOutByDefault();

                c.DocumentTitle = "Jim Halpert";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jim Halpert v3");
                c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
                var aspnetcore_urls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? string.Empty;

                var match = Regex.Match(aspnetcore_urls, @"(http:\/\/)([a-zA-Z0-9&_\.*-]{0,100})(:)([0-9]{0,5})");

                if (match.Success)
                {
                    var swaggerBaseRoute = aspnetcore_urls.Substring(match.Length, aspnetcore_urls.Length - match.Length);

                    if (!swaggerBaseRoute.StartsWith("/"))
                        swaggerBaseRoute = $"/{swaggerBaseRoute}";

                    if (!swaggerBaseRoute.EndsWith("/"))
                        swaggerBaseRoute = $"{swaggerBaseRoute}/";

                }
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
