
namespace TestRating
{
    public class RaterFactory : IRaterFactory
    {
        private readonly ILogger _logger;

        public RaterFactory(ILogger logger)
        {
            _logger = logger;
        }
        public Rater? Create(Policy policy)
        {
            var className = $"TestRating.{policy.Type}PolicyRater";
            var type = Type.GetType(className);
            var obj = new object[] { _logger };
            try
            {
                return Activator.CreateInstance(type, obj) as Rater;
            }
            catch
            {
                return new UnknownPolicyRater(_logger);
            }

        }
    }
}
