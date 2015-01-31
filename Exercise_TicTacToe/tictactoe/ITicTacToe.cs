using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    public interface ITicTacToe
    {
        /// <summary>
        /// Return which PlayerMark is up to take a turn. PlayerMark X should always be the first PlayerMark in a game.
        /// In event of a gameover, this is undefined and may be any valid Player value
        /// </summary>
        /// <returns>Player who may take a turn</returns>
        PlayerMark GetWhoTurn();

        /// <summary>
        /// Obtain the PlayerMark value at the given coordinates of the board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Returns the Player object representing which Player has marked this space, Player._ represents no mark yet</returns>
        PlayerMark GetMarkAt(int x, int y);

        /// <summary>
        /// Attempts to mark a space on the board for the given player
        /// </summary>
        /// <param name="player"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if mark successfully placed, False if the space were already marked or given player isn't the proper player to move</returns>
        bool TryPlaceMarkAt(PlayerMark player, int x, int y);

        /// <summary>
        /// Obtain whether the game is over yet
        /// </summary>
        /// <returns>True if Game is Over (There is a winner or a full board)</returns>
        bool IsGameOver();

        /// <summary>
        /// Obtain which Player won the game
        /// </summary>
        /// <returns>Player.X if X won, Player.O if O won, Player._ if no winner</returns>
        PlayerMark GetWinner();
    }
}
