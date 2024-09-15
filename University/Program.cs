using Microsoft.EntityFrameworkCore;
using University.API.Commands;
using University.API.Database;
using University.API.Queries;

namespace University.API
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

            builder.Services.AddDbContext<UniversityContext>(options =>
            {
                options.UseInMemoryDatabase("UniversityDatabase"); // Configure to use InMemory database
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowAll",
                    policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                    });
            });

            builder.Services.AddScoped<ICourseCommands, CourseCommands>();
            builder.Services.AddScoped<ICourseQuery, CourseQuery>();
            builder.Services.AddScoped<IUserQueries, UserQueries>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyAllowAll"); // Add UseCors middleware

            app.MapControllers();

            app.Run();
        }
    }
}
