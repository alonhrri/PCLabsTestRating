namespace TestRating
{
    public abstract class Rater
    {

        #region Properties
        public ILogger Logger { get; set; }

        public decimal Rating { get; set; }
        #endregion

        #region Ctor
        public Rater(ILogger logger)
        {
            Logger = logger;
        }
        #endregion

        public abstract decimal Rate(Policy policy);



    }
}
