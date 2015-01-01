using Enfold.Configuration;
using System.Web;

namespace PolicyManager.Web
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// Generate the bundle name associated with this request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string Bundle(this HttpRequestBase request)
        {
            var routeData = request.RequestContext.RouteData;
            // first create a list of segments that make up a path
            return string.Format("{0}/{1}/{2}/{3}",
                                    Settings.Current.BundlePrefix,
                                    routeData.DataTokens["area"],
                                    routeData.Values["controller"],
                                    routeData.Values["action"]
                                )
                                .Replace("//", "/")
                                .TrimEnd(new[] { '/' })
                                .ToLowerInvariant();
        }
    }
}