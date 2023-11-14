
namespace TestRating
{
    public class HealthPolicy : Policy
    {

        #region Properties
        public string Gender { get; set; }
        public decimal Deductible { get; set; }
        #endregion
       
        #region Ctor
        public HealthPolicy(PolicyType type, string fullName, DateTime dateOfBirth, string gender, decimal deductible) : base(type, fullName, dateOfBirth)
        {
            Gender = gender;
            Deductible = deductible;
        }
        #endregion

        public override bool Validate(ILogger logger)
        {
            if (String.IsNullOrEmpty(Gender))
            {
                logger.LogError("Health policy must specify Gender");
                return false;
            }
            return true;

        }

        public override void RateCalculator()
        {
            if (Gender == "Male")
            {
                if (Deductible < 500)
                {
                    Rating = 1000m;
                }
                Rating = 900m;
            }
            else
            {
                if (Deductible < 800)
                {
                    Rating = 1100m;
                }
                Rating = 1000m;
            }
        }
   
    }
}
