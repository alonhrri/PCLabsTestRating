namespace TestRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        #region Data Members
        private readonly ILogger _logger;
        private readonly FileHandler<Policy> _policyHandler;
        private IRaterFactory _raterFactory;
        #endregion

        #region Properties
        public decimal Rating { get; set; }
        #endregion

        #region Ctor
        public RatingEngine(ILogger logger, FileHandler<Policy> policyHandler, IRaterFactory raterFactory)
        {
            _logger = logger;
            _policyHandler = policyHandler;
            _raterFactory = raterFactory;
        }
        #endregion
        
        public void Rate()
        {
            _logger.LogInfo(LogMessages.RateStart);
            _logger.LogInfo(LogMessages.LoadingPolicy);

            Policy policy = _policyHandler.Fetch();

            if (policy is null)
            {
                _logger.LogError(LogMessages.UnknownPolicy);
                return;
            }
            else
            {
                _logger.Log(string.Format(LogMessages.RateTypeFormat, policy.Type));
                _logger.Log(LogMessages.ValidateStart);

                var rater = _raterFactory.Create(policy);
                Rating = rater.Rate(policy);
                if (Rating > 0)
                {
                    _logger.Log(LogMessages.RateComplete);
                    _logger.LogSuccess(string.Format(LogMessages.RateProduced, Rating));
                }
                else
                {
                    _logger.LogError(LogMessages.NoRateProduced);
                }
            }



        }
    }
}
