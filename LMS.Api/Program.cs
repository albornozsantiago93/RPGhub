
using LMS.Application;
using LMS.Application.Logic;
using LMS.Common;
using LMS.Common.Logic;
using LMS.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace LMS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SqlContext>();
            builder.Services.AddScoped<ISqlContext, SqlContext>();
            builder.Services.AddScoped<IStuffLogic, StuffLogic>();
            builder.Services.AddScoped<ILogicProxy, LogicProxy>();
            builder.Services.AddHttpContextAccessor();


            // Add services to the container.
            builder.Services.AddControllers();
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
