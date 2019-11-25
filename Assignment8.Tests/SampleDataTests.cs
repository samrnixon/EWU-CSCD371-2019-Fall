using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Assignment.SampleData;

namespace Assignment8.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void SampleDataCsvRows_FirstRowIsSkipped()
        {
            SampleData sample = new SampleData();
            IEnumerable<string> sampleList = sample.CsvRows;

            Assert.IsFalse(Enumerable.Contains<string>(sampleList, "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip"));
        }

        [TestMethod]
        public void SampleDataCsvRows_SomeRowFound()
        {
            SampleData sample = new SampleData();
            IEnumerable<string> sampleList = sample.CsvRows;

            Assert.IsTrue(Enumerable.Contains<string>(sampleList,"10,Scarface,Dennington,sdennington9@chron.com,9978 Maple Wood Parkway,Memphis,TN,99928"));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsAList_Success()
        {
            SampleData sampleData = new SampleData();
            List<string> sampleList = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();

            Assert.IsTrue(sampleList.Count > 0);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsSortedList_Success()
        {
            ISampleData sampleData = new SampleData();
            IEnumerable<string> data = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
             
            IEnumerable<string> sortedDataList = sampleData.CsvRows
            .OrderBy(item => item.Split(',')[(int)Column.State])
            .Select(item => item.Split(',')[(int)Column.State])
            .Distinct();

            Assert.IsTrue(Enumerable.SequenceEqual(sortedDataList, data));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsAListOfOnlyStates_Success()
        {
            SampleData sampleData = new SampleData();
            List<string> sampleList = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().Select(item => "WA").Distinct().ToList();

            var expected = new List<string>()
            {
                "WA"
            };

            Assert.AreEqual(sampleList.Count, expected.Count);
            Assert.IsTrue(Enumerable.SequenceEqual(sampleList,expected));

        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsCorrectString()
        {
            SampleData sampleData = new SampleData();
            string sampleString = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            string expected = "AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV";

            Assert.AreEqual<string>(sampleString, expected);
        }

        [TestMethod]
        public void SampleDataPeople_CorrectlyMakesPeopleObjects()
        {
            SampleData sampleData = new SampleData();
            IEnumerable<IPerson> people = sampleData.People;

            Assert.IsTrue(people.Any());
        }

        /*        [TestMethod]
                public void SampleDataPeople_ChecksListToSeeIfAPersonExists()
                {
                    SampleData sampleData = new SampleData();
                    SampleData sampleData1 = new SampleData();

                    var sampleList = sampleData.CsvRows;
                    var sampleList1 = sampleData1.People;

        *//*            IAddress address = new Address("7884 Corry Way","Helena","MT","70577");
                    IPerson person = new Person("Priscilla","Jenyns",address,"pjenyns0@state.gov");*//*

                    //Assert.IsTrue(Enumerable.Contains(sampleList1.));
                }*/

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SampleData_FilterUsingEmailAddress_NullFilter_Fails()
        {
            SampleData sampleData = new SampleData();

            IEnumerable<(string, string)> returnedList =
                sampleData.FilterByEmailAddress(null!);
        }

        [TestMethod]
        public void SampleData_FilterUsingEmailAddress_ReturnsOnePersonList_Success()
        {
            SampleData sampleData = new SampleData();

            List<(string, string)> expected = new List<(string, string)>()
            {
                ("Chelsy","Buckle")
            };

            IEnumerable<(string, string)> returnedList =
                sampleData.FilterByEmailAddress(item => item.EndsWith("tiny.cc", StringComparison.Ordinal));

            Assert.IsTrue(returnedList.SequenceEqual(expected));
        }

        [TestMethod]
        public void SampleData_FilterUsingEmailAddress_ReturnsMultiplePersonList_Success()
        {
            SampleData sampleData = new SampleData();

            List<(string, string)> expected = new List<(string, string)>()
            {
                ("Sancho","Mahony"),
                ("Fayette","Dougherty")
            };

            IEnumerable<(string, string)> returnedList =
                sampleData.FilterByEmailAddress(item => item.EndsWith("stanford.edu", StringComparison.Ordinal));

            Assert.IsTrue(returnedList.SequenceEqual(expected));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SampleData_GetAggregateListOfStatesGivenPeople_PassedInNull_Fail()
        {
            SampleData sampleData = new SampleData();
            string sampleString = sampleData.GetAggregateListOfStatesGivenPeopleCollection(null!);
        }

        [TestMethod]
        public void SampleDataGetAggregateListOfStatesGivenPeople_PassedInGoodPeopleList_Success()
        {
            SampleData sampleData = new SampleData();
            string sampleString = sampleData.GetAggregateListOfStatesGivenPeopleCollection(sampleData.People);
            string expected = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            Assert.AreEqual(sampleString, expected);
        }
    }
}
