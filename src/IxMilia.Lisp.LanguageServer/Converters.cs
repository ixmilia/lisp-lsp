using System;
using IxMilia.Lisp.LanguageServer.Protocol;

namespace IxMilia.Lisp.LanguageServer
{
    public class Converters
    {
        public static string PathFromUri(string uriString)
        {
            var uri = new Uri(uriString);
            return uri.LocalPath.Substring(1);
        }

        public static LispSourcePosition SourcePositionFromPosition(Position position)
        {
            return new LispSourcePosition((int)position.Line + 1, (int)position.Character + 1);
        }
    }
}
