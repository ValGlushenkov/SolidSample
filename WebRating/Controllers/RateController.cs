using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArdalisRating;

namespace WebRating.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private readonly RatingEngine _ratingEngine;
        private readonly StringPolicySource _policySource;

        public RateController(RatingEngine ratingEngine,
            StringPolicySource policySource)
        {
            _ratingEngine = ratingEngine;
            _policySource = policySource;
        }

        [HttpPost]
        public ActionResult<decimal> Rate([FromBody] string policy)
        {
            _policySource.PolicyString = policy;
            _ratingEngine.Rate();

            return _ratingEngine.Rating;
        }
    }
}
