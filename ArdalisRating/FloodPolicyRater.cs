using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(IRatingUpdater ratingUpdater)
            : base(ratingUpdater)
        {
        }

        public override void Rate(Policy policy)
        {
            Logger.Log("Rating FLOOD plocy...");
            Logger.Log("Validating policy.");
            if(policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Flood plicy must specify Bond Amount and Valuation");
                return;
            }

            if(policy.ElevationAboveSeaLevelFleet <=0)
            {
                Logger.Log("Policy is not available for elevations at or below sea level");
                return;
            }

            if(policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log("Insufficient bond amount");
                return;
            }
            decimal multiple = 1.0m;

            if(policy.ElevationAboveSeaLevelFleet < 100)
            {
                multiple = 2.0m;
            }
            else if(policy.ElevationAboveSeaLevelFleet < 500)
            {
                multiple = 1.5m;
            }
            else if(policy.ElevationAboveSeaLevelFleet < 1000)
            {
                multiple = 1.1m;
            }
            _ratingUpdater.UpdateRating(policy.BondAmount * 0.05m * multiple);
        }
    }
}
