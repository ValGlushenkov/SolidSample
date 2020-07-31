using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface IRatingUpdater
    {
        void UpdateRating(decimal rating);
    }
}
