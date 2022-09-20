using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameState
    {
        public Player[,] GameGrid { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public int TurnsPassed { get; private set; }
        public bool GameOver { get; private set; }

        public void MoveMade(int r, int c)
        {

        }
        public void GameEnded(GameResult result)
        {

        }
        public void GameRestarted()
        {

        }
        public GameState()
        {
            GameGrid = new Player[3, 3];
            CurrentPlayer = Player.X;
            TurnsPassed = 0;
            GameOver = false;
        }
        private bool CanMakeMove(int r, int c)
        {
            return !GameOver && GameGrid[r, c] == Player.none;
        }
        private bool IsGridFull()
        {
            return TurnsPassed == 9;
        }
        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
        }
        private bool AreSquaresMarked(int, int)[] squard, Player player)
        {
            foreach((int r, int c ) in squares) 
            {
                   if (GameGrid[r, c] != player)
                   {
                        return false;
                     }
            }
            return true;
       }
        private bool DidMoveWin(int r, int c, out WinInfo winInfo)
        {
                (int, int)[] row = new[] { (r, 0), (r, 1),(r,2) };
                (int, int)[] row = new[] { (0, c), (1, c),(2,c) };
                (int, int)[] mainDiag = new[] { (0, 0), (1, 1),(2,2) };
                (int, int)[] antiDiag  = new[] { (0, 2), (2, 1),(2,0) };

        }
    }
}
