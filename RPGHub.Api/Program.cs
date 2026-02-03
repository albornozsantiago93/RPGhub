
using RPGHub.Application;
using RPGHub.Application.Logic;
using RPGHub.Common;
using RPGHub.Common.Config;
using RPGHub.Common.Logic;
using RPGHub.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;


namespace RPGHub.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ApiConfiguration.SetConfig(builder.Configuration);
            string connStr = ApiConfiguration.GetConnectionStringConfiguration("Conn");

            builder.Services.AddDbContext<SqlContext>(options => options.EnableSensitiveDataLogging().UseSqlServer(connStr).UseLazyLoadingProxies());

            var redisConnection = builder.Configuration.GetConnectionString("RedisConnection");
            var multiplexer = ConnectionMultiplexer.Connect(redisConnection);
            CacheManager.Init(multiplexer);

            // Add Security
            var key = Encoding.ASCII.GetBytes(ApiConfiguration.GetConfig("Tokens:Key"));
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });



            builder.Services.AddScoped<ISqlContext, SqlContext>();
            builder.Services.AddScoped<IStuffLogic, StuffLogic>();
            builder.Services.AddScoped<ILogicProxy, LogicProxy>();
            builder.Services.AddHttpContextAccessor();


            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "RPGHub API", Version = "v1" });

                // Configuración para JWT
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
    }
}
