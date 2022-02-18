namespace IxMilia.Lisp.LanguageServer.Protocol
{
    public class Position
    {
        public uint Line { get; set; }
        public uint Character { get; set; }

        public Position(uint line, uint character)
        {
            Line = line;
            Character = character;
        }
    }
}
