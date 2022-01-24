using Microsoft.VisualStudio.TestTools.UnitTesting;
using BadgeLibrary;
using System.Collections.Generic;
using System.Linq;

namespace BadgeTesting
{


    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _repo = new BadgeRepository();
        List<Doors> _forBadge1 = new List<Doors>();
        List<Doors> _forBadge2 = new List<Doors>();
        private Badges _badge1 = new Badges();
        private Badges _badge2 = new Badges();



        [TestInitialize]
        public void Arrange()
        {
            _badge1.BadgeID = 12345;
            _forBadge1.Add(Doors.A1);
            _forBadge1.Add(Doors.A2);
            _badge1.AccessPermission = _forBadge1;

            _badge2.BadgeID = 67890;
            _forBadge2.Add(Doors.B1);
            _forBadge2.Add(Doors.ServerRoom);
            _forBadge2.Add(Doors.A3);
            _badge2.AccessPermission = _forBadge2;

        }


        [TestMethod]
        public void AddNewBadge_ShouldReturnTrue()
        {
            // Arrange
            bool addBadgeTwo = _repo.AddNewBadge(_badge2);

            KeyValuePair<int, List<Doors>> testBadge = _repo.SelectOneBadge(_badge2.BadgeID);
            bool checkTwo = testBadge.Value.Contains(Doors.ServerRoom);

            Assert.IsTrue(addBadgeTwo);
            Assert.IsTrue(checkTwo);
        }

        [TestMethod]
        public void ReturnAllBadges_ShouldReturnAllBadges()
        {
            bool addone = _repo.AddNewBadge(_badge1);
            bool addtwo = _repo.AddNewBadge(_badge2);
            int testShouldBeTwoResults = _repo.ReturnAllBadges().Count;

            Assert.AreEqual(2, testShouldBeTwoResults);

        }

        [TestMethod]
        public void AddTheDoor_ShouldReturnTrue()
        {
            // Arrange
            bool checkOne = _repo.AddTheDoor(_badge1, 7);
            // bool checkTwo = _repo.RetrieveSingleBadge(_badge1.BadgeID).AccessPermission.Contains(Doors.ServerRoom);

            // Act

            // Assert
            Assert.IsTrue(checkOne);
            // Assert.IsTrue(checkTwo);
        }

        [TestMethod]
        public void RemoveSingleDoor_ShouldReturnTrue()
        {
            bool checkOne = _repo.RemoveSingleDoor(_badge2, 7);

            Assert.IsTrue(checkOne);
        }

        [TestMethod]
        public void RemoveAllDoors_ShouldReturnTrue()
        {
            bool result = _repo.RemoveAllDoors(_badge2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RetrieveSingleBadge_ShouldReturnBadge()
        {
            
            
            int testID = _badge1.BadgeID;
            Badges testCase = _repo.RetrieveSingleBadge(testID);

            bool testResult = _badge1.Equals(testCase);
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void SelectOneBadge_ShouldReturnTrue()
        {
            int testBadgeID = _badge1.BadgeID;
            KeyValuePair<int, List<Doors>> testCase =_repo.SelectOneBadge(testBadgeID);

            List<Doors> testList = testCase.Value;
            List<Doors> expectedValue = _forBadge1;

            bool testResult = expectedValue.Equals(testList);

            // try
            // {
            //     CollectionAssert.AreEquivalent(testList, expectedValue);
            //     result = true; 
            // }
            // catch (AssertFailedException)
            // {
            //     result = false;
            // }
            Assert.IsTrue(testResult);
        }
    }
}
