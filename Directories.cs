using System;

namespace windows_theodolite
{
    public static class Directories
    {
        /// <summary>
        /// Gets the user directory.
        /// </summary>
        public static string UserDirectory => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Knapp Air-to-surface Impact Measurer\\";

        /// <summary>
        /// Gets the application directory.
        /// </summary>
        public static string ApplicationDirectory => AppDomain.CurrentDomain.BaseDirectory;
    }
}
