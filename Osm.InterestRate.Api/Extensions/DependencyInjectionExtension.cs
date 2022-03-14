using Microsoft.Extensions.DependencyInjection;
using Osm.InterestRate.Data.Repositories;
using Osm.InterestRate.Domain.Interfaces;
using Osm.InterestRate.Domain.Models;
using Osm.InterestRate.Domain.Services;
using System.Diagnostics.CodeAnalysis;

namespace Osm.InterestRate.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IInterestRateService, InterestRateService>();
            services.AddScoped<IRepository<InterestRateModel>, InterestRateRepository>();

            return services;
        }
    }
}
