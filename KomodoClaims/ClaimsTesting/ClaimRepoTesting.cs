using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using ClaimsLibrary;


namespace ClaimsTesting
{
    [TestClass]
    public class ClaimsRepositoryTesting
    {
        private Claim _testClaim = new Claim();
        private ClaimsRepository _testClaims = new ClaimsRepository();

        [TestMethod]
        public void AddNewClaimTest_ShouldReturnTrue()
        {
            // Arrange
            DateTime testAccidentDate1 = DateTime.ParseExact("01/02/03", "MM/dd/yy", CultureInfo.InvariantCulture);
            DateTime testClaimDate1 = DateTime.ParseExact("01/06/03", "MM/dd/yy", CultureInfo.InvariantCulture);
            _testClaim = new Claim(1, ClaimType.Car, "Test Case 1", 123.45m, testAccidentDate1, testClaimDate1, true);
            bool result = _testClaims.AddNewClaim(_testClaim);

            // Act
            string expectedDescription = "Test Case 1";
            Claim testedClaim = _testClaims.GetClaimList().Peek();

            // Assert
            Assert.AreEqual(expectedDescription, testedClaim.ClaimDescription);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetClaimListTest_ShouldReturnAllClaims()
        {
            // Arrange
            Claim testClaim1 = new Claim();
            Claim testClaim2 = new Claim();
            Claim testClaim3 = new Claim();
            _testClaims.AddNewClaim(testClaim1);
            _testClaims.AddNewClaim(testClaim2);
            _testClaims.AddNewClaim(testClaim3);
            // Act
            int expectedCount = 3;
            int testGetListCount = _testClaims.GetClaimList().Count;
            // Assert
            Assert.AreEqual(expectedCount, testGetListCount);
        }

        [TestMethod]
        public void HandleClaimTest_ShouldShowClaimDequeued()
        {
            // Arrange
            Claim testClaim1 = new Claim();
            Claim testClaim2 = new Claim();
            Claim testClaim3 = new Claim();
            _testClaims.AddNewClaim(testClaim1);
            _testClaims.AddNewClaim(testClaim2);
            _testClaims.AddNewClaim(testClaim3);

            // Act
            _testClaims.DealWithClaim();
            // Assert
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, _testClaims.GetClaimList().Count);
            Assert.IsFalse(_testClaims.GetClaimList().Contains(testClaim1));
        }
    }
}
