using FileCloudSolution.Interfaces;
using FileCloudSolution.Repositories;
using FileCloudSolution.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SystemFiles>();
builder.Services.AddScoped<ISystemFiles, SystemFiles>();
builder.Services.AddScoped<ISystemFileService, SystemFileService>();

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
