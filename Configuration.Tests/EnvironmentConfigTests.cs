using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        public void GetConfigValue_ValueSentIsNull_ReturnsTrue()
        {
            EnvironmentConfig environmentConfig = new EnvironmentConfig();
            string name = "PATH";
            string? value = null;
            bool testBool = environmentConfig.GetConfigValue(name, out value);
            Assert.IsTrue(testBool);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConfigValue_NameIsNull_ReturnsFalse()
        {
            EnvironmentConfig environmentConfig = new EnvironmentConfig();
            environmentConfig.GetConfigValue(null!, out string? value);
        }

        [TestMethod]
        public void GetConfigValue_ValidEntries_ReturnsTrue()
        {
            EnvironmentConfig environmentConfig = new EnvironmentConfig();
            Environment.SetEnvironmentVariable("NAME", "VALUE");
            bool testBool = environmentConfig.GetConfigValue("NAME", out string? value);
            Assert.IsTrue(testBool);
        }

/*        [TestMethod]
        public void GetConfigValue_NameSentisNullReturnFalse()
        {
            EnvironmentConfig environmentConfig = new EnvironmentConfig();
            string? name = null;
            string value = "VALUE";
            bool testBool = environmentConfig.GetConfigValue(name, out value);
            Assert.IsFalse(testBool);
        }*/

/*        [TestMethod]
        public void SetConfigValue_AllNormalReturnsTrue()
        {
            EnvironmentConfig environmentConfig = new EnvironmentConfig();
            string name = "NAME";
            string value = "VALUE";
            bool testBool = environmentConfig.SetConfigValue(name, value);
            Assert.IsTrue(testBool);
        }*/
    }
}
