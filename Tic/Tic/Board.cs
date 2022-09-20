using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic
{
    public class Board
    {
        private Player player1;
        private Player player2;
        public int TurnCount { get; set; }
        public int Size { get; private set; } = 3;
        public string[] CurrentState { get; set; }
        public Player Player1
        {
            get { return player1; }
            set { player1 = value; }
        }
        public Player Player2
        {
            get { return player2; }
            set { player2 = value; }
        }
        public Board()
        {
            this.TurnCount = 0;
            this.CurrentState = new string[Size * Size];
            this.player1 = new Player();
            this.player2 = new Player();
            this.Player1.Char = "x";
            this.Player2.Char = "o";
        }
        private void initiateBoard()
        {
            for (int i = 0; i < Size*Size; i++) { CurrentState[i] = " "; }
        }
        public void NewGame()
        {
            this.TurnCount = 0;
            initiateBoard();
            Console.WriteLine("Enter Player1 name (1 char. or more): ");
            player1.setName(Console.ReadLine());
            Console.WriteLine($"Player 1 name is {player1.Name}.");
            Console.WriteLine("Enter Player2 name (1 char. or more): ");
            player2.setName(Console.ReadLine());
            Console.WriteLine($"Player 2 name is {player2.Name}.");            
        }
    }
}
