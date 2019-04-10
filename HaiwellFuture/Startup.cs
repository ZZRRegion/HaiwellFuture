using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HaiwellFuture.Middlewares;

namespace HaiwellFuture
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("stdio", policy => {
                    policy.AllowAnyOrigin();
                });
            });
            services.AddScoped<Services.IServerTime, Services.ServerTimeBasket>();
            services.AddSingleton<Services.IRequestIPRecord, Services.RequestIpRecordServices>();
            services.AddSingleton<Services.IHMISearch, Services.HMISearchServices>();
            services.AddScoped<Services.IProjectScadaView, Services.ProjectScadaService>();
            services.AddMvc();
           
            services.AddDbContext<IdentityDbContext>(options => {
                options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("HaiwellFuture"));
            });
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<IdentityDbContext>();
            services.Configure<IdentityOptions>(config => {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 1;
                config.Password.RequiredUniqueChars = 1;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            ///允许跨域访问
            app.UseCors("stdio");
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules"))
            });
            app.UseRequestIP();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
