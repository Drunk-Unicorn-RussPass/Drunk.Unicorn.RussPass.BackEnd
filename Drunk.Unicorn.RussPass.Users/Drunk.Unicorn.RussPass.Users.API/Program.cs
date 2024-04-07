using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Net.Security;
using Drunk.Unicorn.RussPass.Kafka;
using Drunk.Unicorn.RussPass.Users.BI.Interfaces;
using Drunk.Unicorn.RussPass.Users.BI.Services;
using Drunk.Unicorn.RussPass.Users.EF;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IFilesProvider, FilesProvider>();
builder.Services.AddScoped<IKafkaProvider, KafkaProvider>();
builder.Services.AddScoped<ICheck, Check>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ServiceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));

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

//app.UseExceptionHandler();

app.MapControllers();

app.Run();