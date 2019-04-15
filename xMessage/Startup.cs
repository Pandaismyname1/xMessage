using System;
using Core.Repositories;
using Core.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

namespace xMessage
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
            services.AddDbContext<AppDbContext>();
            services.AddScoped<DbContext, AppDbContext>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAuthKeyRepository, AuthKeyRepository>();
            services.AddTransient<IContactLinkageRepository,ContactLinkageRepository>();

            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IContactLinkageService,ContactLinkageService>();

            services.AddMvc()
                .AddNewtonsoftJson();
            services.AddSwaggerDocument();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting(routes =>
            {
                routes.MapControllers();
            });
            app.UseSwagger().UseSwaggerUi3();

            app.UseAuthorization();
        }
    }
}
