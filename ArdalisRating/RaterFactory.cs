﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, IRatingContext context)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),
                    new object[] { context, context.Logger}
                    );
            }
            catch
            {
                return new UnknownPolicyRater(context, context.Logger);
            }
        }
    }
}
