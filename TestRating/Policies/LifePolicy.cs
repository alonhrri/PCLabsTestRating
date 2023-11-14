
namespace TestRating
{
    public class LifePolicy : Policy
    {

        #region Properties
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
        #endregion

        #region Ctor
        public LifePolicy(PolicyType type, string fullName, DateTime dateOfBirth, bool isSmoker, decimal amount) : base(type, fullName, dateOfBirth)
        {
            IsSmoker = isSmoker;
            Amount = amount;
        }
        #endregion

        public override bool Validate(ILogger logger)
        {
            if (DateOfBirth == DateTime.MinValue)
            {
                logger.LogError("Life policy must include Date of Birth.");
                return false;
            }
            if (DateOfBirth < DateTime.Today.AddYears(-100))
            {
                logger.LogError("Max eligible age for coverage is 100 years.");
                return false;
            }
            if (Amount == 0)
            {
                logger.LogError("Life policy must include an Amount.");
                return false;
            }
            return true;
        }

        public override void RateCalculator()
        {

            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < DateOfBirth.Day ||
                DateTime.Today.Month < DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = Amount * age / 200;
            if (IsSmoker)
            {
                Rating = baseRate * 2;
                return;
            }
            Rating = baseRate;
        }
    
    }
}
