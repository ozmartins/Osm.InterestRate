using Osm.InterestRate.Domain.Interfaces;
using Osm.InterestRate.Domain.Models;

namespace Osm.InterestRate.Domain.Services
{
    public class InterestRateService : IInterestRateService
    {
        private readonly IRepository<InterestRateModel> _repository;

        public InterestRateService(IRepository<InterestRateModel> repository)
        {
            _repository = repository;
        }

        public InterestRateModel GetInterestRate()
        {
            return _repository.Recover();
        }
    }
}
