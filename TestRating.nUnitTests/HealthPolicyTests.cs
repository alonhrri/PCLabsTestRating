using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRating.nUnitTests
{
    public class HealthPolicyTests
    {
        private HealthPolicy _policy { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            var fullName = "Alon";
            var dateOfBirth = DateTime.Parse("Apr 4, 1986");
            
            var type = PolicyType.Health;
            var deductible = 400;
            var gender = "Male";
            _policy = new HealthPolicy(type, fullName, dateOfBirth, gender, deductible);
        }

        [Test]
        public void RateCalculator_Test()
        {

            // Act
            _policy.RateCalculator();

            // Assert
            Assert.AreEqual(900m, _policy.Rating);  
        }
    }
}
