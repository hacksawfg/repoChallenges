using System.Collections.Generic;
using CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]

    // Where repo is tested
    public class MenuRepoTests
    {
        MenuItem _baseItem;
        MenuRepository _menu;

        [TestInitialize]
        public void Arrange()
        {
            string[] baseIngred = { "Item 1", "Item 2", "Item 3" };
            List<string> baseIngredList = new List<string>(baseIngred);
            _baseItem = new MenuItem(1, "Meal 1", "Description 1", baseIngredList, 1.23m, true);
            _menu = new MenuRepository();
            _menu.AddMenuItem(_baseItem);
        }

        // Add Menu Item Test
        [TestMethod]
        public void AddMenuItemTest_ShouldGetTrue()
        {
            // Arrange
            string[] testIngred = {"Expected 1", "Expected 2", "Expected 3"};
            List<string> testIngredList = new List<string>(testIngred);
            MenuItem testMenuItem = new MenuItem(5, "Test Meal", "Test Description", testIngredList, 2.99m, true);
            
            // Act
            bool result = _menu.AddMenuItem(testMenuItem);
            // Assert
            Assert.IsTrue(result);
        }

        // Get Cafe Menu test
        [TestMethod]
        public void GetCafeMenuTest_ShouldGetReturnCorrectList()
        {
            //Arrange
            MenuItem testing1 = new MenuItem();
            MenuItem testing2 = new MenuItem();
            MenuItem testing3 = new MenuItem();
            MenuRepository testRepo = new MenuRepository();
            
            testRepo.AddMenuItem(testing1);
            testRepo.AddMenuItem(testing2);
            testRepo.AddMenuItem(testing3);

            //Act
            List<MenuItem> result = testRepo.GetCafeMenu();

            //Assert
            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.Contains(testing3));


        }

        [TestMethod]
        // Delete Menu Item test
        public void DeleteMenuItemTest_ShouldRemoveItem()
        {
            bool result = _menu.DeleteMenuItem(_baseItem);
            Assert.IsTrue(result);

            List<MenuItem> resultList = _menu.GetCafeMenu();
            Assert.IsFalse(resultList.Contains(_baseItem));
        }
    }
}
