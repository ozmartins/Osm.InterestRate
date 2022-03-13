using Microsoft.AspNetCore.Mvc;
using Osm.InterestRate.Domain.Interfaces;
using System;

namespace Osm.InterestRate.Api.Controllers
{
    [ApiController]
    [Route("TaxaJuros")]
    public class InterestRateController : ControllerBase
    {
        private readonly IInterestRateService _interestRateService;

        public InterestRateController(IInterestRateService interestRateService)
        {
            _interestRateService = interestRateService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult Get()
        {
            try
            {
                var interestRate = _interestRateService.GetInterestRate();

                if (interestRate == null)
                {
                    return StatusCode(500, "Something went wrong. The system couldn't find the interest rate. Please, contact tech support or try again later.");
                }

                return Ok(interestRate);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}
