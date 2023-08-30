

using Core.Interfaces;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;

namespace API.Extension;

public static class AplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()  //Withorigin ("https://domini.com")
                .AllowAnyMethod()          //WithMethods ("GET", "POST")
                .AllowAnyHeader()); 
        });   

    //Implementación de UniteOfService   

    public static void AddAplicacionServices(this IServiceCollection services)
        {
            //services.AddScoped<IPais, PaisRepository>();
            //services.AddScoped<ICustomer, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }    
}
