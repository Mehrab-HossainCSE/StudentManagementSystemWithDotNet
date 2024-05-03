
using Microsoft.EntityFrameworkCore;
using SMS.BAL.Service;
using SMS.Persistence.Contacts;
using SMS.Persistence.Data;
using SMS.Persistence.Repositories;
using SMS.BAL.Worker;

using Microsoft.EntityFrameworkCore;
using SMS.BAL.Mapper;
using SMS.BAL.Middleware;

using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SMS.Persistence.DependecnyResolverPerstence;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using SMS.BAL.DependecnyResolverBAL;


namespace StudentManagementSystem
{
    public class Program
    {

       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Jwt configuration starts here
            var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
            var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtIssuer,
                     ValidAudience = jwtIssuer,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                 };
             });
            //Jwt configuration ends here

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            // Add services to the container.



            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
 
             // Use in-memory database for development
            builder.Services.AddDbContext<InMemoryDataContext>();
            
  
            // Register the StudentMapper
            builder.Services.AddScoped<StudentMapper>();
            
            // Register other services
          
            var configuration = builder.Configuration;
            DependecnyResolverServicePersistence.Register(builder.Services, builder.Environment, configuration);
            DependecnyResolverServiceBAL.RegistionStudent(builder.Services, builder.Environment, configuration);
           
            builder.Services.AddHostedService<NotificationService>();

            builder.Services.AddCors();
            builder.Services.AddResponseCaching();
            var app = builder.Build();

            app.UseCors(option =>
            {
                option.WithOrigins("http://localhost:5028");
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.Logger.LogInformation("Using CORS");
            // app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();
            app.UseResponseCaching();
            app.MapControllers();
            app.Run();
        }
    }
}

