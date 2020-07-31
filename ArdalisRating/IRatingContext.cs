using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface IRatingContext : ILogger
    {
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        Policy GetPolicyFromJsonString(string policyJson);
        Policy GetPolicyFromXmlString(string policyXml);
        Rater CreateRaterForPolicy(Policy policy, IRatingUpdater ratingUpdater);
        RatingEngine Engine { get; set; }
    }
}
