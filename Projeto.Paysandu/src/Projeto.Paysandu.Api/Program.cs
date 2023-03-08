using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Projeto.Paysandu.Application.Interfaces;
using Projeto.Paysandu.Application.Services;
using Projeto.Paysandu.Infrastructure.Database;
using System;
using Projeto.Paysandu.Domain.Interfaces.Repositories;
using Projeto.Paysandu.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("NpgConnectionString")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ENABLE CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("", configurePolicy => configurePolicy.AllowAnyOrigin()
        .AllowAnyMethod().AllowAnyHeader().WithExposedHeaders(HeaderNames.ContentRange));

    //options.AddPolicy("ReactAdmin", builder => builder.AllowAnyOrigin()
    //    .AllowAnyMethod().WithExposedHeaders("Content-Range"," funcionarios 0-5/10"));
});

//JSON SERIALIZER
builder.Services.AddControllers().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});