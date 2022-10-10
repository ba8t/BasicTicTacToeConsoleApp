using System;

namespace TicTacToe
{
    class Program
    {
        static void Main()
        {
            string whoWinner = "No One";
            char whoTurn = 'X';
            int movesPlayed = 0;
            char[,] board = new char[3, 3];

            Initialize(board);
            while (whoWinner == "No One")
            {
                Input(board, ref whoTurn, ref movesPlayed);
                Console.Clear();

                CheckDone(board, ref movesPlayed, ref whoWinner, ref whoTurn);
            }
        }
        static void Input(char[,] board,ref char whoTurn, ref int movesPlayed)
        {
            while (whoTurn == 'X')
            {
                try
                {
                    string printDirection = "row";
                    Print(board, printDirection);
                    Console.Write("\nPlease enter row: ");
                    int row3 = Convert.ToInt32(Console.ReadLine());
                    row3--;
                    Console.Clear();

                    printDirection = "col";
                    Print(board, printDirection);
                    Console.Write($"\nPlease enter row: {row3 + 1}");
                    Console.Write("\n\nPlease enter col: ");
                    int col3 = Convert.ToInt32(Console.ReadLine());
                    col3--;

                    // Checks if Player entered in 0 or >3
                    if (row3 == -1 || row3 >= 3 || col3 == -1 || col3 >= 3)
                    {
                        Console.WriteLine("\n ERROR: Number has to be 1-3! \n\nPress Space to understand.");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else
                    {
                        // Checks if Player entered in a used spot
                        if (board[row3, col3] == 'X' || board[row3, col3] == '0')
                        {
                            Console.WriteLine($"\n ERROR: The spot {row3 + 1}, {col3 + 1} is already taken by: {board[row3, col3]} \n\nPress Space to understand. ");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        else
                        {
                            board[row3, col3] = 'X';
                            whoTurn = '0';
                            movesPlayed++;
                        }
                    }
                }
                // Catches if Player enters in nothing
                catch (FormatException)
                {
                    Console.WriteLine("\n ERROR: You did not type anything, Try entering a number from 1-3. \n\nPress Space to understand. ");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
            //Computer
            if (movesPlayed != 9)
            {
                var row = new Random();
                var col = new Random();

                int row2 = row.Next(0, 3);
                int col2 = col.Next(0, 3);
                while (board[row2, col2] == 'X' || board[row2, col2] == '0')
                {
                    row2 = row.Next(0, 3);
                    col2 = col.Next(0, 3);
                }

                board[row2, col2] = '0';
                whoTurn = 'X';
                movesPlayed++;
            }
        }
        static void Initialize(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }
        static void Print(char[,] board, string printDirection)
        {
            if (printDirection == "col")
            {
                Console.WriteLine("   1 | 2 | 3  ");
            }
            else
            {
                Console.WriteLine();
            }
            for (int row = 0; row < 3; row++)
            {
                Console.Write(" |---+---+---|");
                if (printDirection == "row")
                {
                    Console.Write($"\n{row + 1}" );
                    Console.Write("| ");
                }
                else
                {
                    Console.Write("\n | ");
                }
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
            Console.Write(" |---+---+---|\n");
        }
        static void CheckDone(char[,] board, ref int movesPlayed, ref string whoWinner, ref char whoTurn) 
        {
            string printDirection = "";
            if (movesPlayed == 9)
            {
                Print(board, printDirection);
                Console.Write($"\n\nTie! \n\nEnter in \"y\" to play again, enter in \"n\" to quit: ");
                string? answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.Clear();
                    whoWinner = "No One";
                    whoTurn = 'X';
                    movesPlayed = 0;
                    Initialize(board);
                }
                else
                {
                    whoWinner = "no one";
                }
            }
            // Probably very inefficent but what ever
            for (int t = 0; t <= 1; t++)
            {
                char player = 'X';
                if (t == 1)
                {
                    player = '0';
                }
                if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player)
                {
                    whoWinner = player.ToString();
                }
                else if (board[1, 0] == player && board[1, 1] == player && board[1,2] == player)
                {
                    whoWinner = player.ToString();
                }
                else if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player)
                {
                    whoWinner = player.ToString();
                }
                else if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player)
                {
                    whoWinner = player.ToString();
                }
                else if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player)
                {
                    whoWinner = player.ToString();
                }
                else if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player)
                {
                    whoWinner = player.ToString();
                }
                else if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                {
                    whoWinner = player.ToString();
                }
                else if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                {
                    whoWinner = player.ToString();
                }
            }
            if (whoWinner == "X" || whoWinner == "0")
            {
                Print(board, printDirection);
                Console.Write($"\n\nThe winner is {whoWinner} \n\nEnter in \"y\" to play again, enter in \"n\" to quit: ");
                string? answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.Clear();
                    whoWinner = "No One";
                    whoTurn = 'X';
                    movesPlayed = 0;
                    Initialize(board);
                }
                else
                {
                    whoWinner = "no one";
                }
            }
        }
    }
}