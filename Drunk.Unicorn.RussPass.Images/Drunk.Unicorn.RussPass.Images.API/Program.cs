using Autofac.Core;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using DelegateDecompiler;
using Microsoft.Extensions.DependencyInjection;
using Drunk.Unicorn.RussPass.Images.BI.Interfaces;
using Drunk.Unicorn.RussPass.Images.BI.Options;
using Drunk.Unicorn.RussPass.Images.BI.Services;
using Drunk.Unicorn.RussPass.Images.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Net.Security;
using Drunk.Unicorn.RussPass.Kafka;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ISearchClient, SerpClient>()
    .ConfigureHttpClient((serviceProvider, client) =>
    {
        var configuration = serviceProvider.GetRequiredService<IConfiguration>().GetSection("Search").Get<Config>();
        client.BaseAddress = new Uri(configuration.Url);
    })
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
    });
//   .AddTransientHttpErrorPolicy(policyBuilder => policyBuilder
//       .WaitAndRetryAsync(3, retryNumber => TimeSpan.FromMilliseconds(600)));


builder.Services.AddScoped<ISearch, Search>();
builder.Services.AddSingleton<Keys>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ServiceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddAutoMapper((serviceProvider, automapper) =>
{
    automapper.AddCollectionMappers();
    automapper.UseEntityFrameworkCoreModel<ServiceDbContext>(serviceProvider);
}, typeof(ServiceDbContext).Assembly);


builder.Services.AddSwaggerGen(c =>
            c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer()
            {
                Url = builder.Configuration.GetValue<string>("SwaggerUrl")
            }));

builder.Services.AddHostedService<KafkaWorker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); временно закомментировал

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();