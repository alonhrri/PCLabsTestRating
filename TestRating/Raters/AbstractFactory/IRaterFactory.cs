namespace TestRating
{
    public interface IRaterFactory
    {
        public Rater Create(Policy policy);
    }
}