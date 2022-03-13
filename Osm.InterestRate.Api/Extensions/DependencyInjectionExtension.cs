using Microsoft.Extensions.DependencyInjection;
using Osm.InterestRate.Data.Repositories;
using Osm.InterestRate.Domain.Interfaces;
using Osm.InterestRate.Domain.Models;
using Osm.InterestRate.Domain.Services;

namespace Osm.InterestRate.Api.Extensions
{
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
