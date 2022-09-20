using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game.Services.DTOs
{
    public class Board
    {
        public static readonly string BOARD_SEPARATOR = "|";
        public Board(int boardSize)
        {
            _boardSize = boardSize;
            _locations = new string[_boardSize, _boardSize];
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < _boardSize; i++)
            { 
                for (int j = 0; j < _boardSize; j++)
                {
                    _locations[i, j] = EMPTY_SPACE;
                }
            }
        }

        public int GetSize()
        {
            return _boardSize;
        }

        public string[,] GetLocations()
        {
            return _locations;
        }

        public string GetLocation(int row, int col)
        {
            return _locations[row, col];
        }

        public string GetRowString(int i)
        {
            return String.Join(BOARD_SEPARATOR, GetRow(i));
        }
        public bool HasCompleteLines()
        {
            return false;
        }
        public bool IsFull()
        {
            return false;
        }

        private string[] GetRow(int row)
        {
            var returnStrings = new List<string>();
            for (int i = 0; i < _boardSize; i++)
                returnStrings.Add(_locations[row, i]);
            return returnStrings.ToArray();
        }

        public string[,] SetLocation(int row, int col, string value)
        {
        //Check board index
        //Validate if location is reserved
        //Add Location
        _locations[row, col] = value;
            
            return _locations;
        }

        private readonly int _boardSize;
        private string[,] _locations;

        private static string EMPTY_SPACE = " ";

    }
}
