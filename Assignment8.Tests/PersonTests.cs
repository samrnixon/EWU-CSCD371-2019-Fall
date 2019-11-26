using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        [DataRow(null!, "Montoya","Email")]
        [DataRow("Inigo", null!,"Email")]
        [DataRow("Inigo", "Montoya", null!)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonEachValuePassed_ExceptAddress_IsNull_Fail(string firstName, string lastName, string emailAddress)
        {
            IAddress address = new Address("StreetAddress", "City", "State", "Zip");
            _ = new Person(firstName, lastName, address, emailAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonEachValuePassedInIsGoodExceptAddressIsNull_Fail()
        {
            _ = new Person("Inigo", "Montoya", null!, "Email");
        }

        [TestMethod]
        public void PersonObjectCreated_Successful()
        {
            IAddress address = new Address("777 Foo Bar St", "Cheney", "WA", "99004");

            Person person = new Person("Inigo", "Montoya", address, "Email");

            Assert.IsTrue(person.ToString() == "Inigo, Montoya, 777 Foo Bar St, Cheney, WA, 99004, Email");
        }

    }
}