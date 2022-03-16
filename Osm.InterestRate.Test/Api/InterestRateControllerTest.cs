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
    public class InterestRateControllerTest
    {
        [TestMethod]
        public void InterestRateControllerTest_GettingValidInteresRate()
        {
            #region arrange
            var expectedInterestRate = new InterestRateModel() { Value = InterestRate.Domain.Constants.DefaultInterestRate };

            var interestRateServiceMock = new Mock<IInterestRateService>();
            interestRateServiceMock.Setup(p => p.GetInterestRate()).Returns(expectedInterestRate);

            var controller = new InterestRateController(interestRateServiceMock.Object);
            #endregion

            #region act
            var actionResult = controller.Get();            
            #endregion

            #region assert            
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));            

            Assert.IsNotNull(_convertToOkObjectResult(actionResult.Result).Value);
            Assert.IsInstanceOfType(_convertToOkObjectResult(actionResult.Result).Value, typeof(InterestRateModel));

            Assert.AreEqual(_getInterestRateModelFrom(actionResult.Result).Value, Constants.DefaultInterestRate);
            #endregion
        }

        [TestMethod]
        public void InterestRateControllerTest_GettingNullInteresRate()
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
            Assert.IsInstanceOfType(actionResult.Result, typeof(ObjectResult));
            Assert.AreEqual(_convertToStatusCodeResult(actionResult.Result).StatusCode, 500);

            Assert.IsNotNull(_convertToStatusCodeResult(actionResult.Result).Value);
            Assert.IsTrue(_convertToStatusCodeResult(actionResult.Result).Value is string);
            
            Assert.AreEqual(_convertToStatusCodeResult(actionResult.Result).Value, expectedErrorMessage);
            #endregion
        }

        [TestMethod]
        public void InterestRateControllerTest_ExceptionWhenGettingInteresRate()
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
            Assert.IsInstanceOfType(actionResult.Result, typeof(ObjectResult));
            Assert.AreEqual(_convertToStatusCodeResult(actionResult.Result).StatusCode, 500);

            Assert.IsNotNull(_convertToStatusCodeResult(actionResult.Result).Value);
            Assert.IsTrue(_convertToStatusCodeResult(actionResult.Result).Value is string);

            Assert.AreEqual(_convertToStatusCodeResult(actionResult.Result).Value, expectedErrorMessage);
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
