using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using tictactoe;
using System.Collections.Generic;
namespace test_tictactoe
{
    [TestClass]
    public class TicTacToe
    {

        /* X O X 0,1,2
         * O X X 3,4,8
         * O X O 5,6,7
         */
        struct point { public int x; public int y; }

        point[] failmoves = { new point{x=0,y=0}, new point{x=1,y=0}, new point{x=2,y=0},
                              new point{x=0,y=1}, new point{x=1,y=1}, new point{x=0,y=2},
                              new point{x=1,y=2}, new point{x=2,y=2}, new point{x=2,y=1}};
        
        [TestMethod]
        public void TestBoardCreation()
        {
            ITicTacToe g = new Game();

            for (int row = 0; row < 3; ++row)
                for (int col = 0; col < 3; ++col)
                    Assert.AreEqual<PlayerMark>(PlayerMark._, g.GetMarkAt(col, row));
        }

        [TestMethod]
        public void TestXIsFirst()
        {
            ITicTacToe g = new Game();

            Assert.AreEqual<PlayerMark>(PlayerMark.X, g.GetWhoTurn());
        }


        [TestMethod]
        public void TestSpotTaken()
        {
            ITicTacToe g = new Game();

            Assert.IsTrue(g.TryPlaceMarkAt(g.GetWhoTurn(), 0, 0));
            Assert.IsFalse(g.TryPlaceMarkAt(g.GetWhoTurn(), 0, 0));
        }

        [TestMethod]
        public void TestPlayersMustTakeTurns()
        {
            ITicTacToe g = new Game();

            Assert.IsTrue(g.TryPlaceMarkAt(PlayerMark.X, 0, 0));
            Assert.IsFalse(g.TryPlaceMarkAt(PlayerMark.X, 1, 0));
        }

        [TestMethod]
        public void TestPlayerOrder()
        {
            ITicTacToe g = new Game();
            PlayerMark previousPlayer = PlayerMark.O;
            PlayerMark expectedPlayer = PlayerMark.X;
            PlayerMark tempPlayer = PlayerMark._;
            int moves_made = 0;
            foreach(point p in failmoves)
            {
                // check player is who we expect:
                Assert.AreEqual<PlayerMark>(expectedPlayer, g.GetWhoTurn());
                
                

                // make a move guaranteed to make a stalemate (so we get 9 moves in)
                g.TryPlaceMarkAt(expectedPlayer, p.x, p.y);

                ++moves_made;

                // alternate who we expect:
                tempPlayer = expectedPlayer;
                expectedPlayer = previousPlayer;
                previousPlayer = tempPlayer;
            }

        }

        [TestMethod]
        public void TestMoveCommit()
        {
            ITicTacToe g = new Game();
            PlayerMark previousPlayer = PlayerMark.O;
            PlayerMark expectedPlayer = PlayerMark.X;
            PlayerMark tempPlayer = PlayerMark._;
            int moves_made = 0;
            foreach (point p in failmoves)
            {
               
                // make sure move is accepted
                Assert.IsTrue(g.TryPlaceMarkAt(expectedPlayer, p.x, p.y));

                // make sure move is committed
                Assert.AreEqual<PlayerMark>(expectedPlayer, g.GetMarkAt(p.x, p.y));
                ++moves_made;

                // alternate who we expect:
                tempPlayer = expectedPlayer;
                expectedPlayer = previousPlayer;
                previousPlayer = tempPlayer;
            }

           
        }

