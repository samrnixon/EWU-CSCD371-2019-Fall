using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        private string FilePath { get; }

        public FileConfig(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public bool GetConfigValue(string name, out string? value)
        {
            if(File.Exists(FilePath))
            {
                string[] fileLines = File.ReadAllLines(FilePath);

                foreach(string line in fileLines)
                {
                    string[] parsedLine = line.Split("=");

                    if(name.Equals(parsedLine[0]))
                    {
                        value = parsedLine[1];
                        return true;
                    }
                }
            }

            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value) //worked with crackerJackTech
        {
            if (Validator(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            string newEntry = $"{name}={value}";

            if (File.Exists(FilePath))
            {
                string[] linesInFile = File.ReadAllLines(FilePath);
                bool valueFound = false;

                for (int i = 0; i < linesInFile.Length; i++)
                {
                    string[] parsedLine = linesInFile[i].Split("=");
                    if (parsedLine[0].Equals(name))
                    {
                        linesInFile[i] = newEntry;
                        valueFound = true;
                    }

                }

                File.WriteAllLines(FilePath, linesInFile);

                using (var streamWriter = new StreamWriter(FilePath))
                {
                    foreach (string lines in linesInFile)
                    {
                        streamWriter.WriteLine(lines);
                    }

                    if (!valueFound)
                    {
                        streamWriter.WriteLine(newEntry);
                    }

                    streamWriter.Close();
                }
                return true;
            }
            return false;
        }

        private bool Validator(string name)
        {
            if (name is null || name.Contains(" ") || name.Length < 1 || name.Contains("="))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Writes(EnvironmentConfig environmentConfig)
        {
            if(environmentConfig is null)
            {
                throw new ArgumentNullException(nameof(environmentConfig));
            }

            List<string> configNames = environmentConfig.GetConfigList();

            using(StreamWriter streamWriter = new StreamWriter(FilePath, false))
            {
                foreach(string configLine in configNames)
                {
                    streamWriter.WriteLine($"{configLine} = {Environment.GetEnvironmentVariable(configLine)}");
                }
            }
        }
    }
}
