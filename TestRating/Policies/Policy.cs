
namespace TestRating
{
    public abstract class Policy
    {

        #region Properties
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Rating { get; set; }
        #endregion
       
        #region Ctor
        public Policy(PolicyType type, string fullName, DateTime dateOfBirth)
        {
            Type = type;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
        }
        #endregion

        public abstract bool Validate(ILogger logger);

        public abstract void RateCalculator();


    }
}
