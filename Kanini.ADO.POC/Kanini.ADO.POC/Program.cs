using DataLayer.Interface;
using Kanini.Poc.Ado.Constants.Constants;
using Kanini.Poc.Ado.DataAccess.Repostiory;
using Kanini.Poc.Ado.Domain.Interface.Constants;
using Kanini.Poc.Ado.Domain.Interface.MapperInterface;
using Kanini.Poc.Ado.Domain.Interface.RepostioryInterface;
using Kanini.Poc.Ado.Domain.Interface.ServiceInterface;
using Kanini.Poc.Ado.Domain.Interface.UspRepostiory;
using Kanini.Poc.Ado.Domain.Interface.UspService;
using Kanini.Poc.Ado.Service.Service;
using Kanini.Poc.Ado.Service.UspService;
using Kanini.Poc.Ado.UspDataAccess.Interface;
using Kanini.Poc.Ado.UspDataAccess.Repostiory;
using Mapper.Mapper;

namespace Kanini.ADO.POC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IServiceMapper, ServiceMapper>();
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IEmployeeUspService, EmployeeUspService>();
            builder.Services.AddScoped<IUspEmployeeRepo, UspEmployeeRepo>();
            builder.Services.AddSingleton<IUspConnection, UspConnection>();
            builder.Services.AddSingleton<IMessage, Messages>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
}
