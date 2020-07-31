using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, IRatingUpdater ratingUpdater)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                    new object[] { ratingUpdater}
                    );
            }
            catch
            {
                return new UnknownPolicyRater(ratingUpdater);
            }
        }
    }
}
