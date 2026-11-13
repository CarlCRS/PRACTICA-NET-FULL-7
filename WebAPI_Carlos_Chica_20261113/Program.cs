using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using WebAPI_Carlos_Chica_20261113.Repository;
using WebAPI_Carlos_Chica_20261113.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conexion = builder.Configuration.GetConnectionString("Base_Conexion");

builder.Services.AddScoped<IDbConnection>(co => new SqlConnection(conexion));

builder.Services.AddScoped<EventReposi>();
builder.Services.AddScoped<EventService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(op =>
{
    op.AddPolicy("PermitirAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapSwagger();
    app.UseSwaggerUI();

}
app.UseCors("PermitirAngular");



app.UseAuthorization();

app.MapControllers();

app.Run();
