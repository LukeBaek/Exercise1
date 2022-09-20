using TicTacToe.Game.Services;
using TicTacToe.Game.Services.DTOs;

Console.WriteLine("Welcome to Tic Tac Toc Game");

var boardSize = GetBoardSize();
List<Player> players = GetPlayers();


var service = new TicTacToeServices(players, boardSize);
service.PlayGame();

Console.WriteLine("Thanks for playing game");


int GetBoardSize()
{
    Console.WriteLine("Please enter Size of board:");
    var result = Console.ReadLine();

    try
    {
        return Convert.ToInt32(result);
    }
    catch (Exception ex)
    {
        Console.Write("Board size must be integer, please enter correct board size.");
        return GetBoardSize();
    }
    
}

List<Player> GetPlayers()
{
    Console.WriteLine("We need 2 players");
    Console.Write("First Players Name:");
    var player1 = new Player
    {
        Name = Console.ReadLine()?.Trim() ?? "Player1",
        Shape = "O"
    };


    Console.Write("Second Players Name:");
    var player2 = new Player
    {
        Name = Console.ReadLine()?.Trim() ?? "Player2",
        Shape = "X"
    };
    return new[]
    {
        player1, player2
    }.ToList();
}