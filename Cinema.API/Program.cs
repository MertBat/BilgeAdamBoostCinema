using Cinema.BLL.Mapper;
using Cinema.BLL.Services.Actors;
using Cinema.BLL.Services.Films;
using Cinema.Core.IRepository;
using Cinema.DAL.Context;
using Cinema.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cinema.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConString")));

            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            //Repositories
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient<IFilmRepository, FilmRepository>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<ICategoryFilmRepository, CategoryFilmRepository>();
            builder.Services.AddTransient<IActorFilmRepository, ActorFilmRepository>();
            builder.Services.AddTransient<IActorRepository, ActorRepository>();

            //Services
            builder.Services.AddTransient<IfilmService, FilmService>();
            builder.Services.AddTransient<IActorService, ActorService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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