using Xunit;

namespace IxMilia.Lisp.LanguageServer.Test
{
    public class LanguageServiceTests
    {
        [Theory]
        [InlineData("file:///c%3A/path/to/file.lisp", "c:/path/to/file.lisp")]
        [InlineData("file:///usr/test/path/to/file.lisp", "/usr/test/path/to/file.lisp")]
        [InlineData("untitled:Untitled-1", "Untitled-1")]
        public void PathCanBeExtractedFromUri(string uri, string expectedPath)
        {
            var actualPath = Converters.PathFromUri(uri);
            Assert.Equal(expectedPath, actualPath);
        }
    }
}
