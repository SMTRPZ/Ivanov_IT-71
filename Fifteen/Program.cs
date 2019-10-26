using Fifteen.UIInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I'm glad to see in game Fifteen");
            Console.WriteLine("You can move items with the help of arrows and undo last actions with \"Ctrl+Z\"");
            Console.WriteLine("Enter field size, starts from 3 to 15");
            var fieldSize = GetInteger(3, 15);
            Console.WriteLine("Enter game difficulty size, starts from 1 to 100");
            var difficulty = GetInteger(1, 100);
            Console.WriteLine("Do you want to play game with bonuses? Y/other buttons");
            var bonuses = Console.ReadKey(true).Key == ConsoleKey.Y;

            var game = new GameInterface(new ConsoleUI(fieldSize));
            game.GenerateDesk(fieldSize, difficulty);
            game.StartGame(bonuses);

            Console.ReadLine();
        }

        static private int GetInteger(int minValue, int maxValue)
        {
            var str = "";
            var result = -1;
            while(result < minValue || result > maxValue)
            {
                str = Console.ReadLine();
                if (!int.TryParse(str, out result) || !(result >= minValue && result <= maxValue))
                {
                    Console.WriteLine($"Enter correct value! It's number from {minValue} to {maxValue}.");
                }
            }
            return result;
        }
    }
}
