using System;
using System.Configuration;

namespace Enfold.Configuration
{
    public class Section : ConfigurationSection
    {
        /// <summary>
        /// The root folder where javascript files are contained.
        /// </summary>
        [ConfigurationProperty("scriptPath",
            DefaultValue = "~/Scripts/Views")]
        public string ScriptPath
        {
            get
            {
                return Convert.ToString(this["scriptPath"]);
            }
        }

        /// <summary>
        /// The Javascript file extension
        /// </summary>
        [ConfigurationProperty("scriptExtension",
            DefaultValue = ".js")]
        public string ScriptExtension
        {
            get
            {
                return Convert.ToString(this["scriptExtension"]);
            }
        }

        /// <summary>
        /// The default file name
        /// </summary>
        [ConfigurationProperty("defaultScriptFileName",
            DefaultValue = "default")]
        public string DefaultScriptFileName
        {
            get
            {
                return Convert.ToString(this["defaultScriptFileName"]);
            }
        }

        /// <summary>
        /// The prefix used when generating bundle names
        /// </summary>
        [ConfigurationProperty("bundlePrefix",
            DefaultValue = "~/bundles")]
        public string BundlePrefix
        {
            get
            {
                return Convert.ToString(this["bundlePrefix"]);
            }
        }
    }
}