using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.DBoperitions;
using WebApi.MiddleWare;
using WebApi.Services;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
{
    opt.TokenValidationParameters = new TokenValidationParameters{
        ValidateAudience = true,
        ValidateIssuer =true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero,
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreDBContext>(options => {
    options.UseInMemoryDatabase(databaseName:"BookStoreDB");
    //options.UseSqlite("Data Source=./testtest.db");
});
builder.Services.AddScoped<IBookStoreDBContext,BookStoreDBContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILoggerService,DbLogger>();
//builder.Services.AddSingleton<ILoggerService,ConsoleLogger>();


var app = builder.Build();
using (var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomExceptionMiddlewareExtension();

app.MapControllers();

app.Run();
