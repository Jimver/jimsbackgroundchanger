using NUnit.Framework;
using Resolution = JimsBackgroundChanger.Settings.Resolution;

namespace JimsBackgroundChanger.Tests
{
    [TestFixture()]
    public class ResolutionTests
    {
        private Resolution _resolution;

        [SetUp()]
        public void StartUp()
        {
            _resolution = new Resolution(1920, 1080, null);
        }

        [TearDown()]
        public void TearDown()
        {
            _resolution = null;
        }

        [Test()]
        public void ResolutionTest()
        {
            Assert.AreEqual(1920, _resolution.Width);
            Assert.AreEqual(1080, _resolution.Height);
        }

        [Test()]
        public void ToStringTest()
        {
            Assert.AreEqual("1920x1080", _resolution.ToString());
        }

        [Test()]
        public void EqualsTest()
        {
            Assert.IsTrue(_resolution.Equals(new Resolution(1920, 1080, null)));
        }
    }
}