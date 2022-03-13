using Osm.InterestRate.Domain;
using Osm.InterestRate.Domain.Interfaces;
using Osm.InterestRate.Domain.Models;

namespace Osm.InterestRate.Data.Repositories
{
    public class InterestRateRepository : IRepository<InterestRateModel>
    {
        private InterestRateModel _defaultInteresRate;

        public InterestRateRepository()
        {
            _defaultInteresRate = new InterestRateModel() { Value = Constants.DefaultInterestRate };
        }

        public InterestRateModel Recover()
        {
            return _defaultInteresRate;
        }
    }
}
