namespace IxMilia.Lisp.LanguageServer.Protocol
{
    public class ServerCapabilities
    {
        public TextDocumentSyncOptions TextDocumentSync { get; set; }
        public bool HoverProvider { get; set; }

        public ServerCapabilities()
        {
            TextDocumentSync = new TextDocumentSyncOptions();
            HoverProvider = true;
        }
    }
}
