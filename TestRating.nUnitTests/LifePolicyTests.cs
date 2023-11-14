using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRating.nUnitTests
{
    public class LifePolicyTests
    {
        private LifePolicy _policy { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            var fullName = "Alon";
            var dateOfBirth = DateTime.Parse("Apr 4, 1986");

            var type = PolicyType.Life;
            var IsSmoker = false;
            var Amount = 10000m;
            _policy = new LifePolicy(type, fullName, dateOfBirth, IsSmoker, Amount);
        }

        [Test]
        public void RateCalculator_Test()
        {

            // Act
            _policy.RateCalculator();

            // Assert
            Assert.AreEqual(1850m, _policy.Rating);
        }

    }
}
