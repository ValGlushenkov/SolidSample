using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        private RatingEngine _engine;
        private ILogger _logger;
        private FakePolicySource _policySource;//IPolicySource does not have PolicyString property
        private readonly IPolicySerializer _policySerializer;
        private readonly RaterFactory _raterFactory;
        public RatingEngineRate()
        {
            _logger = new FakeLogger();
            _policySource = new FakePolicySource();
            _policySerializer = new PolicySerializer();
            _raterFactory = new RaterFactory(_logger);
            _engine = new RatingEngine(_logger, _policySource, _policySerializer, _raterFactory);
        }
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            var engine = _engine;
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            var engine = _engine;
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnDefaultPolicyFromEmptyJsonString()
        {
            var inputJson = "{}";
            var serializer = new PolicySerializer();

            var result = serializer.GetPolicyFromJsonString(inputJson);

            var policy = new Policy();
            //May not work. I have not tested if it can compare objects
            Assert.Equal(result, policy);
        }

        [Fact]
        public void LogsStartingLoadingAndCompleting()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200_000, 
                Valuation = 260_000
            };
            string json = JsonConvert.SerializeObject(policy);
            _policySource.PolicyString = json;

            _engine.Rate();
            var result = _engine.Rating;

            Assert.Contains(_logger.LoggedMessages, m => m == "Starting rate.");
            Assert.Contains(_logger.LoggedMessages, m => m == "Loading policy.");
            Assert.Contains(_logger.LoggedMessages, m => m == "Rating completed.");
        }
    }
}
