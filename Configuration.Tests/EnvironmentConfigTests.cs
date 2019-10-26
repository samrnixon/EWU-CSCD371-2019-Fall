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
        public void GetConfigValue_ValueSentIsNullReturnTrue()
        {
            var environmentConfig = new EnvironmentConfig();
            string name = "PATH";
            string value = null;
            bool testBool = environmentConfig.GetConfigValue(name, value);
            Assert.IsTrue(testBool);
        }
        [TestMethod]
        public void GetConfigValue_NameSentisNullReturnFalse()
        {
            var environmentConfig = new EnvironmentConfig();
            string name = null;
            string value = "VALUE";
            bool testBool = environmentConfig.GetConfigValue(name, value);
            Assert.IsFalse(testBool);
        }

        [TestMethod]
        public void SetConfigValue_AllNormalReturnsTrue()
        {
            var environmentConfig = new EnvironmentConfig();
            string name = "NAME";
            string value = "VALUE";
            bool testBool = environmentConfig.SetConfigValue(name, value);
            Assert.IsTrue(testBool);
        }
    }
}
