using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(IRatingContext context, ConsoleLogger logger)
            : base(context)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Unknown policy type");
        }
    }
}
