

namespace TestRating
{
    public class UnknownPolicyRater : Rater
    {
        #region Ctor
        public UnknownPolicyRater(ILogger logger) : base(logger) { }

        #endregion
        
        public override decimal Rate(Policy policy)
        {
            Logger.LogError(LogMessages.UnknownPolicy);

            return Rating;
        }
    }
}
