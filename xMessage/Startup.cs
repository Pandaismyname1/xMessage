using System;
using Core.Repositories;
using Core.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Services;
using Swashbuckle.AspNetCore.Swagger;

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

            services.AddMvc();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "xMessage", Version = "v1" }); });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "xMessage V1"); });

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
