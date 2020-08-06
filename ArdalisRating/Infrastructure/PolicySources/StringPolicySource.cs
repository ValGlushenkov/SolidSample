using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class StringPolicySource : IPolicySource
    {
        public string PolicyString { private get; set; }
        private string _policyString = string.Empty;
        public string GetPolicyFromSource()
        {
            _policyString = PolicyString;
            return _policyString;
        }
    }
}
