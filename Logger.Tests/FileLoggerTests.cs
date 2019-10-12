using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_LogCreateFileCorrectly()
        {
            string fPath = Path.GetTempFileName();
            FileLogger fLogger = new FileLogger(fPath);
            Assert.IsTrue(File.Exists(fPath));
            //File.Delete(fPath);
        }

        [TestMethod]
        public void FileLogger_LogWrittenToFileCorrectly()
        {
            string fPath = Path.GetTempFileName();
            FileLogger fLogger = new FileLogger(fPath);
            fLogger.Log(LogLevel.Warning, "Testing Method");

            int lineCount = File.ReadLines(fPath).Count();

            Assert.AreEqual(1, lineCount);
        }
    }
}
