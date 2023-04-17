namespace assignment1
{
    public class ChessPiece
    {
        public ChessPieceColor color;
        public ChessPieceType type;

        public ChessPiece(ChessPieceType type, ChessPieceColor color)
        {
            this.color = color;
            this.type = type;

        }
    }
}
