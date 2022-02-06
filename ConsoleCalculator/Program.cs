// See https://aka.ms/new-console-template for more information
using ConsoleCalculator;

bool end = false;

Console.WriteLine("--------------------------------------\n");
Console.WriteLine("----------Console Calculator----------\n");
Console.WriteLine("-----  *^^* 콘솔 계산기 *^^*  --------\n");
Console.WriteLine("--------------------------------------\n");

while (!end)
{
    string numInput1 = "";
    string numInput2 = "";
    string op = "";
    double result = 0;

    // Ask the user to type the first number.
    Console.Write("Please enter the first number, and then press Enter: ");
    numInput1 = Console.ReadLine();

    double checkNum1 = 0;
    // while (!double.TryParse(numInput1, out checkNum1))
    while (!Calculator.IsNumeric(numInput1))
    {
        Console.Write("\nThis is not valid input. Please enter an number value: ");
        numInput1 = Console.ReadLine();
    }

    // Ask the user to type the operator.
    Console.WriteLine("\nChoose an operator from the following list: + , -, *, /\n");
    Console.Write("Your operator? ");
    op = Console.ReadLine();

    while (op!= "+" && op != "-"&& op != "*" && op != "/" )
    {
        Console.Write("\nThis is not valid input. Choose an operator from the following list: + , -, *, /\n\nYour operator? ");
        op = Console.ReadLine();
    }

    // Ask the user to type the second number.
    Console.Write("\nPlease enter the second number, and then press Enter: ");
    numInput2 = Console.ReadLine();

    double checkNum2 = 0;
    while ((!double.TryParse(numInput2,out checkNum2)) || ((op == "/") && (int.Parse(numInput2) == 0))) 
    {  
        if ((double.TryParse(numInput2,out checkNum2)) && ((op == "/") && (int.Parse(numInput2) == 0))) // Ask the user to enter a non-zero divisor until they do so.
        {
            Console.Write("\nThis is not valid input. Please enter a non-zero divisor: ");
            numInput2 = Console.ReadLine();
        }
        else
        {
            Console.Write("\nThis is not valid input. Please enter an number value: "); // Ask the user to enter an number value until they do so.
            numInput2 = Console.ReadLine();
        }
    }
    try
    {
        result = Calculator.DoOperation(checkNum1, checkNum2, op);
        if (double.IsNaN(result))
        {
            Console.WriteLine("\nThis operation will result in a mathematical error.\n\nreturned result: " + result);
        }
        else Console.WriteLine("\n\nYour result: {0} {1} {2} = {3:0.##}\n", checkNum1, op, checkNum2 ,result);
    }
    catch (Exception e)
    {
        Console.WriteLine("\nOh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
    }

    Console.WriteLine("--------------------------------------\n");

    Console.Write("Press 'n' and Enter to close the console, or press any other key and Enter to continue: ");
    if (Console.ReadLine() == "n") end = true;

    Console.WriteLine("\n"); 
}
return;
        
