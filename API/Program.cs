/*"ConnectionStrings": {
    "DefaultConnection":"server=localhost;user=root;password= ;database =AutoRepairDBmb"
  }*/ //Casita

/*"ConnectionStrings": {
    "DefaultConnection":"server=localhost;user=root;password=123456 ;database =AutoRepairDBmb"
  }
*/ //campus

using System.Reflection;
using API.Extension;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
//Configuracion cors
builder.Services.ConfigureCors();
//Configuración del servicio de AutoMapper
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
// Add services to the container.
builder.Services.AddAplicacionServices();//-----------------

builder.Services.AddControllers();
builder.Services.AddDbContext<AutoRepairContext>(optionsBuilder =>
{
    string  connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
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

app.UseCors("CorsPolicy");

//Se agregan las siguientes lineas de code (migracion)
using(var scope= app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try{
    var context = services.GetRequiredService<AutoRepairContext>();
    await context.Database.MigrateAsync();
    }
    catch(Exception ex){
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex,"Ocurrió un error durante la migración");
    }
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
