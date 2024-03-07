using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;
using static JimHalpert.Ioc.Bootstraper;

namespace JimHalpert.Web
{
    public class Startup
    {
        public IWebHostEnvironment Env { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();
            var sessionTimeInSeconds = Convert.ToInt32(Configuration.GetSection("SessionTimeInMinutes").Value) * 60;

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(sessionTimeInSeconds);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

            if (Env.IsDevelopment())
            {
                services.AddControllersWithViews().AddRazorRuntimeCompilation();
            }

            services.AddAuthentication(optionsAuth =>
            {

                optionsAuth.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                optionsAuth.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                optionsAuth.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                                                options =>
                                                {
                                                    options.Cookie.HttpOnly = true; // Um sinalizador que diz que o cookie est� dispon�vel apenas para servidores. O navegador envia apenas o cookie, mas n�o pode acess�-lo atrav�s do JavaScript
                                                    options.LoginPath = "/Acesso/";
                                                    //options.AccessDeniedPath = "/Account/Login";
                                                });

            services.AddMvc().AddRazorPagesOptions(options => options.Conventions.AddAreaPageRoute("Home", "/Index", ""));

            services.AddMvc(config =>
            {

                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            //services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            //services.AddTransient<IMailService, MailService>();
            //services.AddTransient<IMailSenderService, MailSenderService>();

            //ioc
            Initializer(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseCookiePolicy();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }

    }
}

// Path: JimHalpert.Web/Program.cs