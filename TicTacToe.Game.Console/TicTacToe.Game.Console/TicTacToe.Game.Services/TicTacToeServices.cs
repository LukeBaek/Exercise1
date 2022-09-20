using System.Linq;
using TicTacToe.Game.Services.DTOs;

namespace TicTacToe.Game.Services
{
    public class TicTacToeServices
    {
        public TicTacToeServices(List<Player> players, int boardSize)
        {
            _boardSize = boardSize;
            _players = players;
            _board = new Board(boardSize);
            
        }

        public void PlayGame()
        {
            //0.Is game valid to start?
            if (!IsValid())
                return;
            //Init Game : Assign First Player
            InitialiseGame();

            while (true) {
                if (!CanContinue())
                    break;

                NextTurn();
                Console.WriteLine("Please insert coordinate example input : 1,1");
                var userInput = Console.ReadLine().Trim().Split(",");
                var row = Convert.ToInt32(userInput[0]);
                var col = Convert.ToInt32(userInput[1]);
                PlayerInputReceived(row, col);
                Console.WriteLine("Input received");
                DisplayBoard();
                
                if (IsWinner())
                {
                    Console.WriteLine($"Congratulations! Winner : {_currentPlayer.Name}");
                    break;
                }
                else
                {
                    if (IsBoardFull())
                    {
                        Console.WriteLine($"Board is full. Starting again");
                        InitialiseGame();
                    }
                }
            }
        }

        private void DisplayBoard()
        {
            var boardSize = _board.GetSize();
            //Row
            for (int i = 0; i < boardSize; i++)
            {
                var rowString = _board.GetRowString(i);
                Console.WriteLine(rowString);
            }
            
        }

        private void InitialiseGame()
        {
            _currentPlayer = null;
            _board = new Board(_boardSize);
        }

        private void NextTurn()
        {
            if (_currentPlayer == null) //Start Game
            {
                _currentPlayer = _players[0];
                Console.WriteLine($"We have first player {_currentPlayer.Name}");
            }
            else //Toggle Player
            {
                _currentPlayer = _players.Where(p => _currentPlayer.Name != p.Name).First();
                Console.WriteLine($"Next player {_currentPlayer.Name}'s turn to play");
            }
        }

        private bool IsValid()
        {
            //Always 2 players
            if (_players == null || _players.Count != 2)
                return false;

            //Board size must be greater than 0
            if (_board == null || _board.GetSize() < 1)
                return false;

            return true;
        }

        private void PlayerInputReceived(int row, int col)
        {
            //Validate Player's action on the board
            //Insert coordinate into board
            //Return Updated Board
            _board.SetLocation(row, col, _currentPlayer.Shape);
        }

        private bool IsWinner()
        {
            return _board.HasCompleteLines();           
        }

        private bool CanContinue()
        {
            if (_board.IsFull() || _board.HasCompleteLines())
                return false;
            else
            return true;
        }

        private bool IsBoardFull()
        {
            //HasWinner? false
            //Is Board Full? false
            //Otherwise true
            return true;
        }

        private int _boardSize;
        private Player _currentPlayer;
        private List<Player> _players;
        private Board _board;
    }
}