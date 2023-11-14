
namespace TestRating
{
    public class TravelPolicyRater: Rater
    {       
        #region Ctor
        public TravelPolicyRater(ILogger logger) : base(logger) { }
        #endregion

        public override decimal Rate(Policy policy)
        {
            if (policy.Days <= 0)
            {
                Logger.LogError("Travel policy must specify Days.");
                return Rating;
            }
            if (policy.Days > 180)
            {
                Logger.LogError("Travel policy cannot be more then 180 Days.");
                return Rating;
            }
            if (String.IsNullOrEmpty(policy.Country))
            {
                Logger.LogError("Travel policy must specify country.");
                return Rating;
            }
            Rating = policy.Days * 2.5m;
            if (policy.Country == "Italy")
            {
                Rating *= 3;
            }
            return Rating;
        }
    }
}
