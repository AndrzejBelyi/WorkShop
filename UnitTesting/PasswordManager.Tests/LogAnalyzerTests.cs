using System;
using System.Collections.Generic;
using System.Xml;
using HW;
using Moq;
using NUnit.Framework;


namespace PasswordManager.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {

        [Test]
        public void IsValidFileName_NameSupportedExtension_True()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.willBeValid = true;
            LogAnalyzer log = new LogAnalyzer(fakeManager);
            Assert.True(log.IsValidLogFileName("short.ext"));
        }
        [Test]
        public void MoqIsValidFileName_NameSupportedExtension_True()
        {
            var mock = new Mock<IExtensionManager>();
            mock.Setup(a => a.IsValid("short.ext")).Returns(true);
            LogAnalyzer log = new LogAnalyzer(mock.Object);
            Assert.True(log.IsValidLogFileName("short.ext"));

        }

        
       
    }

    public class FakeExtensionManager : IExtensionManager
    {
        public bool willBeValid = false;

        public bool IsValid(string fileleName)
        {
            return willBeValid;
        }
    }
}
