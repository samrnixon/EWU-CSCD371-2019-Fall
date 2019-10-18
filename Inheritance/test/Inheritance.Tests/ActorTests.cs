using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void ExpectedSpeech_Penny()
        {
            Penny penny = new Penny();
            Assert.AreEqual("Hello I am Penny", ActorExtensions.Speak(penny));
        }

        [TestMethod]
        public void ExpectedSpeech_Sheldon()
        {
            Sheldon sheldon = new Sheldon();
            Assert.AreEqual("Hello I am Sheldon", ActorExtensions.Speak(sheldon));
        }

        [TestMethod]
        public void ExpectedSpeech_WomenArePresent_Raj()
        {
            Raj raj = new Raj
            {
                WomenAreAround = true
            };

            Assert.AreEqual("*mumbles", ActorExtensions.Speak(raj));
        }

        [TestMethod]
        public void ExpectedSpeech_WomenAreNotPresent_Raj()
        {
            Raj raj = new Raj
            {
                WomenAreAround = false
            };

            Assert.AreEqual("Hello I am Raj", ActorExtensions.Speak(raj));
        }
    }
}
