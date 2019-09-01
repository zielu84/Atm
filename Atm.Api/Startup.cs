using System;
using System.IO;
using System.Reflection;
using Atm.Api.Extensions;
using Atm.Data;
using Atm.Services.Services;
using Atm.Services.Services.Interfaces;
using Atmi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Atm.Api
{
    public class Startup
    {
        private readonly string CorsPolicy = "CorsPolicy";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IMoneyService, MoneyService>();
            services.AddSingleton<ILoggerManager, LoggerManager>();

            var connection = Configuration["ConnectionString"];
            services.AddDbContext<AtmDbContext>(options => options.UseSqlServer(connection));

            var origins = Configuration.GetSection("AllowedOrigins").Get<string[]>();
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(origins)
                );
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"v{Configuration["Version"]}",
                    new Info
                    {
                        Version = $"v{Configuration["Version"]}",
                        Title = "ATM Api",
                        Description = $"Assembly Version: {Assembly.GetExecutingAssembly().GetName().Version}"
                    });

                //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    var dbContext = serviceScope.ServiceProvider.GetService<AtmDbContext>();
                    dbContext.Database.Migrate();
                    DatabaseInitializer.Seed(dbContext);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            app.UseCors(CorsPolicy);
            //app.ConfigureExceptionHandler(logger);
            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v{Configuration["Version"]}/swagger.json", $"ATM Api v{Configuration["Version"]}");
                c.DocExpansion(DocExpansion.None);
            });

            app.UseMvc();
        }
    }
}
