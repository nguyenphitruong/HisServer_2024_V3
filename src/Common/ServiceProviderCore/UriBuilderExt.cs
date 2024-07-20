using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ServiceProvider
{
    public class UriBuilderExt
    {
        private NameValueCollection collection;
        private UriBuilder builder;

        public UriBuilderExt(string uri)
        {
            builder = new UriBuilder(uri);
            collection = HttpUtility.ParseQueryString(string.Empty);
        }

        public void AddParameter(string key, string value)
        {
            collection.Add(key, value);
        }

        public Uri Uri
        {
            get
            {
                builder.Query = collection.ToString();
                return builder.Uri;
            }
        }


        //public static Uri GetUriWithparameters(this Uri uri, Dictionary<string, string> queryParams = null, int port = -1)
        //{
        //    var builder = new UriBuilder(uri);
        //    builder.Port = port;
        //    if (null != queryParams && 0 < queryParams.Count)
        //    {
        //        var query = HttpUtility.ParseQueryString(builder.Query);
        //        foreach (var item in queryParams)
        //        {
        //            query[item.Key] = item.Value;
        //        }
        //        builder.Query = query.ToString();
        //    }
        //    return builder.Uri;
        //}

        //public static string GetUriWithparameters(string uri, Dictionary<string, string> queryParams = null, int port = -1)
        //{
        //    var builder = new UriBuilder(uri);
        //    builder.Port = port;
        //    if (null != queryParams && 0 < queryParams.Count)
        //    {
        //        var query = HttpUtility.ParseQueryString(builder.Query);
        //        foreach (var item in queryParams)
        //        {
        //            query[item.Key] = item.Value;
        //        }
        //        builder.Query = query.ToString();
        //    }
        //    return builder.Uri.ToString();
        //}

    }
}
