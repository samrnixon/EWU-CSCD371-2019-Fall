using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public enum Column
        {
            Id, FirstName, LastName, Email, StreetAddress, City, State, Zip
        }

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("C:\\Users\\Sam\\source\\repos\\EWU-CSCD371-2019-Fall2\\Assignment\\People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> list = CsvRows
            .OrderBy(item => item.Split(',')[(int)Column.State])
            .Select(item => item.Split(',')[(int)Column.State])
            .Distinct();

            return list;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> list = GetUniqueSortedListOfStatesGivenCsvRows();

            string states = list.Aggregate((state1, stateN) => $"{state1},{stateN}");

            return states;
        }

        // 4.
        public IEnumerable<IPerson> People => MakePeople();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) => throw new NotImplementedException();

        public IEnumerable<IPerson> MakePeople()
        {
            IEnumerable<IPerson> peopleList = CsvRows
            .OrderBy(item => item.Split(',')[(int)Column.State])
            .ThenBy(item => item.Split(',')[(int)Column.City])
            .ThenBy(item => item.Split(',')[(int)Column.Zip])
            .Select(item =>
            {
                string[] addressColumns = item.Split(',');
                IAddress address = new Address(
                    addressColumns[(int)Column.StreetAddress], 
                    addressColumns[(int)Column.City], 
                    addressColumns[(int)Column.State], 
                    addressColumns[(int)Column.Zip]);
                IPerson person = new Person(
                    addressColumns[(int)Column.FirstName],
                    addressColumns[(int)Column.LastName],
                    address,
                    addressColumns[(int)Column.Email]);

                return person;
            });

            return peopleList;
        }

    }
}
