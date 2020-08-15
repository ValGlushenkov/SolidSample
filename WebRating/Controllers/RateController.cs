using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArdalisRating;
using Newtonsoft;
using Newtonsoft.Json;

namespace WebRating.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        private readonly RatingEngine _ratingEngine;
        private readonly StringPolicySource _policySource;

        public RateController(RatingEngine ratingEngine,
            StringPolicySource policySource)
        {
            _ratingEngine = ratingEngine;
            _policySource = policySource;
        }

        [HttpPost]
        public ActionResult<decimal> Rate([FromBody] Policy policy)
        {

            
            _ratingEngine.Rate(policy);

            return _ratingEngine.Rating;
        }
    }
}
