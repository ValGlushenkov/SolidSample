﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating.Tests
{
    internal class FakeRatingUpdater : IRatingUpdater
    {
        public decimal? NewRating { get; private set; }
        public void UpdateRating(decimal rating)
        {
            NewRating = rating;
        }
    }
}
