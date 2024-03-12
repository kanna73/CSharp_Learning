using Microsoft.Data.SqlClient;
using Workspace.Poc.Ado.DataAccess.Repository;
using Workspace.Poc.Ado.Domain.Interface.Repository;
using Workspace.Poc.Ado.Domain.Interface.Service;
using Workspace.Poc.Ado.Mapper.Mapper;
using Workspace.Poc.Ado.Service.Middleware;
using Workspace.Poc.Ado.Service.Services;

namespace Workspace.Poc.Ado.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenGenerator,TokenService>();
            builder.Services.AddScoped<ILocationRepo, LocationRepo>();
            builder.Services.AddScoped<ILocationService, LocationService>();
            builder.Services.AddScoped<IRoomRepo, RoomRepo>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IBookingRepo, BookingRepo>();
            builder.Services.AddScoped<IBookingService, BookingService>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<GlobalException>();





            builder.Services.AddSingleton<SqlConnection>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                return new SqlConnection(configuration.GetConnectionString("SqlConnection"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
            app.UseMiddleware<GlobalException>();


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
