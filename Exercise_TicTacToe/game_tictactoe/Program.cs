using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tictactoe;

namespace game_tictactoe
{
    class Program
    {

        static string GetMark(PlayerMark p)
        {
            return System.Enum.GetName(typeof(PlayerMark), p);
        }
        static void PrintBoard(ITicTacToe g)
        {
            PlayerMark whoturn = g.GetWhoTurn();
            Console.WriteLine("Player {0}'s Turn", GetMark(whoturn));
            Console.WriteLine("Board:");
            Console.WriteLine("   0 | 1 | 2 ");
            for (int row = 0; row < 3; ++row )
                Console.WriteLine("{3}: {0} | {1} | {2} ",
                    GetMark(g.GetMarkAt(0, row)), GetMark(g.GetMarkAt(1, row)), GetMark(g.GetMarkAt(2, row)), row);

        }

        static void TakeTurn(ITicTacToe g)
        {
            PlayerMark whoturn = g.GetWhoTurn();
            bool placed = false;
            while(!placed)
            {
                bool gotX = false;
                bool gotY = false;
                int x, y;
                x = y = 0;
                Console.WriteLine("Entering Player Move For: {0}", GetMark(whoturn));
                while (!gotX)
                {
                    Console.WriteLine("Enter Column:");
                    string lineIn = Console.ReadLine();
                    gotX = int.TryParse(lineIn, out x);
                }
                while (!gotY)
                {
                    Console.WriteLine("Enter Row:");
                    string lineIn = Console.ReadLine();
                    gotY = int.TryParse(lineIn, out y);
                }
                placed = g.TryPlaceMarkAt(whoturn, x, y);
                if (!placed)
                    Console.WriteLine("Invalid Move!");
            }
        }

        static void Main(string[] args)
        {
            ITicTacToe game = new Game();

            while(game.IsGameOver()==false)
            {
                PrintBoard(game);
                TakeTurn(game);
            }

            Console.WriteLine("Game Over!");
            if (game.GetWinner() != PlayerMark._)
                Console.WriteLine("Winner is: {0}", GetMark(game.GetWinner()));
            Console.ReadKey();
        }
    }
}
