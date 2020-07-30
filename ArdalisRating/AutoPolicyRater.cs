using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {

        public AutoPolicyRater(IRatingContext context, ConsoleLogger logger)
            :base(context)
        {
        }

        public override void Rate(Policy policy)
        {
            _context.Log("Rating AUTO policy...");
            _context.Log("Validating policy.");
            if(string.IsNullOrEmpty(policy.Make))
            {
                _context.Log("Auto policy must specify Make");
                return;
            }
            if(policy.Make == "BMW")
            {
                if(policy.Deductible < 500)
                {
                    _context.Rating = 1000m;
                }
                _context.Rating = 900m;
            }
        }
    }
}
