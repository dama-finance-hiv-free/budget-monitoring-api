using System;
using Autofac;
using Dama.Fin.API.Core;
using Dama.Fin.API.Middleware;
using Dama.Fin.API.Services;
using Dama.Fin.Application;
using Dama.Fin.Domain.Contracts.Service.Common;
using Dama.Fin.Infrastructure.Persistence;
using Dama.Fin.Infrastructure.Reporting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Dama.Fin.API;

public class Startup
{
    private const string AllowedCorsOrigins = "AllowedCorsOrigins";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        AddSwagger(services);

        services.AddControllersWithViews(config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            config.Filters.Add(new AuthorizeFilter(policy));
        });

        services.AddScoped<ILoggedInUserService, LoggedInUserService>();

        services.AddApplicationCoreServices();
        services.AddInfrastructureServices(Configuration);

        services
            .AddDatabaseContext(Configuration)
            .AddAuthorizationServer(Configuration)
            .AddCaching();

        var allowedOrigins = Configuration.GetValue<string>("AllowedOrigins")?.Split(",") ?? Array.Empty<string>();

        services.AddCors(options =>
        {
            options.AddPolicy(AllowedCorsOrigins,
                builder =>
                {
                    builder.WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Dama Finance API",
            });

            c.OperationFilter<FileResultContentTypeOperationFilter>();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        app.UseMiddleware<ExceptionMiddleware>();
        
        if (!env.IsDevelopment()) app.UseHsts();

        InitializeDatabase(app);

        app.UseRouting();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseCors(AllowedCorsOrigins);

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planner API");
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        var options = new DefaultFilesOptions();
        options.DefaultFileNames.Clear();
        options.DefaultFileNames.Add("startup.html");
        app.UseDefaultFiles(options);

        app.UseStaticFiles();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterApplicationDependencies();
    }

    private static void InitializeDatabase(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
         serviceScope?.ServiceProvider.GetRequiredService<MonitoringContext>().Database.Migrate();
    }
}