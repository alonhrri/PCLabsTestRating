
namespace TestRating
{
    public class TravelPolicy: Policy
    {

        #region Properties
        public string Country { get; set; }
        public int Days { get; set; }
        #endregion
        
        #region Ctor
        public TravelPolicy(PolicyType type, string fullName, DateTime dateOfBirth, string country, int days) : base(type, fullName, dateOfBirth)
        {
            this.Country = country;
            this.Days = days;
        }
        #endregion

        public override bool Validate(ILogger logger)
        {
            if (Days <= 0)
            {
                logger.LogError("Travel policy must specify Days.");
                return false;
            }
            if (Days > 180)
            {
                logger.LogError("Travel policy cannot be more then 180 Days.");
                return false;
            }
            if (String.IsNullOrEmpty(Country))
            {
                logger.LogError("Travel policy must specify country.");
                return false;
            }
            return true;
        }

        public override void RateCalculator()
        {
            Rating = Days * 2.5m;
            if (Country == "Italy")
            {
                Rating *= 3;
            }
        }
  
    }
}
