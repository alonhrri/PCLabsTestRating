namespace TestRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger _logger;
        private readonly PolicyData _policyData;

        public RatingEngine(ILogger logger, PolicyData policyData)
        {
            _logger = logger;
            _policyData = policyData;

        }
        public void Rate()
        {
            _logger.LogInfo(LogMessages.RateStart);
            _logger.LogInfo(LogMessages.LoadingPolicy);
            
            List<Policy> policies = _policyData.Fetch();
            
            foreach (Policy policy in policies)
            {
                if (policy != null)
                {
                    _logger.Log(string.Format(LogMessages.RateTypeFormat, policy.Type));
                    _logger.Log(LogMessages.ValidateStart);

                    if (policy.Validate(_logger))
                    {
                        policy.RateCalculator();
                        _logger.Log(LogMessages.RateComplete);

                    }
                    _logger.LogSuccess(string.Format(LogMessages.RateProduced, policy.Rating));
                }
                else
                {
                    _logger.Log(LogMessages.UnknownRate);
                }
            }

        }
    }
}
