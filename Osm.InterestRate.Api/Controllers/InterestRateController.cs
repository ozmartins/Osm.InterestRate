using Microsoft.AspNetCore.Mvc;
using Osm.InterestRate.Domain.Interfaces;
using Osm.InterestRate.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel;

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
        [SwaggerOperation(Summary = Constants.InterestRateGetSummary, Description = Constants.InterestRateGetDescription, Tags = new[] { Constants.InterestRateTag })]
        public ActionResult<InterestRateModel> Get()
        {
            try
            {
                var interestRate = _interestRateService.GetInterestRate();

                if (interestRate == null)
                {
                    return StatusCode(500, Constants.NullInterestRateMessage);
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
