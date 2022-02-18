using System.Collections.Generic;
using System.IO;
using System.Text;
using IxMilia.Lisp.LanguageServer.Protocol;
using StreamJsonRpc;

namespace IxMilia.Lisp.LanguageServer
{
    public class LanguageServer
    {
        private JsonRpc _rpc;
        private LispRepl _repl;
        private Dictionary<string, string> _documentContents = new Dictionary<string, string>();

        public LanguageServer(Stream sendingStream, Stream receivingStream)
        {
            var encoding = new UTF8Encoding(false);
            var formatter = new JsonMessageFormatter(encoding);
            Serializer.ConfigureSerializer(formatter.JsonSerializer);
            var messageHandler = new HeaderDelimitedMessageHandler(sendingStream, receivingStream, formatter);
            _rpc = new JsonRpc(messageHandler, this);
            _repl = new LispRepl();
        }

        public void Start()
        {
            _rpc.StartListening();
        }

        [JsonRpcMethod("initialize", UseSingleObjectParameterDeserialization = true)]
        public InitializeResult Initialize(InitializeParams param)
        {
            return new InitializeResult();
        }

        [JsonRpcMethod("textDocument/didOpen", UseSingleObjectParameterDeserialization = true)]
        public void TextDocumentDidOpen(DidOpenTextDocumentParams param)
        {
            var path = Converters.PathFromUri(param.TextDocument.Uri);
            _documentContents[path] = param.TextDocument.Text;
        }

        [JsonRpcMethod("textDocument/hover", UseSingleObjectParameterDeserialization = true)]
        public Hover TextDocumentHover(HoverParams param)
        {
            var path = Converters.PathFromUri(param.TextDocument.Uri);
            var position = Converters.SourcePositionFromPosition(param.Position);
            if (_documentContents.TryGetValue(path, out var code))
            {
                var obj = _repl.GetObjectAtLocation(code, position);
                var markdown = _repl.GetMarkdownDisplayFromSourceObject(obj);
                return new Hover(new MarkupContent(MarkupKind.Markdown, markdown));
            }

            return null;
        }
    }
}
