using DataAccess.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using NLog;
using Service.Extension;
using Service.Services.Abstractions;
using web.Extensions;
using Newtonsoft.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        builder.Services.LoadDataLayerExtension(builder.Configuration);
        builder.Services.LoadServiceExtension();
        builder.Services.AddAutoMapper(typeof(Program));
        LogManager.Setup().LoadConfigurationFromFile("Nlog.config").GetCurrentClassLogger();

        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        var app = builder.Build();

        var logger = app.Services.GetRequiredService<ILoggerService>();
        app.ConfigureExceptionHandler(logger);


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}