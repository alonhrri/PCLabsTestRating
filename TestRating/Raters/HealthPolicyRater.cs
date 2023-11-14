
namespace TestRating
{
    public class HealthPolicyRater : Rater
    {   
        #region Ctor
        public HealthPolicyRater(ILogger logger) : base(logger) { }
        #endregion

        public override decimal Rate(Policy policy)
        {
            if (String.IsNullOrEmpty(policy.Gender))
            {
                Logger.LogError("Health policy must specify Gender");
                return Rating;
            }
            if (policy.Gender == "Male")
            {
                if (policy.Deductible < 500)
                {
                    Rating = 1000m;
                }
                Rating = 900m;
            }
            else
            {
                if (policy.Deductible < 800)
                {
                    Rating = 1100m;
                }
                Rating = 1000m;
            }
            return Rating;

        } 
    }
}
