using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

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
            private readonly int _width;
            private readonly int _height;

            // Folders
            private readonly List<string> _folders;

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
            public int Width => _width;

            // Getter and setter for height.
            public int Height => _height;

            // Getter and setter for folders.
            public List<string> Folders => _folders;

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
        private readonly List<Resolution> _resolutions;
        private readonly bool _startup;
        private readonly string _cliCommand;
        private readonly string _cliArgs;

        /// <summary>
        /// Constructor of settings
        /// </summary>
        /// <param name="resolutions">Resolution list</param>
        /// <param name="startup">startup boolean</param>
        /// <param name="cliCommand">cli command</param>
        /// <param name="cliArgs">cli args</param>
        public Settings(List<Resolution> resolutions, bool startup, string cliCommand, string cliArgs)
        {
            _resolutions = resolutions;
            _startup = startup;
            _cliCommand = cliCommand;
            _cliArgs = cliArgs;
        }

        /// <summary>
        /// Getter and setter for resolutions.
        /// </summary>
        public List<Resolution> Resolutions => _resolutions;

        /// <summary>
        /// Getter and setter for startup
        /// </summary>
        public bool Startup => _startup;

        /// <summary>
        /// Getter and setter for the cli command
        /// </summary>
        public string CliCommand => _cliCommand;

        /// <summary>
        /// Getter and setter for the args
        /// </summary>
        public string CliArgs => _cliArgs;

        /// <summary>
        /// Load function.
        /// </summary>
        /// <returns>Returns the settings according to the settings file.</returns>
        public static Settings Load()
        {
            // Create an empty settings file if it doesn't exist.
            if (!File.Exists(fileName))
            {
                new Settings(new List<Resolution>(), false, "", "").Save();
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

        public Settings Copy()
        {
            return new Settings(_resolutions, _startup, _cliCommand, _cliArgs);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Settings)obj);
        }

        protected bool Equals(Settings other)
        {
            return _resolutions.SequenceEqual(other._resolutions) && _startup == other._startup &&
                   string.Equals(_cliCommand, other._cliCommand) && string.Equals(_cliArgs, other._cliArgs);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_resolutions != null ? _resolutions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _startup.GetHashCode();
                hashCode = (hashCode * 397) ^ (_cliCommand != null ? _cliCommand.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_cliArgs != null ? _cliArgs.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Resolutions + ", " + Startup + ", " + CliCommand + ", " + CliArgs;
        }
    }
}