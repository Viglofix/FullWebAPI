using Microsoft.EntityFrameworkCore;
using FullWebAPI.TransientData;
using FullWebAPI.SingletonData;
using FullWebAPI.ScopeData;
using Microsoft.AspNetCore.Mvc.Routing;
using DataBase.Services;
using DataBase.Container;
using AutoMapper;
using DataBase.Helper;
using DataBase;

namespace FullWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<MorenDatabaseDbContext>(obj =>
            obj.UseNpgsql(builder.Configuration.GetConnectionString("MorenDataBase")));

            builder.Services.AddCors(o => {
                o.AddPolicy(name: "MyCorsPolicy", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                });
            });

            builder.Services.AddTransient<IMorenService, MorenService>();

            var autoMapperConfiguration = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
            IMapper mapper = autoMapperConfiguration.CreateMapper();
            builder.Services.AddSingleton(mapper);

            // Test Section
            builder.Services.AddTransient<IMorenTempData, MorenTempDataLocations>();
            builder.Services.AddSingleton<ISingletonMorenTempData, SingletonMorenTempData>();
            builder.Services.AddSingleton<IScopeMorenTempData, ScopeMorenTempData>();

            var app = builder.Build();
            app.UseCors("MyCorsPolicy");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }
            if (app.Environment.IsProduction())
            {

            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Moren}/{action=Index}/{id?}");

            app.Use(async (context, next) =>
            {
                var GetContext = context.RequestServices.GetService<IMorenTempData>();
                GetContext!.NameData = "Stefan";

                await next(context);
            });

            app.Use(async (context, next) =>
            {
                var GetContext = context.RequestServices.GetService<ISingletonMorenTempData>();
                GetContext!.Name = "Stefan";

                await next(context);
            });

            app.Use(async (context, next) =>
            {
                var GetContext = context.RequestServices.GetService<IScopeMorenTempData>();
                GetContext!.Name = "Stefan";

                await next(context);
            });

            app.Use(async (context, _next) =>
            {
                var GetContext = context.RequestServices.GetService<IScopeMorenTempData>();
                GetContext!.Name = "ScopedChangedByRequest";

                await _next(context);
            });

            app.Run();
        }
    }
}