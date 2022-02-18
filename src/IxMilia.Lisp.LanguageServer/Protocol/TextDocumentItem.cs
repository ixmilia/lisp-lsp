namespace IxMilia.Lisp.LanguageServer.Protocol
{
    public class TextDocumentItem
    {
        public string Uri { get; set; }
        public string LanguageId { get; set; }
        public int Version { get; set; }
        public string Text { get; set; }
    }
}
