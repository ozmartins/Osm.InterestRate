using Microsoft.VisualStudio.TestTools.UnitTesting;
using Osm.InterestRate.Data.Repositories;
using Osm.InterestRate.Domain;
using Osm.InterestRate.Domain.Models;

namespace Osm.InterestRate.Test.Data
{
    [TestClass]
    public class InterestRateRepositoryTest
    {
        [TestMethod]
        public void InterestRateRepositoryTest_RecoveringValidInterestRate()
        {
            #region arange
            var expectedInterestRate = new InterestRateModel() { Value = Constants.DefaultInterestRate };           
            var repository = new InterestRateRepository();
            # endregion

            #region act
            var interestRate = repository.Recover();
            #endregion

            #region assert
            Assert.IsNotNull(interestRate);
            Assert.AreEqual(interestRate.Value, expectedInterestRate.Value);
            #endregion
        }
    }
}
