using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace JimsBackgroundChanger
{
    /// <summary>
    /// Settings class.
    /// </summary>
    [Serializable]
    public class Settings
    {
        /// <summary>
        /// Resolution class for storing folder according to resolution.
        /// </summary>
        [Serializable]
        public class Resolution
        {
            // Dimensions
            private int _width;
            private int _height;

            // Folders
            private List<string> _folders;

            /// <summary>
            /// Constructor of a resolution.
            /// </summary>
            /// <param name="width">Width in px.</param>
            /// <param name="height">Height in px.</param>
            /// <param name="folders">List of folders, can be null.</param>
            public Resolution(int width, int height, List<string> folders)
            {
                _width = width;
                _height = height;
                _folders = folders;
            }

            // Getter and setter for width.
            public int Width
            {
                get { return _width; }
                set { _width = value; }
            }

            // Getter and setter for height.
            public int Height
            {
                get { return _height; }
                set { _height = value; }
            }

            // Getter and setter for folders.
            public List<string> Folders
            {
                get { return _folders; }
                set { _folders = value; }
            }

            /// <summary>
            /// ToString that only takes width and height into account.
            /// </summary>
            /// <returns>The width plus an 'x' plus the height.</returns>
            public override string ToString()
            {
                return Width + "x" + Height;
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (obj.GetType() == typeof(Resolution))
                {
                    Resolution other = (Resolution) obj;
                    if (other.Width == Width && other.Height == Height) return true;
                }
                return false;
            }

            protected bool Equals(Resolution other)
            {
                return _width == other._width && _height == other._height;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = _width;
                    hashCode = (hashCode * 397) ^ _height;
                    hashCode = (hashCode * 397) ^ (_folders != null ? _folders.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        // Fields
        private static string fileName = "settings.jbc";
        private List<Resolution> _resolutions;
        private bool _startup;

        public Settings(List<Resolution> resolutions, bool startup)
        {
            _resolutions = resolutions;
            _startup = startup;
        }

        /// <summary>
        /// Getter and setter for resolutions.
        /// </summary>
        public List<Resolution> Resolutions
        {
            get { return _resolutions; }
            set { _resolutions = value; }
        }

        public bool Startup
        {
            get { return _startup; }
            set { _startup = value; }
        }

        /// <summary>
        /// Load function.
        /// </summary>
        /// <returns>Returns the settings according to the settings file.</returns>
        public static Settings Load()
        {
            // Create an empty settings file if it doesn't exist.
            if (!File.Exists(fileName))
            {
                new Settings(new List<Resolution>(), false).Save();
            }

            // Create stream and Settings.
            Stream stream = null;

            try
            {
                stream = File.Open(fileName, FileMode.Open);

                // Create the formatter.
                BinaryFormatter formatter = new BinaryFormatter();

                // Serialize this Settings class and return it.
                return (Settings)formatter.Deserialize(stream);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            finally
            {
                // Close the stream if it exists.
                stream?.Close();
            }
        }

        /// <summary>
        /// Save function, saves to the fileName location.
        /// </summary>
        public void Save()
        {
            // Open the stream
            Stream stream = File.Open(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            // Serialize this Settings class.
            formatter.Serialize(stream, this);

            // Close the stream.
            stream.Close();
        }
    }
}