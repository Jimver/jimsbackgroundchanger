using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Resolution = JimsBackgroundChanger.Settings.Resolution;

namespace JimsBackgroundChanger.Tests
{
    [TestFixture()]
    public class SettingsTests
    {
        private static string fileName = "settings.jbc";
        private Settings _settings;
        private List<Resolution> _resolutions;

        [SetUp()]
        public void StartUp()
        {
            _resolutions = new List<Resolution> {new Resolution(1920, 1080, null), new Resolution(3440, 1440, null)};
            _settings = new Settings(_resolutions, false, "command", "args");
            _settings.Save();
        }

        [TearDown()]
        public void TearDown()
        {
            _settings = null;
            _resolutions = null;
            File.Delete(fileName);
        }

        [Test()]
        public void SettingsTest()
        {
            Assert.NotNull(_settings);
        }

        [Test()]
        public void LoadTest()
        {
            Assert.AreEqual(_settings, Settings.Load());
        }

        [Test()]
        public void SaveTest()
        {
            _settings.Save();
            Assert.AreEqual(_settings, Settings.Load());
        }

        [Test()]
        public void CopyTest()
        {
            Assert.AreEqual(_settings, _settings.Copy());
            Assert.AreNotSame(_settings, _settings.Copy());
            Assert.AreNotSame(_settings.Copy(), _settings.Copy());
        }
    }
}