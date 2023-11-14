using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRating
{
    public static class LogMessages
    {
        public const string SystemStart = "Insurance Rating System Starting...";
        public const string RateStart = "Starting rate.";
        public const string LoadingPolicy = "Loading policy.";
        public const string ValidateStart = "Validating policy.";
        public const string UnknownRate = "Unknown policy type";
        public const string RateComplete = "Rating completed.";
        public const string RateTypeFormat = "Rating {0} policy...";
        public const string ErrorFormat = "{0}";
        public const string RateProduced = "Rating: {0}"; 
        public const string NoRateProduced = "No rating produced.";

    }
}
