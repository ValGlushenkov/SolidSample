using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface IRatingContext : ILogger
    {
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        Policy GetPolicyFromXmlString(string policyXml);
        Rater CreateRaterForPolicy(Policy policy, ILogger logger);
        RatingEngine Engine { get; set; }
    }
}
