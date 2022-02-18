using System.Collections.Generic;

namespace IxMilia.Lisp.LanguageServer.Protocol
{
    public class DidChangeTextDocumentParams
    {
        public VersionedTextDocumentIdentifier TextDocument { get; set; }
        public List<TextDocumentContentChangeEvent> ContentChanges { get; } = new List<TextDocumentContentChangeEvent>();
    }
}
