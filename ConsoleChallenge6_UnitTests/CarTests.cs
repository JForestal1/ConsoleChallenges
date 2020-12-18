using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleChallenge6_repo;

namespace ConsoleChallenge6_UnitTests
{
    [TestClass]
    public class CarTests
    {
        CarRepo testCarRepo = new CarRepo();
        
        [TestMethod]
        public void TestAdd()
        {
            bool result;
            result = testCarRepo.AddCar(new Hybred("Prius", 3, 35900.00, 45, 120));
            result = result && testCarRepo.AddCar(new Electric("Volt", 5, 45500.00, 400));
            result = result && testCarRepo.AddCar(new Gas("Charger", 4, 32500.00, 25.8, 20));

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestUpdate()
        {

            testCarRepo.AddCar(new Hybred("Prius", 3, 35900.00, 45, 120));
            testCarRepo.AddCar(new Electric("Volt", 5, 45500.00, 400));
            testCarRepo.AddCar(new Electric("Zinger", 5, 45500.00, 400));
            testCarRepo.AddCar(new Electric("Magic", 5, 45500.00, 400));
            Gas updateTest = new Gas("Charger", 4, 32500.00, 25.8, 20);

            Assert.IsTrue(testCarRepo.UpdateCar("Prius",updateTest));
        }
        [TestMethod]
        public void TestDelete()
        {

            testCarRepo.AddCar(new Hybred("Prius", 3, 35900.00, 45, 120));
            testCarRepo.AddCar(new Electric("Volt", 5, 45500.00, 400));
            testCarRepo.AddCar(new Electric("Zinger", 5, 45500.00, 400));
            testCarRepo.AddCar(new Electric("Magic", 5, 45500.00, 400));

            Assert.IsTrue(testCarRepo.DeleteCar("Magic"));
        }

        [TestMethod]
        public void TestGetOneCar()
        {

            testCarRepo.AddCar(new Hybred("Prius", 3, 35900.00, 45, 120));
            testCarRepo.AddCar(new Electric("Volt", 5, 45500.00, 400));
            testCarRepo.AddCar(new Electric("Zinger", 5, 45500.00, 400));
            testCarRepo.AddCar(new Electric("Magic", 5, 45500.00, 400));

            Assert.IsNotNull(testCarRepo.GetOneCar("Magic"));
        }

    }
}
