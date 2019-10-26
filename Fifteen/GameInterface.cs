using Fifteen.BLL;
using Fifteen.BLL.Bonuses;
using Fifteen.BLL.Model.Enums;
using Fifteen.UIInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    public class GameInterface
    {
        private IUInterface _uInterface;
        private readonly Random rnd;
        public GameInterface(IUInterface uInterface)
        {
            _uInterface = uInterface;
            rnd = new Random();
        }

        public void GenerateDesk(int size, int moveIterations)
        {
            Game.GetInstance().GenerateDesk(size, moveIterations);
            ShowDesk();
        }
        public void StartGame(bool useBonuses)
        {
            var game = Game.GetInstance();
            while(!game.IsInWinPosition())
            {
                var key = Console.ReadKey(true);
                var button = key.Key;
                if(button != ConsoleKey.UpArrow && button != ConsoleKey.DownArrow 
                    && button != ConsoleKey.LeftArrow && button != ConsoleKey.RightArrow 
                    && (button != ConsoleKey.Z && key.Modifiers != ConsoleModifiers.Control))
                {
                    continue;
                }
                if (key.Key == ConsoleKey.UpArrow)
                    game.Move(MoveDirection.Up);
                else if (key.Key == ConsoleKey.RightArrow)
                    game.Move(MoveDirection.Right);
                else if (key.Key == ConsoleKey.DownArrow)
                    game.Move(MoveDirection.Down);
                else if (key.Key == ConsoleKey.LeftArrow)
                    game.Move(MoveDirection.Left);
                else if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.Z)
                    game.UndoLastCommand();

                if (key.Modifiers != ConsoleModifiers.Control && useBonuses && rnd.Next(100) < 20)
                {
                    _uInterface.ShowInfoMessage("Bonus was used");
                    game.UseBonus();
                } else
                {
                    _uInterface.ShowInfoMessage("");
                }

                ShowDesk();
            }

            _uInterface.ShowSuccessMessage("YOU WIN!!!");
        }

        private void ShowDesk()
        {
            var desk = Game.GetInstance().GetDesk();
            _uInterface.ShowDesk(desk);
        }
    }
}
