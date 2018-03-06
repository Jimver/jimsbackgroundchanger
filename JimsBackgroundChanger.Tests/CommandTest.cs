using System;
using NUnit.Framework;

namespace JimsBackgroundChanger.Tests
{
    [TestFixture]
    public class CommandTest
    {
        private Command.Result _result;
        [SetUp]
        public void StartUp()
        {
            _result = new Command.Result(0, "", "out");
        }

        [TearDown]
        public void TearDown()
        {
            _result = null;
        }

        [Test]
        public void ResultTest()
        {
            Assert.NotNull(_result);
        }

        [Test]
        public void RunTest()
        {
            Assert.AreEqual(new Command.Result(0, "", ""), Command.Run("cmd.exe", "/C"));
        }
    }
}
