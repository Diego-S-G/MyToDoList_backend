
using Microsoft.EntityFrameworkCore;
using MyToDoList.Application.Interfaces;
using MyToDoList.Application.Services;
using MyToDoList.Domain.Interfaces;
using MyToDoList.Infrastructure.Datas;
using MyToDoList.Infrastructure.Repositories;

namespace MyToDoList.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MyToDoListDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
            builder.Services.AddScoped<ITarefaService, TarefaService>();

            builder.Services.AddScoped<ICorRepository, CorRepository>();
            builder.Services.AddScoped<ICorService, CorService>();

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
