using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox.Tests
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataLoaderStreamSourceIsNull_ThrowsException()
        {
            using var dataLoader = new DataLoader(null);
        }

/*        [TestMethod]
        public void DataLoaderStreamSourceIsValid_LoadWorks()
        {
            var personA = new Person("Sam", "Nixon");

            List<Mailbox>? mailboxes = new List<Mailbox>()
            {
                new Mailbox(personA, (0,0), Sizes.Large)
            };

            string jsonData = JsonConvert.SerializeObject(mailboxes);

            using var ms = new MemoryStream();
            using var writer = new StreamWriter(ms, leaveOpen: true);
            writer.WriteLine(jsonData);
            DataLoader dataLoader = new DataLoader(ms);

            List<Mailbox>? testList = dataLoader.Load();

            Assert.AreEqual(mailboxes.Count, testList.Count);
        }
*/
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataLoaderSaveNullPassed_ThrowsArgumentNullException()
        {
            using var ms = new MemoryStream();
            DataLoader dataLoader = new DataLoader(ms);

            dataLoader.Save(null);
        }

/*        [TestMethod]
        public void DataLoaderStreamSourceIsValid_SaveWorks()
        {
            var personA = new Person("Sam", "Nixon");
            var personB = new Person("Foo", "Bar");

            List<Mailbox>? mailboxes = new List<Mailbox>()
            {
                new Mailbox(personA, (0,0), Sizes.Large),
                new Mailbox(personB, (0,1), Sizes.Medium)
            };

            string jsonData = JsonConvert.SerializeObject(mailboxes);

            using var ms = new MemoryStream();
            using var writer = new StreamWriter(ms, leaveOpen: true);
            writer.WriteLine(jsonData);
            DataLoader dataLoader = new DataLoader(ms);

            dataLoader.Save(mailboxes);
            List<Mailbox>? testList = dataLoader.Load();

            Assert.AreEqual(mailboxes.ToString(), testList?.ToString());
        }*/

    }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
}
