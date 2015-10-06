using Enfold.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;

namespace Enfold.Javascript
{
    public static class BundleExtensions
    {
        /// <summary>
        /// The filter used when searching for javascript files
        /// </summary>
        private readonly static string fileFilter = string.Format("*{0}", Settings.Current.ScriptExtension);        // *.js
        /// <summary>
        /// The default file name
        /// </summary>
        private readonly static string defaultFile = string.Format("{0}{1}",
                                                                    Settings.Current.DefaultScriptFileName,
                                                                    Settings.Current.ScriptExtension);            // default.js
        /// <summary>
        /// The file names used when generating a script bundle
        /// </summary>
        private readonly static IEnumerable<string> scriptFileNames = new[] { string.Empty, 
                                                                              Settings.Current.ScriptExtension, 
                                                                              string.Format("/{0}", defaultFile) };

        /// <summary>
        /// Adds groups of Javascript files as bundles to the bundle collection
        /// </summary>
        /// <param name="bundles">The collection of bundles to be appended</param>
        public static void RegisterScriptBundles(this BundleCollection bundles)
        {
            // the starting point to search for javascript files
            var rootPath = HostingEnvironment.MapPath(Settings.Current.ScriptPath);
            // the list of all files in the directory tree
            var allScripts = rootPath.ScriptFiles();

            foreach (var script in allScripts.Where(x => !x.IsDefaultFile()))
            {
                // 1. remove the extension
                // 2. replace the root path with the bundle prefix
                // 3. convert all characters to lowercase
                var bundleName = script.Substring(0, script.Length - Settings.Current.ScriptExtension.Length)
                                       .Replace(Settings.Current.ScriptPath, Settings.Current.BundlePrefix)
                                       .ToLowerInvariant();

                var bundlePaths = script.RelatedPaths(allScripts).ToArray();

                var bundle = new ScriptBundle(bundleName);
                bundle.Include(bundlePaths);
                bundles.Add(bundle);
            }
        }

        /// <summary>
        /// Generate a list of all files in a folder and subfolders
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static IEnumerable<string> ScriptFiles(this string path)
        {
            return Directory.GetFiles(path, fileFilter, SearchOption.AllDirectories).Select(ToVirtualPath);
        }

        /// <summary>
        /// Convert the physical path to a relative path
        /// </summary>
        /// <param name="path">The physical path</param>
        /// <returns>The relative path</returns>
        private static string ToVirtualPath(this string path)
        {
            return string.Format("~/{0}", path.Substring(HttpRuntime.AppDomainAppPath.Length))
                         .Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        /// <summary>
        /// Generate a list of script files that should be included in the same bundle
        /// </summary>
        /// <param name="path">The path to the script file</param>
        /// <param name="paths">The list of all javascript files located in the file system</param>
        /// <returns>A collection of files that should be included in the same bundle as the supplied file</returns>
        private static IEnumerable<string> RelatedPaths(this string path, IEnumerable<string> paths)
        {
            // first create a list of segments that make up a path
            return path.Split(Path.AltDirectorySeparatorChar)
                // then generate multiple paths made up of those segments
            .Aggregate(new List<string>(), (list, item) =>
            {
                // add a new item to the list
                // made up of a combination of
                // the last item and the current item
                if (list.Count() <= 0)
                {
                    list.Add(item);
                }
                else
                {
                    list.Add(string.Format("{0}/{1}", list.Last(), item));
                }

                // return list to the aggregation
                // so items can be appended
                return list;
            })
                // then generate multiple paths where the file name is appended
            .SelectMany(prefix => scriptFileNames.Select(name => string.Format("{0}{1}", prefix, name)))
                // then ensure the file exists
            .Where(p => paths.Contains(p));
        }

        /// <summary>
        /// Checks if the path points to a default file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool IsDefaultFile(this string path)
        {
            return Regex.IsMatch(path, string.Format("{0}$", defaultFile), RegexOptions.IgnoreCase);
        }
    }
}
