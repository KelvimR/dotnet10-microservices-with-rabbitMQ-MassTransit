using AirlineBookingSystem.Payments.Application.Handlers;
using AirlineBookingSystem.Payments.Core.Repositories;
using AirlineBookingSystem.Payments_.Infrastructure.Repositories;
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