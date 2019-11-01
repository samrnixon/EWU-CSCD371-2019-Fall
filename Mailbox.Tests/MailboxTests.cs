using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {

        [TestMethod]
        public void Mailbox_JustTestingToString()
        {
            Person person = new Person("Sam", "Nixon");
            Mailbox mailbox = new Mailbox(person, (1,2), Sizes.None);
            mailbox.ToString();
            Assert.AreEqual("Sam Nixon 1,2", mailbox.ToString());
        }

        [TestMethod]
        public void Mailbox_NormalValues_SizeNotPremium()
        {
            Person person = new Person("Sam", "Nixon");

            Mailbox mailboxSmall = new Mailbox(person, (1, 2), Sizes.Small);
            Mailbox mailboxMedium = new Mailbox(person, (1, 2), Sizes.Medium);
            Mailbox mailboxLarge = new Mailbox(person, (1, 2), Sizes.Large);

            Assert.AreEqual("Sam Nixon 1,2 Small", mailboxSmall.ToString());
            Assert.AreEqual("Sam Nixon 1,2 Medium", mailboxMedium.ToString());
            Assert.AreEqual("Sam Nixon 1,2 Large", mailboxLarge.ToString());
        }

        [TestMethod]
        public void Mailbox_NormalValues_SizePremium()
        {
            Person person = new Person("Sam", "Nixon");

            Mailbox mailboxPremiumSmall = new Mailbox(person, (1, 2), Sizes.PremiumSmall);
            Mailbox mailboxPremiumMedium = new Mailbox(person, (1, 2), Sizes.PremiumMedium);
            Mailbox mailboxPremiumLarge = new Mailbox(person, (1, 2), Sizes.PremiumLarge);

            Assert.AreEqual("Sam Nixon 1,2 Small Premium", mailboxPremiumSmall.ToString());
            Assert.AreEqual("Sam Nixon 1,2 Medium Premium", mailboxPremiumMedium.ToString());
            Assert.AreEqual("Sam Nixon 1,2 Large Premium", mailboxPremiumLarge.ToString());
        }
    }
}
