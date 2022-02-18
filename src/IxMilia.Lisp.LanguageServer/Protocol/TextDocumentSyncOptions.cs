using Newtonsoft.Json;

namespace IxMilia.Lisp.LanguageServer.Protocol
{
    public class TextDocumentSyncOptions
    {
        public bool OpenClose { get; }

        [JsonConverter(typeof(ForceDefaultConverter))]
        public TextDocumentSyncKind Change { get; }

        public TextDocumentSyncOptions()
        {
            OpenClose = true;
            Change = TextDocumentSyncKind.Full;
        }
    }
}
