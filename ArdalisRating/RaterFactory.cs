using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RaterFactory
    {
        private readonly IRatingUpdater _ratingUpdater;
        private readonly ILogger _logger;
        public RaterFactory(ILogger logger)
        {
            _logger = logger;
        }
        public Rater Create(Policy policy)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                    new object[] { _logger }
                    );
            }
            catch
            {
                return new UnknownPolicyRater(_logger);
            }
        }
    }
}
