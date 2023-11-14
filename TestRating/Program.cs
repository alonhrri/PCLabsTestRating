namespace TestRating
{
    class Program
    {
        static void Main(string[] args)
        {

            var logger = new Logger();
            var policyData = new PolicyData();

            logger.LogInfo(LogMessages.SystemStart);


            var engine = new RatingEngine(logger, policyData);
            engine.Rate();
        }
    }
}
