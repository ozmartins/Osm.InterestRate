using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Osm.InterestRate.Domain.Interfaces;
using Osm.InterestRate.Domain.Models;
using Osm.InterestRate.Domain.Services;
using Osm.InterestRate.Domain;

namespace Osm.InterestRate.Test.Domain
{
    [TestClass]
    public class InterestRateServiceTest
    {
        [TestMethod]
        public void InterestRateServiceTest_GettingValidInteresRate()
        {
            #region arrange
            var expectedInterestRate = new InterestRateModel() { Value = Constants.DefaultInterestRate };
            
            var interestRateRepositoryMock = new Mock<IRepository<InterestRateModel>>();
            interestRateRepositoryMock.Setup(p => p.Recover()).Returns(expectedInterestRate);
            
            var interestRateService = new InterestRateService(interestRateRepositoryMock.Object);
            #endregion

            #region act
            var interestRate = interestRateService.GetInterestRate();
            #endregion

            #region asssert
            Assert.IsNotNull(interestRate);
            Assert.AreEqual(interestRate.Value, expectedInterestRate.Value);
            #endregion 
        }
    }
}
