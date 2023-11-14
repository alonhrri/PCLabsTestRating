
namespace TestRating
{
    public class LifePolicyRater : Rater
    {
        #region Ctor
        public LifePolicyRater(ILogger logger) : base(logger) { }

        #endregion

        public override decimal Rate(Policy policy)
        {
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                Logger.LogError("Life policy must include Date of Birth.");
                return Rating;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                Logger.LogError("Max eligible age for coverage is 100 years.");
                return Rating;
            }
            if (policy.Amount == 0)
            {
                Logger.LogError("Life policy must include an Amount.");
                return Rating;
            }

            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                return baseRate * 2;           
            }
            return baseRate;
        }
    }
}
