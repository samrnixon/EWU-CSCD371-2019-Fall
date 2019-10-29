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

        public bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name) ?? throw new ArgumentNullException(name);
            return true;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (Validator(name, value))
            {
                return false;
            }

            nameList.Add(name);
            Environment.SetEnvironmentVariable(name, value);
            return true;
        }

        public List<string> GetConfigList()
        {
            return this.nameList;
        }

        private bool Validator(string name, string? value)
        {
            if (value is null || name is null || name.Contains(" ") || name.Length < 1 || name.Contains("="))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
