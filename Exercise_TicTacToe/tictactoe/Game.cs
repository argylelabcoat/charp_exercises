using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    public class Game : ITicTacToe
    {

        
        public Player GetWhoTurn()
        {
            throw new NotImplementedException();
        }

       
        public Player GetMarkAt(int x, int y)
        {
            throw new NotImplementedException();
        }

        
        public bool TryPlaceMarkAt(Player player, int x, int y)
        {
            throw new NotImplementedException();
        }

        
        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }


        public Player GetWinner()
        {
            throw new NotImplementedException();
        }
    }
}
