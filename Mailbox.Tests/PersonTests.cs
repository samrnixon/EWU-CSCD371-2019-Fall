using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [TestClass]
    public class PersonTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonWithNullFirstName_ThrowsArgumentNullException()
        {
            Person person = new Person(null, "Nixon");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonWithNullLastName_ThrowsArgumentNullException()
        {
            Person person = new Person("Sam", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonWithFirstNameAndLastNameNull_ThrowsArgumentNullException()
        {
            Person person = new Person(null, null);
        }

        [TestMethod]
        public void PersonCheckingPersonEquals_DifferentPeopleFalse()
        {
            Person personA = new Person("Sam", "Nixon");
            Person personB = new Person("Foo", "Bar");

            Assert.IsFalse(personA.Equals(personB));
        }

        [TestMethod]
        public void PersonCheckingPersonEquals_SameNameDifferntObjTrue()
        {
            Person personA = new Person("Sam", "Nixon");
            Person personB = new Person("Sam", "Nixon");

            Assert.IsTrue(personA.Equals(personB));
        }

        [TestMethod]
        public void PersonCheckingPersonEquals_MultipleNameDifferntObjTrue()
        {
            Person personA = new Person("Sam", "Nixon");
            Person personB = new Person("Sam", "Nixon");
            Person personC = new Person("Foo", "Bar");

            Assert.IsTrue(personA.Equals(personB));
            Assert.IsFalse(personA.Equals(personC));
            Assert.IsFalse(personB.Equals(personC));
        }

        [TestMethod]
        public void PersonToStringTest_ReturnsCorrectString()
        {
            Person personA = new Person("Sam", "Nixon");

            Assert.AreEqual("Sam Nixon", personA.ToString());
        }
        
    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
