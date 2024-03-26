
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MovieReact.Server.Data;
using MovieReact.Server.Repositories;
using System.Globalization;

namespace MovieReact.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var conn = builder.Configuration.GetConnectionString(NamesConstants.LocalConnection);

            builder.Services.AddDbContext<MovieContext>(opt =>
            {
                opt.UseSqlServer(conn);
            });





            // Add services to the container.

            builder.Services.AddScoped<IMovieRepository, MovieRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
