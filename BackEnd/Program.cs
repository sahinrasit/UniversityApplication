using BackEnd.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var databaseservice = builder.Services.AddDbContext<UniAppContext>(options => options.UseSqlServer("Data Source=.;Initial Catalog=UniversityApplication;Integrated Security=True"));
AppUtil.mydb = (UniAppContext)ServiceProviderServiceExtensions.GetRequiredService(databaseservice.BuildServiceProvider(), typeof(UniAppContext));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "localhost",
        ValidAudience = "localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hfýdhhrfghreugfy"))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["X-Access-Token"];
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Permission","Admin"));
    //options.AddPolicy("StudentOnly", policy => policy.RequireClaim("Permission","Student"));
    //options.AddPolicy("CheckerOnly", policy => policy.RequireClaim("Permission","Checker"));
    //options.AddPolicy("DeciderOnly", policy => policy.RequireClaim("Permission","Decider"));

    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("StudentOnly", policy => policy.RequireClaim("Student"));
    options.AddPolicy("CheckerOnly", policy => policy.RequireClaim("Checker"));
    options.AddPolicy("DeciderOnly", policy => policy.RequireClaim("Decider"));
});
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllHeaders", builder =>
//    {
//        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//});

//builder.Services.AddCors(options =>
//     options.AddDefaultPolicy(builder =>
//     builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
var app = builder.Build();
app.UseCors(builder =>
      builder.WithOrigins("https://localhost:7197")
         .AllowAnyHeader().AllowAnyMethod().AllowCredentials()
  );
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
