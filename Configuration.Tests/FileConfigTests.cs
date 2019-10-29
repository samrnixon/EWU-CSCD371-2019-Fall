using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileConfig_ConstructorNull()
        {
            
            new FileConfig(null!);
            
        }

        [TestMethod]
        public void FileConfig_ValidConstructor()
        {
            _ = new FileConfig("config.settings");
        }

        [TestMethod]
        public void FileConfig_InvalidConstructor_CallGetValue_ReturnsTrue()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\configTEST.settings";
            var file = File.Create(filePath);
            file.Close();
            using (StreamWriter sr = new StreamWriter(filePath))
            {
                sr.Write("testNAME=testVALUE");
                sr.Close();
            }
            
            FileConfig test = new FileConfig(filePath);
            Assert.IsTrue(test.GetConfigValue("testNAME", out string? value));
            File.Delete(filePath);
        }

        [TestMethod]
        public void FileConfig_InvalidConstructor_CallGetValue_ReturnsFalse()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\configTEST.settings";
            var file = File.Create(filePath);
            file.Close();
            using (StreamWriter sr = new StreamWriter(filePath))
            {
                sr.Write("testNAME=testVALUE");
                sr.Close();
            }

            FileConfig test = new FileConfig(filePath);
            Assert.IsFalse(test.GetConfigValue("testBAD", out string? value));
            File.Delete(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileConfig_SetConfig_NameIsNull()
        {
            FileConfig fileConfig = new FileConfig("TESTPATH");
            fileConfig.SetConfigValue(null!, null);
        }

        [TestMethod]
        public void FileConfig_SetConfig_ValidName()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\configTEST.settings";
            var file = File.Create(filePath);
            file.Close();
            FileConfig fileConfig = new FileConfig(filePath);
            fileConfig.SetConfigValue("nameTEST", "valueTEST");
            fileConfig.SetConfigValue("nameTEST2", "valueTEST2");

            Assert.IsTrue(fileConfig.SetConfigValue("nameTEST3", "valueTEST3"));

            File.Delete(filePath);
        }

        [TestMethod]
        public void FileConfig_SetConfig_SameNameNewValue()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\configTEST.settings";
            var file = File.Create(filePath);
            file.Close();
            FileConfig fileConfig = new FileConfig(filePath);
            fileConfig.SetConfigValue("nameTEST", null!);
            fileConfig.SetConfigValue("nameTEST", "valueTEST1");

            Assert.IsTrue(fileConfig.SetConfigValue("nameTEST2", "valueTEST2"));
            File.Delete(filePath);
        }
    }
}
