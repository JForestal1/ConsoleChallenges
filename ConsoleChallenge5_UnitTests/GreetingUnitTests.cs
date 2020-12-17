using ConsoleChallenge5_repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ConsoleChallenge5_UnitTests
{
    [TestClass]
    public class GreetingUnitTests
    {
        CustomerRepo testCustomerRepo = new CustomerRepo();

        [TestMethod]
        public void TestAdd()
        {
            testCustomerRepo.AddCustomer("John", "Doe", Customer.CustomerType.Current);

            Assert.IsNotNull(testCustomerRepo);
        }

        [TestMethod]
        public void TestDelete()
        {
            testCustomerRepo.AddCustomer("John", "Doe", Customer.CustomerType.Current);
            testCustomerRepo.AddCustomer("XX", "XX", Customer.CustomerType.Current);

            Assert.IsTrue(testCustomerRepo.DeleteCustomer("John", "Doe"));
        }
        [TestMethod]
        public void TestUpdate()
        {
            testCustomerRepo.AddCustomer("John", "Doe", Customer.CustomerType.Current);
            testCustomerRepo.AddCustomer("XX", "XX", Customer.CustomerType.Current);
            Customer updatedCustomer = new Customer("Phil", "Collins", Customer.CustomerType.Current);

            Assert.IsTrue(testCustomerRepo.UpdateCustomer("John","Doe",updatedCustomer));
        }

        [TestMethod]
        public void TestRead()
        {
            testCustomerRepo.AddCustomer("John", "Doe", Customer.CustomerType.Current);
            testCustomerRepo.AddCustomer("XX", "XX", Customer.CustomerType.Current);

            Assert.IsTrue(testCustomerRepo.GetAllCustomers().Count == 2);
        }


    }
}
