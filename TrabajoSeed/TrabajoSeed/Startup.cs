using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using TrabajoSeed.AuthorizationRequirements;
using TrabajoSeed.Models;
using TrabajoSeed.Repository;
using TrabajoSeed.Services;

namespace TrabajoSeed
{
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
            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", config => {
                    config.Cookie.Name = "Seed.Cookie";
                    config.LoginPath = "/InicioSesion/Index";
                });

            services.AddAuthorization(config => 
            {
                //var defaultAuthBuilder = new AuthorizationPolicyBuilder();
                //var defaultAuthPolicy = defaultAuthBuilder
                //.RequireAuthenticatedUser()
                //.RequireClaim(ClaimTypes.Role)
                //.Build();

                //config.DefaultPolicy = defaultAuthPolicy;
                //config.AddPolicy("Claim.Role", policyBuilder => 
                //{
                //    policyBuilder.RequireClaim(ClaimTypes.Role);
                //});
                config.AddPolicy("Claim.Email", policyBuilder =>
                {
                    policyBuilder.RequireCustomClaim(ClaimTypes.Email);
                });
            });

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images")));
            services.AddDbContext<GrupoSeedContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connectionstr")));
            services.AddControllersWithViews();
            services.AddScoped<IAuthorizationHandler, CustomRequireHandler>();
            services.AddTransient<IUserInfo, UserInfoRepository>();
            services.AddTransient<IFileService, FileServiceRepository>();
            services.AddTransient<ILogin, LoginRepository>();
            services.AddTransient<IProgramaPresupuestario, ProgramaPresupuestarioRepository>();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //quien eres?
            app.UseAuthentication();

            //estas permitido?
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
