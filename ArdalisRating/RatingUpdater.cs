using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RatingUpdater : IRatingUpdater
    {
        public decimal? Rating { get; set; }
        public void UpdateRating(decimal rating)
        {
            Rating = rating;
        }
    }
}
