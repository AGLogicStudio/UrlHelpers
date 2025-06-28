

using Xunit;
using AG.UrlHelpers;
namespace UrlHelpers.Tests
{

    public class UrlHelpersTests
    {
        [Theory]
        [InlineData(new[] { "http://example.com", "api", "v1", "resource" }, "http://example.com/api/v1/resource")]
        [InlineData(new[] { "http://example.com/", "/api/", "v1/", "/resource" }, "http://example.com/api/v1/resource")]
        [InlineData(new[] { "https://domain.org", "", "path", null, "file.html" }, "https://domain.org/path/file.html")]
        [InlineData(new[] { "http://base.com/oldpath", "newsegment", "https://another.com/new/root", "file.json" }, "https://another.com/new/root/file.json")]
        [InlineData(new[] { "//cdn.net", "assets", "image.png" }, "//cdn.net/assets/image.png")]
        [InlineData(new[] { "http://api.com", "data", "items?id=123&name=test#section" }, "http://api.com/data/items?id=123&name=test#section")]
        [InlineData(new[] { "https://www.example.net/", "path/to/", "/subfolder/", "file.aspx?query=abc#top" }, "https://www.example.net/path/to/subfolder/file.aspx?query=abc#top")]
        [InlineData(new[] { "example.com", "products", "item1" }, "example.com/products/item1")]
        [InlineData(new[] { "/", "app", "pages", "home.html" }, "/app/pages/home.html")]
        [InlineData(new[] { "http://mysite.com/old/path", "/new/base", "item.xml" }, "http://mysite.com/old/path/new/base/item.xml")]
        [InlineData(new[] { "http://test.com/index.html?param=value#anchor" }, "http://test.com/index.html?param=value#anchor")]
        [InlineData(new[] { "", null, "" }, "")]
        [InlineData(new[] { "http://base.com/path", "api/endpoint" }, "http://base.com/path/api/endpoint")]
        [InlineData(new[] { "http://base.com", "/api/endpoint" }, "http://base.com/api/endpoint")]
        public void ConcatenateUrl_ReturnsExpectedCombinedUrl(string[] segments, string expected)
        {
            // Act
            var result = AG.UrlHelpers.UrlHelpers.ConcatenateUrl(segments);

            // Assert
            Assert.Equal(expected, result);
        }
    }


}
