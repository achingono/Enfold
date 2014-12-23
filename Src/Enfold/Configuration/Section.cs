using System;
using System.Configuration;

namespace Enfold.Configuration
{
    public class Section : ConfigurationSection
    {
        [ConfigurationProperty("scriptPath",
            DefaultValue = "~/Scripts/Views")]
        public string ScriptPath
        {
            get
            {
                return Convert.ToString(this["scriptPath"]);
            }
        }

        [ConfigurationProperty("scriptExtension",
            DefaultValue = ".js")]
        public string ScriptExtension
        {
            get
            {
                return Convert.ToString(this["scriptExtension"]);
            }
        }

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