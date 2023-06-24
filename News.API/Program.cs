using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using News.BL;
using News.DAL;
using News.DAL.Repos;
using System.Security.Claims;
using System.Text;

namespace News.API
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Default

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #endregion

            #region Database

            builder.Services.AddDbContext<NewsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("NewsTaskDB")));
            #endregion

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "default";
                options.DefaultChallengeScheme = "default";
            })
            .AddJwtBearer("default", options =>
                {
                    string? keyString = builder.Configuration.GetValue<string>("SecretKey");
                    byte[] keyBytes = Encoding.ASCII.GetBytes(keyString!);
                    var key = new SymmetricSecurityKey(keyBytes);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            #endregion

            #region Repos

            builder.Services.AddScoped<INewsRepo, NewsRepo>();
            builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Managers

            builder.Services.AddScoped<INewsManager, NewsManager>();
            builder.Services.AddScoped<IAuthorManager, AuthorManager>();

            #endregion

            #region Auhtorization

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "admin");
                });
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}