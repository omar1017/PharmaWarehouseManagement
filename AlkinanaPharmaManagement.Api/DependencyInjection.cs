namespace AlkinanaPharmaManagement.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        //services.AddSwaggerGen(
        //        c =>
        //        {
        //            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //            {
        //                Description = @"Jwt Authorization Example : 'Bearer eyelieieek",
        //                Name = "Authorization",
        //                In = ParameterLocation.Header,
        //                Type = SecuritySchemeType.ApiKey,
        //                Scheme = "Bearer"
        //            });
        //            c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        //            {
        //                new OpenApiSecurityScheme
        //                {
        //                    Reference = new OpenApiReference
        //                    {
        //                        Type = ReferenceType.SecurityScheme,
        //                        Id = "Bearer"
        //                    },
        //                    Scheme = "outh2",
        //                    Name = "BEarer",
        //                    In = ParameterLocation.Header
        //                },
        //                new List<string>()
        //            }
        //            });
        //        });

        // services.AddExceptionHandler<GlobalExceptionHandler>();

        services.AddControllers();

        services.AddProblemDetails();


        return services;
    }
}
