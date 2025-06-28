using System.Text;

namespace AG.UrlHelpers
{

    public static class UrlHelpers    
    {

        public static string ConcatenateUrl(params string[] segments)
        {
            if (segments is null || segments.Length == 0)
                return string.Empty;

            var sb = new StringBuilder();
            ReadOnlySpan<char> queryAndAnchor = default;
            bool preserveRoot = false;

            for (int i = 0; i < segments.Length; i++)
            {
                var segment = segments[i];
                if (string.IsNullOrWhiteSpace(segment))
                    continue;

                ReadOnlySpan<char> span = segment.AsSpan();

                // Preserve leading "/" if first non-empty segment starts with it
                if (sb.Length == 0 && span.StartsWith("/".AsSpan()))
                    preserveRoot = true;

                // Handle the last segment – extract ?query or #anchor
                if (i == segments.Length - 1)
                {
                    int queryStart = span.IndexOfAny('?', '#');
                    if (queryStart >= 0)
                    {
                        queryAndAnchor = span.Slice(queryStart);
                        span = span.Slice(0, queryStart);
                    }
                }

                // Absolute URLs override previous path
                if (span.StartsWith("http://".AsSpan(), StringComparison.OrdinalIgnoreCase) ||
                    span.StartsWith("https://".AsSpan(), StringComparison.OrdinalIgnoreCase) ||
                    span.StartsWith("//".AsSpan(), StringComparison.OrdinalIgnoreCase))
                {
                    sb.Clear();
                    sb.Append(span.TrimEnd('/'));
                    preserveRoot = false; // reset if absolute URL detected
                    continue;
                }

                span = span.Trim('/');

                if (sb.Length > 0 && sb[^1] != '/' && !span.IsEmpty)
                    sb.Append('/');

                sb.Append(span);
            }

            if (!queryAndAnchor.IsEmpty)
                sb.Append(queryAndAnchor);

            if (preserveRoot && (sb.Length == 0 || sb[0] != '/'))
                sb.Insert(0, '/');

            return sb.ToString();
        }
    }
}
