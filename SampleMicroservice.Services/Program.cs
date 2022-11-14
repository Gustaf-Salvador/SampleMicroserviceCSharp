using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SampleMicroservice.Application.RequestEvent;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Domain.Repositories;
using SampleMicroservice.Repository.Mapper;
using SampleMicroservice.Repository.Repositories;

namespace SampleMicroservice.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            ConfigureServices(builder.Services);
            RegisterDomains(builder.Services);
            RegisterRepositories(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IAddressRepository, AddressRepository>();
        }

        private static void RegisterDomains(IServiceCollection services)
        {
            services.AddTransient<Customer>();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddMediatR(new Type[] { typeof(Program), typeof(CreateCustomerRequestEvent) });
            services.AddAutoMapper(new Type[] { typeof(Program), typeof(CustomerDsoMapper) });
        }

    }
}