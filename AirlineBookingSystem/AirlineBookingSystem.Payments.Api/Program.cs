using AirlineBookingSystem.BuildingBlocks.Common;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Payments.Application.Consumers;
using AirlineBookingSystem.Payments.Application.Handlers;
using AirlineBookingSystem.Payments.Core.Repositories;
using AirlineBookingSystem.Payments_.Infrastructure.Repositories;
using MassTransit;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

        //MassTransit
        builder.Services.AddMassTransit(config =>
        {
            //Mark this as consumer
            config.AddConsumer<FlightBookedConsumer>();

            config.UsingRabbitMq((ct, cfg) =>
            {
                //cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
                cfg.Host(builder.Configuration["EventBusSettings:Host"], "/", h =>
                {
                    h.Username(builder.Configuration["EventBusSettings:Username"]);
                    h.Password(builder.Configuration["EventBusSettings:Password"]);
                });

                cfg.ReceiveEndpoint(EventBusConstant.FlightBookedQueue, c =>
                {
                    c.ConfigureConsumer<FlightBookedConsumer>(ct);
                });

            });
        });

        //Register MediatR
        var assemblies = new Assembly[]
        {
            typeof(ProcessPaymentHandler).Assembly,
            typeof(RefundPaymentHandler).Assembly
        };
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

        //Add sql connection
        builder.Services.AddScoped<IDbConnection>(sp =>
            new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}