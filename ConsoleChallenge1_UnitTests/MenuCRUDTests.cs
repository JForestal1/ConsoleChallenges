using ConsoleChallenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ConsoleChallenge1_Tests_2
{
    [TestClass]
    public class MenuCRUDTests
    {
        MenuItemsRepo TestMenuRepo = new MenuItemsRepo();
        MenuItems menuTest = new MenuItems();
        List<Ingredients> _testIngredients = new List<Ingredients>();
        Ingredients testSingleIngredient = new Ingredients();
        List<MenuItems> _testWholeMenu = new List<MenuItems>();

        [TestInitialize]
        public void Arrange()
        {
            menuTest.MenuItem = 1;
            menuTest.MenuName = "Donut";
            menuTest.Price = 1.25;
            menuTest.Description = "Baked Wonderland with a hole in the middle";
            testSingleIngredient.Item = "Flour";
            testSingleIngredient.Quantity = 2;
            testSingleIngredient.Units = Ingredients.UnitTypes.cups;
            _testIngredients.Add(testSingleIngredient);
            menuTest._ListOfIngredients = _testIngredients;
        }

        [TestMethod]
        public void TestAddForTrue()
        {
            // arrange 
            // perfomred in TestInitalize

            // act
            bool result = TestMenuRepo.AddMenuItem(menuTest);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetForObject()
        {
            //Arrange
            MenuItems returnedMenuItem = new MenuItems();

            // act
            TestMenuRepo.AddMenuItem(menuTest);
            returnedMenuItem = TestMenuRepo.GetMenuItemByName("Donut");

            // assert
            Assert.IsNotNull(returnedMenuItem);
        }

        [TestMethod]
        public void TestRemove()
        {
            //Arrange
            //performed in Test Initialization

            // act
            TestMenuRepo.AddMenuItem(menuTest);
            bool result = TestMenuRepo.RemoveMenuItem("Donut");

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUpdateObject()
        {
            //Arrange
            MenuItems MenuTest2 = new MenuItems();
            MenuTest2.MenuItem = 2;
            MenuTest2.MenuName = "Waffle";
            MenuTest2.Price = 2.25;
            MenuTest2.Description = "This is an updated donut";
            TestMenuRepo.AddMenuItem(MenuTest2);

            // act
            TestMenuRepo.AddMenuItem(menuTest);
            bool result = TestMenuRepo.UpdateMenuItem("Donut", MenuTest2);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        public void TestUpdateIngredient()
        {
            // arrange
            Ingredients updatedIngredient = new Ingredients();
            updatedIngredient.Item = "Water";
            updatedIngredient.Quantity = 2;
            testSingleIngredient.Units = Ingredients.UnitTypes.tbsp;

            // act
            TestMenuRepo.AddMenuItem(menuTest);
            bool result = TestMenuRepo.UpdateMenuItemIngredients("Donut", "Flour", updatedIngredient);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetWholeMenu()
        {
            // Arrange
            List<MenuItems> _returnWholeList = new List<MenuItems>();

            // act
            TestMenuRepo.AddMenuItem(menuTest);
            _testWholeMenu.Add(menuTest);
            _returnWholeList = TestMenuRepo.GetEntireMenu();

            Assert.AreEqual(_testWholeMenu.Count, _returnWholeList.Count);
            //Assert.AreSame(_testWholeMenu, TestMenuRepo.GetEntireMenu());
        }
    }
}
