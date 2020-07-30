using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class DefaultRatingContext : IRatingContext
    {
        public RatingEngine Engine { get; set; }
        public ConsoleLogger Logger => new ConsoleLogger();

        public decimal Rating { get; set; }

        public Rater CreateRaterForPolicy(Policy policy, IRatingContext context)
        {
            return new RaterFactory().Create(policy, context);
        }

        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return new PolicySerializer().GetPolicyFromJsonString(policyJson);
        }

        public Policy GetPolicyFromXmlString(string policyXml) 
            => throw new NotImplementedException();

        public string LoadPolicyFromFile()
        {
            return new FilePolicySource().GetPolicyFromSource();
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
