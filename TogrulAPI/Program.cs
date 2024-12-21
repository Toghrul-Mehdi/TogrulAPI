using Microsoft.EntityFrameworkCore;
using TogrulAPI.DAL;
using TogrulAPI.Services.BannedWord.Abstracts;
using TogrulAPI.Services.BannedWord.Implements;
using TogrulAPI.Services.Language.Abstracts;
using TogrulAPI.Services.Language.Implements;
using TogrulAPI.Services.Word.Abstracts;
using TogrulAPI.Services.Word.Implements;

namespace TogrulAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<TogrulDB>(s => s.UseSqlServer(builder.Configuration.GetConnectionString("Mssql")));
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<IWordService, WordService>();
            builder.Services.AddScoped<IBannedWordService, BannedWordService>();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
