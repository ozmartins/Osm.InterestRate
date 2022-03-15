using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Osm.InterestRate.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerExtension
    {       
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Interest rate API",
                    Description = "This simple API has only one endpoint that returns a fixed interest rate defined in the source code. " +
                                   "The value returned here is used by the FutureValueApi to calculate the future value of an amount of money. "+
                                   "Future versions of this API will recover the interest rate from a database.",                    
                    Contact = new OpenApiContact
                    {
                        Name = "Oséias da Silva Martins",
                        Url = new Uri("https://github.com/ozmartins"),
                        Email = "oseias.silva.martins@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCustomSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Osm.InterestRate.Api v1"));

            var option = new RewriteOptions();
            
            option.AddRedirect("^$", "swagger");
            
            app.UseRewriter(option);

            return app;
        }
    }
}
