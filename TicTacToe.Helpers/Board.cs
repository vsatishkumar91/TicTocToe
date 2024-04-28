using System.Data;
using System.Numerics;
using TicTacToe.Helpers;

namespace TiTacToe.Helpers
{
    public class Board
    {
        private readonly int NoOfRows = 3;
        private readonly int NoOfColumns = 3;

        private string?[,] Tiles;

        private GameState GameState = GameState.NoResult;

        public Board()
        {
            Tiles = new string?[NoOfRows, NoOfColumns];
            for (int i = 0; i < NoOfRows; i++)
            {
                for (int j = 0; j < NoOfColumns; j++)
                {
                    Tiles[i, j] = (i * NoOfColumns + j + 1).ToString();
                }
            }
        }

        public void StartGame()
        {
            PrintBoard();
            int choice;
            int player = 1; //By default player 1 is set
            do
            {
                Console.WriteLine("Player1:X and Player2:O" + player);
                Console.WriteLine("\n");
               
                do
                {
                    if (player % 2 == 0)//checking the chance of the player
                    {
                        Console.WriteLine("Player 2 Chance");
                    }
                    else
                    {
                        Console.WriteLine("Player 1 Chance");
                    }
                    choice = int.Parse(Console.ReadLine());

                } while (choice < 1 || choice > 9);
                int selectedRow = (choice - 1) / NoOfColumns;
                int selectedCol = (choice-1)%NoOfColumns;
                if (Tiles[selectedRow,selectedCol] != "X" && Tiles[selectedRow, selectedCol] != "O")
                {
                    if (player % 2 == 0) //if chance is of player 2 then mark O else mark X
                    {
                        Tiles[selectedRow, selectedCol] = "O";
                    }
                    else
                    {
                        Tiles[selectedRow, selectedCol] = "X";
                    }
                    player++;

                }
                else
                //If there is any possition where user want to run
                //and that is already marked then show message and load board again
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, Tiles[selectedRow, selectedCol]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }

                PrintBoard();
                GameState = checkIfGameOver(player%2, selectedRow, selectedCol);

                if(GameState != GameState.NoResult)
                {
                    Console.WriteLine(GameState);
                }
            } while (GameState == GameState.NoResult);
        }

        private GameState checkIfGameOver(int player, int selectedrOW, int selectedCol)
        {
            var res = GameState.Win;
            string checkFor = player % 2 == 0 ? "O" : "X";
            for(int i = 0; i < 3; i++)
            {
                if (Tiles[selectedrOW, i] != checkFor){
                    res = GameState.NoResult;
                    break;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (Tiles[i, selectedCol] != checkFor)
                {
                    res = GameState.NoResult;
                    break;
                }
            }

            if(selectedCol == selectedrOW || selectedrOW == NoOfColumns-selectedCol- 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Tiles[i, i] != checkFor)
                    {
                        res = GameState.NoResult;
                        break;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    if (Tiles[i, NoOfColumns-1-i] != checkFor)
                    {
                        res = GameState.NoResult;
                        break;
                    }
                }
            }

            if(res == GameState.Win)
            {
                return res;
            }

            if(res == GameState.NoResult)
            {
                //check for draw
                for(int i = 0;i<NoOfRows;i++)
                {
                    for(int j=0;j<NoOfColumns;j++)
                    {
                        if (Tiles[i,j] != "X" && Tiles[i,j] != "O")
                        {
                            return GameState.NoResult;
                        }
                    }
                }
            }

            return GameState.Draw;
        }

        public void PrintBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Tiles[0,0], Tiles[0,1], Tiles[0,2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Tiles[1,0], Tiles[1,1], Tiles[1,2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Tiles[2,0], Tiles[2,1], Tiles[2,2]);
            Console.WriteLine("     |     |      ");
        }
    }
}
