using System;
using System.Collections.Generic;
using Configuration;
using Configuration.Tests;

namespace SampleApp
{
    public class Program
    {
        public static void Main()
        {
            #pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
            string? value;
            #pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
            var dataList = new List<(string, string)>
            {
                ("testNAME","testVALUE"),
                ("testNAME2","testVALUE2"),
                ("testNAME3","testVALUE3"),
                ("testNAME4","testVALUE4"),
                ("testNAME5","testVALUE5"),
                ("testNAME6","testVALUE6")
            };

            MockConfig mockConfig = new MockConfig(dataList);
            
            foreach((string,string) listElement in dataList)
            {
                mockConfig.GetConfigValue(listElement.Item1, out value);
                Console.WriteLine($"{listElement.Item1} = {value}");
            }
        }
    }
}
