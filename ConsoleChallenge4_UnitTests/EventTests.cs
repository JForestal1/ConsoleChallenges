using ConsoleChallenge4_repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleChallenge4_UnitTests
{
    [TestClass]
    public class EventTests
    {
        OutingRepo testOutingRepo = new OutingRepo();
        Outing outingToAdd = new Outing(Outing.EventType.Golf, 120, DateTime.Parse("12/17/2020"), 42.32, 2700.71);
        Outing outingToAdd2 = new Outing(Outing.EventType.Golf, 120, DateTime.Parse("12/17/2020"), 42.32, 100);
        Outing outingToAdd3 = new Outing(Outing.EventType.Bowling, 120, DateTime.Parse("12/17/2020"), 42.32, 200);

        [TestInitialize]
        public void Arrange()
        {

        }

        [TestMethod]
        public void TestAddAndGet()
        {
            // arrange
            // Done in Test Init

            //Act
            testOutingRepo.AddOuting(outingToAdd);

            // assert
            Assert.IsTrue(testOutingRepo.GetAllOutings() != null);
        }

        [TestMethod]
        public void TestGetTotalsFiltered()
        {
            // arrange
            // Done in Test Init

            //Act
            testOutingRepo.AddOuting(outingToAdd);
            testOutingRepo.AddOuting(outingToAdd2);
            testOutingRepo.AddOuting(outingToAdd3);

            // assert
            Assert.IsTrue(testOutingRepo.GetCostsTotal(Outing.EventType.Golf) == 2800.71);
        }

        [TestMethod]
        public void TestGetTotals()
        {
            // arrange
            // Done in Test Init

            //Act
            testOutingRepo.AddOuting(outingToAdd);
            testOutingRepo.AddOuting(outingToAdd2);
            testOutingRepo.AddOuting(outingToAdd3);

            // assert
            Assert.IsTrue(testOutingRepo.GetCostsTotal() == 3000.71);
        }
    }
}

//{
//    [TestClass]
//    public class BadgeReportTests
//{
//    BadgeRepo testBadgeRepo = new ConsoleChallenge3_repo.BadgeRepo();

//    [TestMethod]
//    public void TestAddUniqueKey()
//    {
//        // arrange
//        List<string> testDoors = new List<string>();
//        testDoors.Add("A1");
//        testDoors.Add("D3");
//        testDoors.Add("F4");

//        // act and assert
//        Assert.IsTrue(testBadgeRepo.AddBadge(1, testDoors));
//    }
//    [TestMethod]
//    public void TestAddNOTUniqueKey()
//    {
//        // arrange
//        List<string> testDoors = new List<string>();
//        testDoors.Add("A1");
//        testDoors.Add("D3");
//        testDoors.Add("F4");
//        testBadgeRepo.AddBadge(1, testDoors);

//        // act and assert
//        Assert.IsFalse(testBadgeRepo.AddBadge(1, testDoors));
//    }

//    [TestMethod]
//    public void TestGetSingleBadge()
//    {
//        // arrange
//        List<string> testDoors = new List<string>();
//        testDoors.Add("A1");
//        testDoors.Add("D3");
//        testDoors.Add("F4");
//        testBadgeRepo.AddBadge(2, testDoors);

//        // act and assert
//        Assert.IsNotNull(testBadgeRepo.GetSingleBadge(2));
//    }

//    [TestMethod]
//    public void TestGetAllBadge()
//    {
//        // arrange
//        List<string> testDoors = new List<string>();
//        testDoors.Add("A1");
//        testDoors.Add("D3");
//        testDoors.Add("F4");
//        testBadgeRepo.AddBadge(1, testDoors);
//        List<string> testDoors2 = new List<string>();
//        testDoors2.Add("B1");
//        testDoors2.Add("C3");
//        testDoors2.Add("G4");
//        testBadgeRepo.AddBadge(2, testDoors2);

//        // act and assert
//        Assert.IsTrue(testBadgeRepo.GetAllBadges().Count == 2);
//    }

//    [TestMethod]
//    public void TestDeleteAllDoors()
//    {
//        // arrange
//        List<string> testDoors = new List<string>();
//        testDoors.Add("A1");
//        testDoors.Add("D3");
//        testDoors.Add("F4");
//        testBadgeRepo.AddBadge(1, testDoors);

//        // act and assert
//        Assert.IsTrue(testBadgeRepo.DeleteAllDoors(1) && testBadgeRepo.GetSingleBadge(1).Doors.Count == 0);
//    }
//    [TestMethod]
//    public void TestUpdateDoors()
//    {
//        // arrange
//        List<string> testDoors = new List<string>();
//        testDoors.Add("A1");
//        testDoors.Add("D3");
//        testDoors.Add("F4");
//        testBadgeRepo.AddBadge(1, testDoors);
//        List<string> testnewDoors = new List<string>();
//        testnewDoors.Add("X1");
//        testnewDoors.Add("Y3");

//        // act and assert
//        Assert.IsTrue(testBadgeRepo.UpdateDoors(1, testnewDoors));
//    }
//}
//}