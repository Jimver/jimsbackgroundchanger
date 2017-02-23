using System;
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
        private Settings settings;
        private List<Resolution> resolutions;

        [SetUp()]
        public void StartUp()
        {
            resolutions = new List<Resolution>();
            resolutions.Add(new Resolution(1920, 1080, null));
            resolutions.Add(new Resolution(3440, 1440, null));
            settings = new Settings(resolutions, false);
            settings.Save();
        }

        [TearDown()]
        public void TearDown()
        {
            settings = null;
            resolutions = null;
            File.Delete(fileName);
        }

        [Test()]
        public void SettingsTest()
        {
            Assert.NotNull(settings);
        }

        [Test()]
        public void LoadTest()
        {
            Assert.AreEqual(settings, Settings.Load());
        }

        [Test()]
        public void SaveTest()
        {
            settings.Save();
            Assert.AreEqual(settings, Settings.Load());
        }
    }
}