using PhotoManagementSystem.Application.Interfaces;
using PhotoManagementSystem.Application.Mapper;
using PhotoManagementSystem.Application.Services;
using PhotoManagementSystem.Infrastructure.Interfaces;
using PhotoManagementSystem.Infrastructure.Repositories;

namespace PhotoManagementSchedules_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddAutoMapper(typeof(UserProfile));

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IClinetService, ClientService>();

            builder.Services.AddAutoMapper(typeof(ClientProfile));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");


            app.MapControllers();

            app.Run();
        }
    }
}
