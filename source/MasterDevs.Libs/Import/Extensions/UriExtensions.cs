using System.Collections.Generic;

namespace System
{
    public static class UriExtensions
    {
        public static Dictionary<string, string> QueryString(this Uri uri)
        {
            if (null == uri) return new Dictionary<string, string>();

            var query = uri.Query;

            return query.QueryString();
        }
    }
}