        [TestMethod]
        public void TestToStalemate()
        {
            ITicTacToe g = new Game();
            PlayerMark previousPlayer = PlayerMark.O;
            PlayerMark expectedPlayer = PlayerMark.X;
            PlayerMark tempPlayer = PlayerMark._;
            int moves_made = 0;
            foreach (point p in failmoves)
            {
                // check player is who we expect:
                Assert.AreEqual<PlayerMark>(expectedPlayer, g.GetWhoTurn());



                // make a move guaranteed to make a stalemate (so we get 9 moves in)
                Assert.IsTrue(g.TryPlaceMarkAt(expectedPlayer, p.x, p.y));

                // make sure move is committed
                Assert.AreEqual<PlayerMark>(expectedPlayer, g.GetMarkAt(p.x, p.y));
                ++moves_made;

                // alternate who we expect:
                tempPlayer = expectedPlayer;
                expectedPlayer = previousPlayer;
                previousPlayer = tempPlayer;
            }

            // should be unnecessary. might as well though.
            Assert.AreEqual<int>(9, moves_made);

            // game should now be over
            Assert.IsTrue(g.IsGameOver());

            // game winner should be no one
            Assert.AreEqual<PlayerMark>(PlayerMark._, g.GetWinner());

        }


        public void VerticalMovesX(ITicTacToe g, int column)
        {
            int low = 0;
            int high = 1;
            switch(column)
            {
                case 0:
                    low = 1;
                    high = 2;
                    break;
                case 1:
                    low = 0;
                    high = 2;
                    break;
                case 2:
                    low = 0;
                    high = 1;
                    break;
                default:
                    break;
            }
            for(int y = 0; y < 3; ++y)
            {
                g.TryPlaceMarkAt(PlayerMark.X, column, y);
                g.TryPlaceMarkAt(PlayerMark.O, y == 1 ? high : low, y );
            }
        }

        public void VerticalMovesO(ITicTacToe g, int column)
        {
            int low = 0;
            int high = 1;
            switch (column)
            {
                case 0:
                    low = 1;
                    high = 2;
                    break;
                case 1:
                    low = 0;
                    high = 2;
                    break;
                case 2:
                    low = 0;
                    high = 1;
                    break;
                default:
                    break;
            }
            for (int y = 0; y < 3; ++y)
            {
                g.TryPlaceMarkAt(PlayerMark.X,  y == 1 ? high : low, y);
                g.TryPlaceMarkAt(PlayerMark.O, column, y);
            }
        }

        public void HorizontalMovesX(ITicTacToe g, int row)
        {
            int low = 0;
            int high = 1;
            switch (row)
            {
                case 0:
                    low = 1;
                    high = 2;
                    break;
                case 1:
                    low = 0;
                    high = 2;
                    break;
                case 2:
                    low = 0;
                    high = 1;
                    break;
                default:
                    break;
            }
            for (int x = 0; x < 3; ++x)
            {
                g.TryPlaceMarkAt(PlayerMark.X, x, row);
                g.TryPlaceMarkAt(PlayerMark.O, x, x == 1 ? high : low);
            }
        }

        public void HorizontalMovesO(ITicTacToe g, int row)
        {
            int low = 0;
            int high = 1;
            switch (row)
            {
                case 0:
                    low = 1;
                    high = 2;
                    break;
                case 1:
                    low = 0;
                    high = 2;
                    break;
                case 2:
                    low = 0;
                    high = 1;
                    break;
                default:
                    break;
            }
            for (int x = 0; x < 3; ++x)
            {
                g.TryPlaceMarkAt(PlayerMark.X, x, x == 1 ? high : low);
                g.TryPlaceMarkAt(PlayerMark.O, x, row);
            }
        }

        [TestMethod]
        public void TestXVerticalVictory()
        {
            for (int col = 0; col < 3; ++col )
            {
                ITicTacToe g = new Game();
                // mark a column of X's
                VerticalMovesX(g, col);
                // This should end the game
                Assert.IsTrue(g.IsGameOver());
                // X Should be winner via vertical moves
                Assert.AreEqual<PlayerMark>(PlayerMark.X, g.GetWinner());
            }
        }

        [TestMethod]
        public void TestOVerticalVictory()
        {
            for (int col = 0; col < 3; ++col)
            {
                ITicTacToe g = new Game();
                // mark a column of O's
                VerticalMovesO(g, col);
                // This should end the game
                Assert.IsTrue(g.IsGameOver());
                // O Should be winner via vertical moves
                Assert.AreEqual<PlayerMark>(PlayerMark.O, g.GetWinner());
            }
        }

