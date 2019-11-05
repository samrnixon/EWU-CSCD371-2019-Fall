using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxesTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MailboxesInvalidWidth_Fails()
        {
            List<Mailbox> mailboxList = new List<Mailbox>()
            {
                new Mailbox(new Person("Sam", "Nixon"), (0,0),Sizes.Medium)
            };
            Mailboxes mailboxes = new Mailboxes(mailboxList, -1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MailboxesInvalidHeight_Fails()
        {
            List<Mailbox> mailboxList = new List<Mailbox>()
            {
                new Mailbox(new Person("Sam", "Nixon"), (0,0),Sizes.Medium)
            };
            Mailboxes mailboxes = new Mailboxes(mailboxList, 10, -1);
        }

        [TestMethod]
        public void MailboxesValidList_ListSizeCorrect()
        {
            List<Mailbox> mailboxList = new List<Mailbox>()
            {
                new Mailbox(new Person("Sam", "Nixon"), (0,0),Sizes.Medium),
                new Mailbox(new Person("Foo", "Bar"), (0,1),Sizes.Medium),
                new Mailbox(new Person("Bar", "Foo"), (0,2),Sizes.Medium)
            };

            Mailboxes mailboxes = new Mailboxes(mailboxList, 30, 10);

            Assert.AreEqual(3, mailboxList.Count);
        }

        [TestMethod]
        public void MailboxesValidList_ContainsMailboxObjectsTrueOrFalse()
        {
            Person personA = new Person("Sam", "Nixon");
            Person personB = new Person("Foo", "Bar");
            Mailbox mailboxA = new Mailbox(personA, (0, 0), Sizes.Large);
            Mailbox mailboxB = new Mailbox(personB, (0, 1), Sizes.Medium);

            List<Mailbox> mailboxList = new List<Mailbox>();
            mailboxList.Add(mailboxA);
            mailboxList.Add(mailboxB);

            Mailboxes mailboxes = new Mailboxes(mailboxList, 30, 10);

            Assert.AreEqual(mailboxA, mailboxList[0]);
            Assert.AreEqual(mailboxB, mailboxList[1]);
            Assert.AreNotEqual(mailboxB, mailboxList[0]);
            Assert.AreNotEqual(mailboxA, mailboxList[1]);
        }

        [TestMethod]
        public void MailboxesAdjacentPeople()
        {
            Person personA = new Person("Sam", "Nixon");
            Person personB = new Person("Foo", "Bar");
            Mailbox mailboxA = new Mailbox(personA, (0, 0), Sizes.Large);
            Mailbox mailboxB = new Mailbox(personB, (0, 1), Sizes.Medium);

            List<Mailbox> mailboxList = new List<Mailbox>();
            mailboxList.Add(mailboxA);
            mailboxList.Add(mailboxB);

            Mailboxes mailboxes = new Mailboxes(mailboxList, 30, 10);
            HashSet<Person> mailboxesHash = new HashSet<Person>();
            bool isOccupied = mailboxes.GetAdjacentPeople(0,1, out mailboxesHash);

            Assert.AreEqual(isOccupied, mailboxesHash.Contains(personA));
        }

        [TestMethod]
        public void MailboxesAdjacentPeople_IsOccupied()
        {
            Person personA = new Person("Sam", "Nixon");
            Person personB = new Person("Foo", "Bar");
            Mailbox mailboxA = new Mailbox(personA, (0, 0), Sizes.Large);
            Mailbox mailboxB = new Mailbox(personB, (0, 1), Sizes.Medium);

            List<Mailbox> mailboxList = new List<Mailbox>();
            mailboxList.Add(mailboxA);
            mailboxList.Add(mailboxB);

            Mailboxes mailboxes = new Mailboxes(mailboxList, 30, 10);
            HashSet<Person> mailboxesHash = new HashSet<Person>();
            bool isOccupied = mailboxes.GetAdjacentPeople(0, 1, out mailboxesHash);

            Assert.IsTrue(isOccupied);
        }

        [TestMethod]
        public void MailboxesAdjacentPeople_IsNotOccupied()
        {
            Person personA = new Person("Sam", "Nixon");
            Person personB = new Person("Foo", "Bar");
            Mailbox mailboxA = new Mailbox(personA, (0, 0), Sizes.Large);
            Mailbox mailboxB = new Mailbox(personB, (0, 1), Sizes.Medium);

            List<Mailbox> mailboxList = new List<Mailbox>();
            mailboxList.Add(mailboxA);
            mailboxList.Add(mailboxB);

            Mailboxes mailboxes = new Mailboxes(mailboxList, 30, 10);
            HashSet<Person> mailboxesHash = new HashSet<Person>();
            bool isOccupied = mailboxes.GetAdjacentPeople(3, 6, out mailboxesHash);

            Assert.IsFalse(isOccupied);
        }
    }
}
