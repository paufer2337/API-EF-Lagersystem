using Microsoft.EntityFrameworkCore;
using StorageApi.Data;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<StorageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StorageContext")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "StorageApi v1");
            options.RoutePrefix = string.Empty;
        });
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();