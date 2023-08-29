

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
}
