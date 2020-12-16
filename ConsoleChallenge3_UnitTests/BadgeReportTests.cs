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
            testBadgeRepo.AddBadge(1, testDoors);

            // act and assert
            Assert.IsNotNull(testBadgeRepo.GetSingleBadge(1));
        }
    }
}
