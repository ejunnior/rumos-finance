namespace Restaurant.Tests.Infrastructure.Api
{
    using System;
    using System.Collections.Specialized;
    using System.Text;

    internal static class NameValueCollectionExtensions
    {
        internal static string ToQueryString(this NameValueCollection collection)
        {
            if (collection == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            foreach (string key in collection.Keys)
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    continue;
                }

                var values = collection.GetValues(key);
                if (values == null)
                {
                    continue;
                }

                foreach (var value in values)
                {
                    sb.Append(sb.Length == 0 ? "?" : "&");
                    sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));
                }
            }

            return sb.ToString();
        }
    }
}