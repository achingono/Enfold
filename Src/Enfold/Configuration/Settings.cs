using System.Configuration;

namespace Enfold.Configuration
{
    public sealed class Settings
    {
        private static Section section;

        public static Section Current
        {
            get
            {
                return section;
            }
        }

        #region Static Constructor

        static Settings()
        {
            section = (Section)ConfigurationManager.GetSection("enfold");
        }

        #endregion Static Constructor
    }
}