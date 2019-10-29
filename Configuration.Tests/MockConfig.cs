using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    public class MockConfig : IConfig
    {
        private List<(string, string?)>? _DataList;

        public MockConfig() { }
        public MockConfig(List<(string,string?)> list)
        {
            _DataList = list;
        }

        public bool GetConfigValue(string name, out string? value)
        {
            if(name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }


            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach ((string,string?) listElement in _DataList)
            #pragma warning restore CS8602 // Dereference of a possibly null reference.
            {
                if(listElement.Item1.Equals(name))
                {
                    value = listElement.Item2;
                    return true;
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if(name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
        #pragma warning disable CS8602 // Dereference of a possibly null reference.
            _DataList.Add((name, value));
        #pragma warning restore CS8602 // Dereference of a possibly null reference.
            return true;
        }
    }
}
