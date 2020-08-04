using System;

namespace ArdalisRating
{

    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {

        private readonly ILogger _logger;
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly RaterFactory _factory;

        public IRatingContext Context { get; set; } 
        public IRatingUpdater RatingUpdater { get; set; } = new RatingUpdater();
        public decimal Rating { get; set; }
        public RatingEngine(ILogger logger,
            IPolicySource policySource,
            IPolicySerializer policySerializer,
            RaterFactory raterFactory
            )
        {
            _policySource = policySource;
            _policySerializer = policySerializer;
            _logger = logger;
            Context = new DefaultRatingContext(policySource);
            Context.Engine = this;
            _factory = raterFactory;
        }


        public void Rate()
        {
            _logger.Log("Starting rate.");

            _logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _policySource.GetPolicyFromSource();

            var policy = _policySerializer.GetPolicyFromJsonString(policyJson);


            var rater = _factory.Create(policy);
            rater.Rate(policy);

            Context.Log("Rating completed.");
        }
    }
}
