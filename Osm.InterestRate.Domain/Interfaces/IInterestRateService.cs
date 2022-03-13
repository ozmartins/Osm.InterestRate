using Osm.InterestRate.Domain.Models;

namespace Osm.InterestRate.Domain.Interfaces
{
    public interface IInterestRateService
    {
        InterestRateModel GetInterestRate();
    }
}
