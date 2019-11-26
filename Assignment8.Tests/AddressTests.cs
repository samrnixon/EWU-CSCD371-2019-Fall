using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        [DataRow(null!, "City", "State", "Zip")]
        [DataRow("StreetAddress", null!, "State", "Zip")]
        [DataRow("StreetAddress", "City", null!, "Zip")]
        [DataRow("StreetAddress", "City", "State", null!)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressEachValuePassedIsNull_Fail(string streetAddress, string city, string state, string zip)
        {
            _ = new Address(streetAddress, city, state, zip);
        }

        [TestMethod]
        public void AddressObjectCreated_Success()
        {
            Address address = new Address("777 Foo Bar St","Cheney","WA","99004");
            Assert.IsTrue(address.ToString() == "777 Foo Bar St, Cheney, WA, 99004");
        }

    }
}