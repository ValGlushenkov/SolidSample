using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromJsonString(string json);
    }
}
