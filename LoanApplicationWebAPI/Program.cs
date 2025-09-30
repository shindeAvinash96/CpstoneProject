using LoanApplicationWebAPI.Data;
using LoanApplicationWebAPI.Helpers;
using LoanApplicationWebAPI.Repositories.Interfaces;
using LoanApplicationWebAPI.Repository;
using LoanApplicationWebAPI.Services;
using LoanApplicationWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace LoanApplicationWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoanAppConn")));


            //JWt helper
            builder.Services.AddScoped<JwtHelper>();


            // ---------- User ----------
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IUserService, UserService>();

            // ---------- Customer ----------
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            // ---------- Loan Officer ----------
            builder.Services.AddScoped<ILoanOfficerRepo, LoanOfficerRepo>();
            builder.Services.AddScoped<ILoanOfficerService, LoanOfficerService>();

            // ---------- Loan Scheme ----------
            builder.Services.AddScoped<ILoanSchemeRepo, LoanSchemeRepo>();
            builder.Services.AddScoped<ILoanSchemeService, LoanSchemeService>();

            // ---------- Loan Application ----------
            builder.Services.AddScoped<ILoanApplicationRepo, LoanApplicationRepo>();
            builder.Services.AddScoped<ILoanApplicationService, LoanApplicationService>();

            // ---------- Loan Approved ----------
            builder.Services.AddScoped<ILoanApprovedRepo, LoanApprovedRepo>();
            builder.Services.AddScoped<ILoanApprovedService, LoanApprovedService>();

            // ---------- Repayment ----------
            builder.Services.AddScoped<IRepaymentRepo, RepaymentRepo>();
            builder.Services.AddScoped<IRepaymentService, RepaymentService>();


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

            builder.Services.AddAuthorization();
            // Add services to the container.

            //builder.Services.AddControllers();//this enables all controllers
            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });



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
            app.UseAuthentication();


            app.MapControllers();

            app.Run();
        }
    }
}
