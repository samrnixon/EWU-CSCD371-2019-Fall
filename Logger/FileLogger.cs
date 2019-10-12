using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string fPath;
        StreamWriter sWriter;

        public FileLogger(string pth)
        {
            fPath = pth;

            if(File.Exists(fPath))
            {

            }
            else
            {
                File.Create(fPath);
            }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            DateTime dateTime = DateTime.Now;
            string dTime = dateTime.ToString();
            string lLevel = logLevel.ToString();

            string logInput = $"{dTime} {className} {lLevel} {message}";

            using(sWriter = new StreamWriter(fPath))
            {
                sWriter.WriteLine(logInput);
            }
        }
    }
}
