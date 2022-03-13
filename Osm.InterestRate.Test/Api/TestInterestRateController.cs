using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Osm.InterestRate.Api.Controllers;
using Osm.InterestRate.Domain;
using Osm.InterestRate.Domain.Interfaces;
using Osm.InterestRate.Domain.Models;
using System;

namespace Osm.InterestRate.Test.Api
{
    [TestClass]
    public class TestInterestRateController
    {
        [TestMethod]
        public void GettingValidInteresRateFromController()
        {
            #region arrange
            var expectedInterestRate = new InterestRateModel() { Value = Constants.DefaultInterestRate };

            var interestRateServiceMock = new Mock<IInterestRateService>();
            interestRateServiceMock.Setup(p => p.GetInterestRate()).Returns(expectedInterestRate);

            var controller = new InterestRateController(interestRateServiceMock.Object);
            #endregion

            #region act
            var actionResult = controller.Get();            
            #endregion

            #region assert            
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));            

            Assert.IsNotNull(_convertToOkObjectResult(actionResult).Value);
            Assert.IsInstanceOfType(_convertToOkObjectResult(actionResult).Value, typeof(InterestRateModel));

            Assert.AreEqual(_getInterestRateModelFrom(actionResult).Value, Constants.DefaultInterestRate);
            #endregion
        }

        [TestMethod]
        public void GettingNullInteresRateFromController()
        {
            #region arrange           
            var expectedErrorMessage = "Something went wrong. The system couldn't find the interest rate. Please, contact tech support or try again later.";

            var interestRateServiceMock = new Mock<IInterestRateService>();            

            var controller = new InterestRateController(interestRateServiceMock.Object);
            #endregion

            #region act
            var actionResult = controller.Get();
            #endregion

            #region assert            
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(ObjectResult));
            Assert.AreEqual(_convertToStatusCodeResult(actionResult).StatusCode, 500);

            Assert.IsNotNull(_convertToStatusCodeResult(actionResult).Value);
            Assert.IsTrue(_convertToStatusCodeResult(actionResult).Value is string);

            Assert.AreEqual(_convertToStatusCodeResult(actionResult).Value, expectedErrorMessage);
            #endregion
        }

        [TestMethod]
        public void ExceptionWhenGettingInteresRateFromController()
        {
            #region arrange           
            var expectedErrorMessage = "Error message thown during unit test.";

            var interestRateServiceMock = new Mock<IInterestRateService>();
            interestRateServiceMock.Setup(p => p.GetInterestRate()).Throws(new Exception(expectedErrorMessage));

            var controller = new InterestRateController(interestRateServiceMock.Object);
            #endregion

            #region act
            var actionResult = controller.Get();
            #endregion

            #region assert            
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(ObjectResult));
            Assert.AreEqual(_convertToStatusCodeResult(actionResult).StatusCode, 500);

            Assert.IsNotNull(_convertToStatusCodeResult(actionResult).Value);
            Assert.IsTrue(_convertToStatusCodeResult(actionResult).Value is string);

            Assert.AreEqual(_convertToStatusCodeResult(actionResult).Value, expectedErrorMessage);
            #endregion
        }

        private OkObjectResult _convertToOkObjectResult(ActionResult actionResult)
        {
            return (OkObjectResult)actionResult;
        }

        private ObjectResult _convertToStatusCodeResult(ActionResult actionResult)
        {
            return (ObjectResult)actionResult;
        }

        private InterestRateModel _getInterestRateModelFrom(ActionResult actionResult)
        {
            var okObjectResult = _convertToOkObjectResult(actionResult);

            return (InterestRateModel)okObjectResult.Value;
        }
    }
}
