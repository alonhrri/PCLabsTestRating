namespace TestRating.nUnitTests
{
    public class TravelPolicyTests
    {
        private TravelPolicy _policy { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            var fullName = "Alon";
            var dateOfBirth = DateTime.Parse("Apr 4, 1986");
            var type = PolicyType.Travel;
            var days = 10;
            var country = "Italy";
            _policy = new TravelPolicy(type, fullName, dateOfBirth, country, days);
        }

        [Test]
        public void RateCalculator_Test()
        {

            // Act
            _policy.RateCalculator();

            // Assert
            Assert.AreEqual(75m, _policy.Rating); // Assuming Days * 2.5m * 3 as rate for Italy      
        }
    }
}