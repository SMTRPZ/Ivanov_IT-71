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
                if (IsInputInvalid(key))
                {
                    continue;
                }

                //if (key.Key == ConsoleKey.UpArrow)
                //    game.Move(MoveDirection.Up);
                //else if (key.Key == ConsoleKey.RightArrow)
                //    game.Move(MoveDirection.Right);
                //else if (key.Key == ConsoleKey.DownArrow)
                //    game.Move(MoveDirection.Down);
                //else if (key.Key == ConsoleKey.LeftArrow)
                //    game.Move(MoveDirection.Left);

                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.Z)
                    game.UndoLastCommand();
                else
                    game.Move((MoveDirection)key.Key - 37);

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

        private bool IsInputInvalid(ConsoleKeyInfo key)
        {
            var button = key.Key;
            return button != ConsoleKey.UpArrow && button != ConsoleKey.DownArrow
                    && button != ConsoleKey.LeftArrow && button != ConsoleKey.RightArrow
                    && (button != ConsoleKey.Z && key.Modifiers != ConsoleModifiers.Control);
        }

        private void ShowDesk()
        {
            var desk = Game.GetInstance().GetDesk();
            _uInterface.ShowDesk(desk);
        }
    }
}
