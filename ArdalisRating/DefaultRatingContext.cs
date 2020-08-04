using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class DefaultRatingContext : IRatingContext
    {

        public RatingEngine Engine { get; set; }
        public List<string> LoggedMessages { get; }


        private readonly IPolicySource _policySource;

        public DefaultRatingContext(IPolicySource policySource)
        {
            _policySource = policySource;
        }
        public Rater CreateRaterForPolicy(Policy policy, ILogger logger)
        {
            return new RaterFactory(logger).Create(policy);
        }

        public Policy GetPolicyFromXmlString(string policyXml) 
            => throw new NotImplementedException();

        public string LoadPolicyFromFile()
        {
            return _policySource.GetPolicyFromSource();
        }

        public string LoadPolicyFromURI(string uri)
            => throw new NotImplementedException();

        public void Log(string message)
        {
            new ConsoleLogger().Log(message);
        }

        public void UpdateRating(decimal rating)
            => throw new NotImplementedException();
    }
}
