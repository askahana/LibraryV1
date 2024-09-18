
using LibraryAPI.Data;
using LibraryAPI.EndPoints;
using LibraryAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace LibraryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

            builder.Services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            builder.Services.AddAutoMapper(typeof(MappingConfig));
            builder.Services.AddCors((setup) =>
            setup.AddPolicy("default", (options) =>
            {
                options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            }));

			// When you use controller API.
			//builder.Services.AddControllers().AddJsonOptions(options =>
			//{
			//    options.JsonSerializerOptions.Converters
			//    .Add(new JsonStringEnumConverter());
			//});
            // Added this so that string-enum will be shown instead of number.
			builder.Services.ConfigureHttpJsonOptions(options =>
			{
				options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
			});

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("default");

            app.ConfigurationLibraryEndpoints();

            app.Run();
        }
    }
}
