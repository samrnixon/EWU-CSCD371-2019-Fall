using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_PathIsNull()
        {
            BaseLogger baseLogger;
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(null);
            baseLogger = logFactory.CreateLogger("Test Path");

            Assert.IsNull(baseLogger);
        }

        [TestMethod]
        public void CreateLogger_PathIsNotNull()
        {
            BaseLogger baseLogger;
            string randoPath = Path.GetTempFileName();
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(randoPath);
            baseLogger = logFactory.CreateLogger("Test Path");

            Assert.IsNotNull(baseLogger);
        }
    }
}
