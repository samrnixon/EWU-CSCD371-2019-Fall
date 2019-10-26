using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        private List<string> nameList;
        public EnvironmentConfig()
        {
            nameList = new List<string>();
        }
        public bool GetConfigValue(string name, string? value)
        {
            if (name is null) { return false; }
            value = Environment.GetEnvironmentVariable(name);
            if(value is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (value is null || name is null)
            {
                return false;
            }
            nameList.Add(name);
            Environment.SetEnvironmentVariable(name, value);
            return true;
        }

    }
}
