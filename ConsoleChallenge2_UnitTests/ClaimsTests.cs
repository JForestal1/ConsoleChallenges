using ConsoleChallenge2_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ConsoleChallenge2_UnitTests
{
    [TestClass]
    public class ClaimsTests
    {
        Claim testClaim = new Claim();
        ClaimRepo testClaimRepo = new ClaimRepo();

        [TestInitialize]
        public void Arrange()
        {
        }

        [TestMethod]
        public void TestAdd()
        {
            // arrange - IsValid set to false. should be changed within add method due to business rules

            Claim expectedClaim = new Claim(1, Claim.ClaimType.Car, "Vehicle Accident", 1500, new DateTime(2020, 03, 03), new DateTime(2020, 04, 01), true);
            
            
            bool result = false;
            // Act
            testClaimRepo.AddToQueue(new Claim(1, Claim.ClaimType.Car, "Vehicle Accident", 1500, new DateTime(2020, 03, 03), new DateTime(2020, 04, 01), true));
            var resultClaim = testClaimRepo.GetCurrentClaim();
            
           
            if (resultClaim.Description == expectedClaim.Description &&
                resultClaim.ClaimID == expectedClaim.ClaimID &&
                resultClaim.ClaimAmount == expectedClaim.ClaimAmount &&
                resultClaim.DateOfClaim == expectedClaim.DateOfClaim &&
                resultClaim.DateOfIncident == expectedClaim.DateOfIncident &&
                resultClaim.IsValid == expectedClaim.IsValid &&
                resultClaim.Type == expectedClaim.Type)
                result = true;

            // Assert 
            Assert.IsTrue(result);
            //????????? This fails when I compare the entire claim
            //Assert.AreEqual(expectedClaim, resultClaim);
        }
        [TestMethod]
        public void TestIDUniqueIsNotUnique()
        {
            // arrange - add a claim to the queue
            testClaimRepo.AddToQueue(new Claim(1, Claim.ClaimType.Car, "Vehicle Accident", 1500, new DateTime(2020, 03, 03), new DateTime(2020, 04, 01), true));

             //Act
             bool result = testClaimRepo.ClaimIdIsUnique(1);

            // arrange 
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestIDUniqueIsUnique()
        {
            // arrange - add a claim to the queue
            testClaimRepo.AddToQueue(new Claim(2, Claim.ClaimType.Car, "Vehicle Accident", 1500, new DateTime(2020, 03, 03), new DateTime(2020, 04, 01), true));

            //Act
            bool result = testClaimRepo.ClaimIdIsUnique(1);

            // arrange 
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestGetQueue()
        {
            // arrange - add 4 claims to the queue
            testClaimRepo.AddToQueue(new Claim(1, Claim.ClaimType.Car, "Vehicle Accident", 1500, new DateTime(2020, 03, 03), new DateTime(2020, 04, 01), true));
            testClaimRepo.AddToQueue(new Claim(2, Claim.ClaimType.Home, "Nasty house fire", 80000, new DateTime(2020, 05, 04), new DateTime(2020, 06, 03), true));
            testClaimRepo.AddToQueue(new Claim(3, Claim.ClaimType.Theft, "Stolen source code", 20, new DateTime(2020, 11, 14), new DateTime(2020, 12, 13), true));
            testClaimRepo.AddToQueue(new Claim(4, Claim.ClaimType.Theft, "Stolen cheese - late", 20, new DateTime(2020, 08, 03), new DateTime(2020, 10, 21), true));
            Queue<Claim> testClaimQueue = new Queue<Claim>();

            //Act
            testClaimQueue = testClaimRepo.GetEntireQueue();

            // arrange 
            Assert.IsTrue(testClaimQueue.Count==4);
        }
        [TestMethod]
        public void TestProcess()
        {
            // arrange - add 4 claims to the queue
            testClaimRepo.AddToQueue(new Claim(1, Claim.ClaimType.Car, "Vehicle Accident", 1500, new DateTime(2020, 03, 03), new DateTime(2020, 04, 01), true));
            testClaimRepo.AddToQueue(new Claim(2, Claim.ClaimType.Home, "Nasty house fire", 80000, new DateTime(2020, 05, 04), new DateTime(2020, 06, 03), true));
            testClaimRepo.AddToQueue(new Claim(3, Claim.ClaimType.Theft, "Stolen source code", 20, new DateTime(2020, 11, 14), new DateTime(2020, 12, 13), true));
            testClaimRepo.AddToQueue(new Claim(4, Claim.ClaimType.Theft, "Stolen cheese - late", 20, new DateTime(2020, 08, 03), new DateTime(2020, 10, 21), true));

            //Act
            bool result = testClaimRepo.ProcessClaim();

            // arrange 
            Assert.IsTrue(testClaimRepo.GetEntireQueue().Count == 3 && result);
        }
        [TestMethod]
        public void TestGetCurrentClaim()
        {
            // arrange - add 4 claims to the queue
            testClaimRepo.AddToQueue(new Claim(1, Claim.ClaimType.Car, "Vehicle Accident", 1500, new DateTime(2020, 03, 03), new DateTime(2020, 04, 01), true));
            testClaimRepo.AddToQueue(new Claim(2, Claim.ClaimType.Home, "Nasty house fire", 80000, new DateTime(2020, 05, 04), new DateTime(2020, 06, 03), true));
            testClaimRepo.AddToQueue(new Claim(3, Claim.ClaimType.Theft, "Stolen source code", 20, new DateTime(2020, 11, 14), new DateTime(2020, 12, 13), true));
            testClaimRepo.AddToQueue(new Claim(4, Claim.ClaimType.Theft, "Stolen cheese - late", 20, new DateTime(2020, 08, 03), new DateTime(2020, 10, 21), true));
            Claim expectedClaim = new Claim();
            bool result = false;

            //Act
            expectedClaim = testClaimRepo.GetCurrentClaim();
            if (expectedClaim.Description == "Vehicle Accident")
                result = true;

            // arrange 
            Assert.IsTrue(result);
        }

    }
}

