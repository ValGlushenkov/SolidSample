﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace ArdalisRating.Tests
{
    public class AutoPolicyRaterRate
    {
        [Fact]
        public void LogMakeRequiredMessageGivenPolicyWithoutMake()
        {
            var policy = new Policy { Type = PolicyType.Auto };
            var logger = new FakeLogger();//use Moq instead of dummy implementations
            var rater = new AutoPolicyRater(null);
            rater.Logger = logger;

            rater.Rate(policy);

            Assert.Equal("Auto policy must specify Make", logger.LoggedMessages.Last());
        }

        [Fact]
        public void SetRatingTo1000ForBMWWith250Deductible()
        {
            var policy = new Policy()
            {
                Type = PolicyType.Auto,
                Make = "BMW",
                Deductible = 250m
            };
            var ratingUpdater = new FakeRatingUpdater();
            var rater = new AutoPolicyRater(ratingUpdater);

            rater.Rate(policy);

            Assert.Equal(1000m, ratingUpdater.NewRating.Value);
        }
    }
}