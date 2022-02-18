namespace IxMilia.Lisp.LanguageServer.Protocol
{
    public class TextDocumentSyncOptions
    {
        public bool OpenClose { get; }
        public TextDocumentSyncKind Change { get; }

        public TextDocumentSyncOptions()
        {
            OpenClose = true;
            Change = TextDocumentSyncKind.Full;
        }
    }
}
