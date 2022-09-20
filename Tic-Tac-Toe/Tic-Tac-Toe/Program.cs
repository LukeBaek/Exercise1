
namespace Tic_Tac_Toe
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe");
            char player = 'X';
            int gridSize = 3;
            char[,] grid = new char[gridSize, gridSize];
            Initialize(grid, gridSize);            
            bool gameEnd = false;            
            while (gameEnd == false)
            {
                Console.Clear();
                Print(grid, gridSize);                
                Console.WriteLine("Please enter row: ");
                int row = processInput(Console.ReadLine(), gridSize);
                Console.WriteLine("Please enter col: ");
                int col = processInput(Console.ReadLine(), gridSize);
                while (grid[row, col] != ' ')
                {
                    Print(grid, gridSize);
                    Console.WriteLine("Already occupied!");
                    Console.WriteLine("Please enter row again: ");
                    row = processInput(Console.ReadLine(), gridSize);
                    Console.WriteLine("Please enter col again: ");
                    col = processInput(Console.ReadLine(), gridSize);

                }            
                grid[row, col] = player;                              
                gameEnd = checkWin(grid, player, gridSize);                
                player = ChangePlayer(player);
            }
        }
        static void Print(char[,] grid, int gridSize)
        {
            Console.WriteLine("   TicTacToe");
            for (int row = 0; row < gridSize; row++)
            {
                Console.Write(" | ");
                for (int col = 0; col < gridSize; col++)
                {
                    Console.Write(grid[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
        static void Initialize(char[,] grid, int gridSize)
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    grid[row, col] = ' ';
                }
            }
        }
        static char ChangePlayer(char currentPlayer)
        {
            if (currentPlayer == 'X')
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }
        static bool checkWin(char[,] grid, char player, int gridSize) {

            for (int row = 0; row < gridSize; row++)
            {
                string concat = "";
                for (int col = 0; col < gridSize; col++)
                {
                    concat += grid[row, col];
                }
                if ((concat == "XXX") || (concat == "OOO"))
                {
                    printWin(grid, player, gridSize);
                    return true;
                }
            }
            for (int col = 0; col < gridSize; col++)
            {
                string concat = "";
                for (int row = 0; row < gridSize; row++)
                {
                    concat += grid[row, col];
                }
                if ((concat == "XXX") || (concat == "OOO"))
                {
                    printWin(grid, player, gridSize);
                    return true;
                }
            }
            if (player == grid[0, 0] && player == grid[1, 1] && player == grid[2, 2])
            {
                printWin(grid, player, gridSize);
                return true;
            }
            else if (player == grid[0, 2] && player == grid[1, 1] && player == grid[2, 0])
            {
                printWin(grid, player, gridSize);
                return true;
            }
            else return false;
        }

        static void printWin(char[,] grid, char player, int gridSize)
        {
            Console.Clear();
            Print(grid, gridSize);
            Console.WriteLine(player + " has won the game!");     
            //Console.ReadKey();            
        }
        
        private static int processInput(string input, int gridSize)
        {
            int number = -1;
            while (number == -1)
            {
                try
                {
                    number = Int32.Parse(input);
                    if (number >= 0 && number <= gridSize-1)
                    { return number; }
                    else
                    {
                        Console.WriteLine($"{input} is not a valid number in 0-{gridSize - 1} range, try again: ");
                        number = -1;
                        input = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"{input} is not a valid number in 0-{gridSize - 1} range, try again: ");
                    number = -1;
                    input = Console.ReadLine();
                }
            }
            return number;
        }
    }
}