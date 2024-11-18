using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagement_System_API.Database;
using System.Text;
using System.Text.Json.Serialization;


namespace StudentManagement_System_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // builder.Services.AddControllers();
            builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
             });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StudentManagementContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("StudentDBConnection")));

            //var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]));

            //builder.Services.AddAuthentication()
            //    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        IssuerSigningKey = key,
            //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        ValidAudience = builder.Configuration["Jwt:Audience"],
            //    });

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(
                   name: "CORSPolicy",
                   builder =>
                   {
                       builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();

                   }
                   );
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("CORSPolicy");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
