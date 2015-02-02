using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    public class Game : ITicTacToe
    {

        
        public PlayerMark GetWhoTurn()
        {
            throw new NotImplementedException();
        }


        public PlayerMark GetMarkAt(int x, int y)
        {
            throw new NotImplementedException();
        }


        public bool TryPlaceMarkAt(PlayerMark player, int x, int y)
        {
            throw new NotImplementedException();
        }

        
        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }


        public PlayerMark GetWinner()
        {
            throw new NotImplementedException();
        }
    }
}
