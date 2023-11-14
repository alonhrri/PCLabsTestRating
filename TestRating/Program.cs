using Microsoft.Extensions.Configuration;

namespace TestRating
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();

            try
            {
                var raterFactory = new RaterFactory(logger);
                var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
                var config = builder.Build();
                var policyHandler = new FileHandler<Policy>(config["FilePath"]);
                logger.LogInfo(LogMessages.SystemStart);

                var engine = new RatingEngine(logger, policyHandler, raterFactory);
                engine.Rate();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
