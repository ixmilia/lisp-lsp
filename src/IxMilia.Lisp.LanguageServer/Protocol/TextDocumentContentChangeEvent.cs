namespace IxMilia.Lisp.LanguageServer.Protocol
{
    public class TextDocumentContentChangeEvent
    {
        public Range Range { get; set; }
        public uint? RangeLength { get; set; }
        public string Text { get; set; }
    }
}
