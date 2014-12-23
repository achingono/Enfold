using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PolicyManager.Web
{
    public static class HttpRequestExtensions
    {
        private static IEnumerable<string> scriptFileNames = new[] { string.Empty, "/default" };

        /// <summary>
        /// Generate the bundle name associated with this request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string Bundle(this HttpRequestBase request)
        {
            var routeData = request.RequestContext.RouteData;
            // first create a list of segments that make up a path
            var bundleName = string.Format("~/bundles/{0}/{1}/{2}",
                                    routeData.DataTokens["area"],
                                    routeData.Values["controller"],
                                    routeData.Values["action"]
                                )
                                .Replace("//", "/")
                                .ToLowerInvariant();

            if (bundleName.EndsWith("/"))
            {
                return bundleName.Substring(0, bundleName.Length - 1);
            }
            return bundleName;
        }

        /// <summary>
        /// Generate script paths based on current route data
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns></returns>
        private static IEnumerable<string> Scripts(this HttpRequestBase request)
        {
            var routeData = request.RequestContext.RouteData;
            // first create a list of segments that make up a path
            return new[]
            {
                routeData.DataTokens["area"],
                routeData.Values["controller"],
                routeData.Values["action"]
            }
                // then generate multiple paths made up of those segments
            .Aggregate(new List<string>(), (list, item) =>
            {
                // add a new item to the list
                // made up of a combination of
                // the last item and the current item
                list.Add(string.Format("{0}/{1}", list.DefaultIfEmpty("").Last(), item));

                // return list to the aggregation
                // so items can be appended
                return list;
            })
                // then generate multiple paths where the file name is appended
            .SelectMany(path => scriptFileNames.Select(name => string.Format("{0}{1}", path, name)))
                // then append the prefix and extension
            .Select(path => string.Format("~/scripts/views{0}.js", path))
                // then ensure the file exists
            .Where(path => HostingEnvironment.VirtualPathProvider.FileExists(path));
        }
    }
}