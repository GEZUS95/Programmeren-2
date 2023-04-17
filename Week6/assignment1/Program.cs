using System;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            ChessPiece[,] board = new ChessPiece[8, 8];
            InitChessboard(board);
            DisplayChessboard(board);
            PlayChess(board);

            Console.ReadKey();
        }

        void InitChessboard(ChessPiece[,] chessboard)
        {
            for (int r = 0; r < chessboard.GetLength(0); r++)
            {
                for (int k = 0; k < chessboard.GetLength(1); k++)
                {
                    chessboard[r, k] = null;
                }
            }
            PutChessPieces(chessboard);
        }

        void DisplayChessboard(ChessPiece[,] chessboard)
        {
            for (int r = 0; r < chessboard.GetLength(0) + 1; r++)
            {
                for (int k = 0; k < chessboard.GetLength(1) + 1; k++)
                {
                    if ((r != 8) && (k != 0))
                    {
                        // check if field is odd or even then set BGcolor
                        if ((r + (k - 1)) % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        }

                        DisplayChessPiece(chessboard[r, k - 1]);

                        // reset color
                        Console.ResetColor();
                    }
                    // letters at the botom of the board
                    if (r == 8)
                    {
                        switch (k)
                        {
                            case 1: Console.Write(" a "); break;
                            case 2: Console.Write(" b "); break;
                            case 3: Console.Write(" c "); break;
                            case 4: Console.Write(" d "); break;
                            case 5: Console.Write(" e "); break;
                            case 6: Console.Write(" f "); break;
                            case 7: Console.Write(" g "); break;
                            case 8: Console.Write(" h "); break;
                            default: Console.Write(""); break;
                        }
                    }

                    if (k == 0)
                    {
                        switch (r)
                        {
                            case 0: Console.Write("8 "); break;
                            case 1: Console.Write("7 "); break;
                            case 2: Console.Write("6 "); break;
                            case 3: Console.Write("5 "); break;
                            case 4: Console.Write("4 "); break;
                            case 5: Console.Write("3 "); break;
                            case 6: Console.Write("2 "); break;
                            case 7: Console.Write("1 "); break;
                            case 8: Console.Write("  "); break;
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        void PutChessPieces(ChessPiece[,] chessboard)
        {
            ChessPieceType[] order = { ChessPieceType.Rook, ChessPieceType.Knight, ChessPieceType.Bishop, ChessPieceType.Queen, ChessPieceType.King, ChessPieceType.Bishop, ChessPieceType.Knight, ChessPieceType.Rook };

            for (int col = 0; col < 8; col++)
            { // put black chess pieces ('at the top') 
                chessboard[0, col] = new ChessPiece(order[col], ChessPieceColor.Black);
                chessboard[1, col] = new ChessPiece(ChessPieceType.Pawn, ChessPieceColor.Black); // put white pieces ('at the bottom') 
                chessboard[6, col] = new ChessPiece(ChessPieceType.Pawn, ChessPieceColor.White);
                chessboard[7, col] = new ChessPiece(order[col], ChessPieceColor.White);
            }
        }

        void DisplayChessPiece(ChessPiece chessPiece)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (chessPiece == null)
            {
                Console.Write(" ");
                return;
            }
            // set the font color, depending on the color of the chess piece 
            if (chessPiece.color == ChessPieceColor.White) { Console.ForegroundColor = ConsoleColor.White; }
            else if (chessPiece.color == ChessPieceColor.Black) { Console.ForegroundColor = ConsoleColor.Black; }
            else {Console.ForegroundColor = ConsoleColor.Cyan; } // impossible 
                                                              // print the chess piece
            string text = chessPiece.type.ToString();
            if ((chessPiece.type != ChessPieceType.King) && (chessPiece.type != ChessPieceType.Queen))
            {
                text = text.ToLower();
            }
            else
            {
                Console.Write("   ");
            }
            Console.Write(" {0} ", text[0]);
        }

        Position String2Position(string pos)
        {
            pos = pos.ToLower();

            Position p = new Position();
            try
            {
                p.col = pos[0] - 'a';
                p.row = 8 - int.Parse(pos[1].ToString());

                if ((p.row < 0) || (p.col < 0) || (p.row >= 8) || (p.col >= 8))
                {
                    throw new Exception("invalid position: " + pos);
                }
                return p;
            }
            catch (Exception e)
            {
                throw new Exception("invalid position: " + pos);
            }
        }

        void PlayChess(ChessPiece[,] chessboard)
        {
            Console.WriteLine("Enter move (e.g. a2 a3): ");
            string input = Console.ReadLine();
            while (input != "stop")
            {
                try
                {
                    string[] positions = input.Split(' ');
                    Position from = String2Position(positions[0]);
                    Position to = String2Position(positions[1]);
                    CheckMove(chessboard, from, to);
                    DoMove(chessboard, from, to);
                    Console.Clear();
                    DisplayChessboard(chessboard);

                    Console.WriteLine("move from {0} to {1}\n", positions[0], positions[1]);
                }

                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                    Console.ResetColor();
                }


                Console.WriteLine("Enter move (e.g. a2 a3): ");
                input = Console.ReadLine();
            }
        }


        void DoMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            //value of from to pos and then empty from
            chessboard[to.row, to.col] = chessboard[from.row, from.col];
            chessboard[from.row, from.col] = null;
        }


        void CheckMove(ChessPiece[,] chessboard, Position from, Position to)
        {
            ChessPiece chesspiece1 = chessboard[from.row, from.col];
            ChessPiece chesspiece2 = chessboard[to.row, to.col];
            if (chesspiece1 == null) throw new Exception("No chess piece at from-position");
            if (chesspiece2 != null)
            { // other piece must be other color 
                if (chesspiece1.color == chesspiece2.color) throw new Exception("Can not take a chess piece of same color");
            }
            int ver = Math.Abs(from.row - to.row); int hor = Math.Abs(from.col - to.col); // no move at all?
            if ((ver == 0) && (hor == 0))
                throw new Exception("No movement");
            bool validMove = false;
            switch (chesspiece1.type)
            {
                case ChessPieceType.Rook:
                    validMove = (hor * ver == 0);
                    break;
                case ChessPieceType.Knight:
                    validMove = (hor * ver == 2);
                    break;
                case ChessPieceType.Bishop:
                    validMove = (hor == ver);
                    break;
                case ChessPieceType.King:
                    validMove = ((hor == 1) || (ver == 1));
                    break;
                case ChessPieceType.Queen: // rook and bishop move combined 
                    validMove = ((hor * ver == 0) || (hor == ver)); 
                    break; 
                case ChessPieceType.Pawn:
                                           // can go diagonally when taking opponent's chesspiece...
                    if (chesspiece2 != null)
                        validMove = ((hor == 1) && (ver == 1));
                    else
                        validMove = ((hor == 0) && ((ver == 1) || (ver == 2))); break;
                default:
                    validMove = false;
                    break;
            }
            if (!validMove)
                throw new Exception("Invalid move for chess piece " + chesspiece1.type);
        }


    }

}

