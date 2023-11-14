using System.Diagnostics.Metrics;
using TestRating.Raters;

namespace TestRating.nUnitTests
{
    public class MockPolicyRaterTest
    {

        [Test]
        public void SetsRatingTo900ForHealthPolicyRaterWith600DeductibleAndMaleGender()
        {
            var policy = new Policy()
            {
                Type = PolicyType.Health,
                Gender = "Male",
                Deductible = 600
            };
            var logger = new Logger();
            var rater = new HealthPolicyRater(logger);
            // Act
            var result = rater.Rate(policy);
            // Assert
            Assert.AreEqual(900, result);
        }

        [Test]
        public void SetsRatingToExpectedForLifePolicyRaterWith1986DateOfBirthAndIsSmokerFalseAnd1000Amount()
        {
            var policy = new Policy()
            {
                Type = PolicyType.Life,
                DateOfBirth = new DateTime(1986, 4, 4),
                IsSmoker = false,
                Amount = 1000,
            };
            var logger = new Logger();
            var rater = new LifePolicyRater(logger);
            // Act
            var result = rater.Rate(policy);
            // Assert
            Assert.AreEqual(185, result);
        }

        [Test]
        public void SetsRatingTo75ForTravelPolicyRaterWith30DaysAndFranceCountry()
        {
            var policy = new Policy()
            {
                Type = PolicyType.Travel,
                Days = 30,
                Country = "France",
            };
            var logger = new Logger();
            var rater = new TravelPolicyRater(logger);
            // Act
            var result = rater.Rate(policy);
            // Assert
            Assert.AreEqual(75, result);
        }
    }
}