        [TestMethod]
        public void TestXHorizontalVictory()
        {
            for (int col = 0; col < 3; ++col)
            {
                ITicTacToe g = new Game();
                // mark a row of X's
                HorizontalMovesX(g, col);
                // This should end the game
                Assert.IsTrue(g.IsGameOver());
                // X Should be winner via horizontal moves
                Assert.AreEqual<PlayerMark>(PlayerMark.X, g.GetWinner());
            }
        }

        [TestMethod]
        public void TestOHorizontalVictory()
        {
            for (int col = 0; col < 3; ++col)
            {
                ITicTacToe g = new Game();
                // mark a row of O's
                HorizontalMovesO(g, col);
                // This should end the game
                Assert.IsTrue(g.IsGameOver());
                // O Should be winner via horizontal moves
                Assert.AreEqual<PlayerMark>(PlayerMark.O, g.GetWinner());
            }
        }

        

        

        point IndexToPoint(int index)
        {
            point p;
            p.x = index % 3;
            p.y = (int) Math.Floor(index / 3.0f);
            return p;
        }

        point[] StringToMoves(string board)
        {
            List<point> xMoves = new List<point>();
            List<point> oMoves = new List<point>();
            List<point> moves = new List<point>();

            int index = 0;
            foreach(char c in board)
            {
                if (c == '_')
                    ++index;
                else if (c == 'X' || c == 'x')
                    xMoves.Add(IndexToPoint(index++));
                else if (c == 'O' || c == 'o')
                    oMoves.Add(IndexToPoint(index++));
            }

            while(xMoves.Count > 0 && oMoves.Count > 0)
            {
                moves.Add(xMoves[0]);
                moves.Add(oMoves[0]);
                xMoves.RemoveAt(0);
                oMoves.RemoveAt(0);
            }
            // because there's 9 squares, x can move 1 more time than o
            if (xMoves.Count>0)
            {
                moves.Add(xMoves[0]);
                xMoves.RemoveAt(0);
            }

            return moves.ToArray();
        }


        void TestMovesExpectWinner(ITicTacToe g, point[] moves, PlayerMark winner)
        {
            foreach(point p in moves)
            {
                g.TryPlaceMarkAt(g.GetWhoTurn(), p.x, p.y);
            }
            Assert.IsTrue(g.IsGameOver());
            Assert.AreEqual<PlayerMark>(winner, g.GetWinner());
        }

        [TestMethod]
        public void TestXDiagonalVictory()
        {
            string testAstr = "";
            testAstr += "XOO";
            testAstr += "_XO";
            testAstr += "__X";

            string testBstr = "";
            testBstr += "OOX";
            testBstr += "OX_";
            testBstr += "X__";

            TestMovesExpectWinner(new Game(), StringToMoves(testAstr), PlayerMark.X);
            TestMovesExpectWinner(new Game(), StringToMoves(testBstr), PlayerMark.X);
        }

        [TestMethod]
        public void TestODiagonalVictory()
        {
            string testAstr = "";
            testAstr += "OXX";
            testAstr += "_OX";
            testAstr += "__O";

            string testBstr = "";
            testBstr += "XXO";
            testBstr += "XO_";
            testBstr += "O__";

            TestMovesExpectWinner(new Game(), StringToMoves(testAstr), PlayerMark.O);
            TestMovesExpectWinner(new Game(), StringToMoves(testBstr), PlayerMark.O);
        }

        [TestMethod]
        public void TestSomeStalemates()
        {
            string testAstr = "";
            testAstr += "XXO";
            testAstr += "OOX";
            testAstr += "XOX";

            string testBstr = "";
            testBstr += "XOX";
            testBstr += "OOX";
            testBstr += "XXO";

            TestMovesExpectWinner(new Game(), StringToMoves(testAstr), PlayerMark._);
            TestMovesExpectWinner(new Game(), StringToMoves(testBstr), PlayerMark._);
        }

    }
}
