using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleChallenge3_repo;
using System.Collections.Generic;

namespace ConsoleChallenge3_UnitTests
{
    [TestClass]
    public class BadgeReportTests
    {
        BadgeRepo testBadgeRepo = new ConsoleChallenge3_repo.BadgeRepo();

        [TestMethod]
        public void TestAddUniqueKey()
        {
            // arrange
            List<string> testDoors = new List<string>();
            testDoors.Add("A1");
            testDoors.Add("D3");
            testDoors.Add("F4");

            // act and assert
            Assert.IsTrue(testBadgeRepo.AddBadge(1, testDoors));
        }
        [TestMethod]
        public void TestAddNOTUniqueKey()
        {
            // arrange
            List<string> testDoors = new List<string>();
            testDoors.Add("A1");
            testDoors.Add("D3");
            testDoors.Add("F4");
            testBadgeRepo.AddBadge(1, testDoors);

            // act and assert
            Assert.IsFalse(testBadgeRepo.AddBadge(1, testDoors));
        }

        [TestMethod]
        public void testGetSingleBadge()
        {
            // arrange
            List<string> testDoors = new List<string>();
            testDoors.Add("A1");
            testDoors.Add("D3");
            testDoors.Add("F4");
            testBadgeRepo.AddBadge(2, testDoors);

            // act and assert
            Assert.IsNotNull(testBadgeRepo.GetSingleBadge(2));
        }

        [TestMethod]
        public void testGetAllBadge()
        {
            // arrange
            List<string> testDoors = new List<string>();
            testDoors.Add("A1");
            testDoors.Add("D3");
            testDoors.Add("F4");
            testBadgeRepo.AddBadge(1, testDoors);
            List<string> testDoors2 = new List<string>();
            testDoors2.Add("B1");
            testDoors2.Add("C3");
            testDoors2.Add("G4");
            testBadgeRepo.AddBadge(2, testDoors2);

            // act and assert
            Assert.IsTrue(testBadgeRepo.GetAllBadges().Count == 2);
        }

        [TestMethod]
        public void testDeleteAllDoors()
        {
            // arrange
            List<string> testDoors = new List<string>();
            testDoors.Add("A1");
            testDoors.Add("D3");
            testDoors.Add("F4");
            testBadgeRepo.AddBadge(1, testDoors);

            // act and assert
            Assert.IsTrue(testBadgeRepo.DeleteAllDoors(1) && testBadgeRepo.GetSingleBadge(1).Doors.Count == 0);
        }
        [TestMethod]
        public void testUpdateDoors()
        {
            // arrange
            List<string> testDoors = new List<string>();
            testDoors.Add("A1");
            testDoors.Add("D3");
            testDoors.Add("F4");
            testBadgeRepo.AddBadge(1, testDoors);
            List<string> testnewDoors = new List<string>();
            testnewDoors.Add("X1");
            testnewDoors.Add("Y3");

            // act and assert
            Assert.IsTrue(testBadgeRepo.UpdateDoors(1, testnewDoors));
        }
    }
}
