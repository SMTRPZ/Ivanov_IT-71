using Fifteen.BLL.Factories;
using Fifteen.BLL.WinCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL
{
    public class Desk
    {
        public int Size { get; private set; }

        private Cell[,] _desk;
        private Point emptyPosition;
        private IDeskFieldFactory _deskFieldFactory;
        private IWinChecker _winChecker;
        public Desk(int size)
        {
            Size = size;
            _deskFieldFactory = new ConsoleDeskFieldGenerator();
            _winChecker = new SimpleWinChecker();
        }

        public int?[,] GetDesk()
        {
            var size = _desk.GetLength(0);
            var cells = new int?[size, size];
            for(int i = 0; i < size; i++)
                for(int j = 0; j < size; j++)
                {
                    cells[i, j] = _desk[i, j]?.Number;
                }
            return cells;
        }

        public void SetGenerator(IDeskFieldFactory deskFieldFactory)
        {
            _deskFieldFactory = deskFieldFactory;
        }
        public void GenerateDesk()
        {
            _desk = _deskFieldFactory.GenerateDeskField(Size);
            emptyPosition = new Point(Size - 1, Size - 1);
        }

        public void SetWinner(IWinChecker winChecker)
        {
            _winChecker = winChecker;
        }
        public bool IsInWinPosition()
        {
            return _winChecker.IsDeskInWinState(_desk);
        }

        public bool MoveLeft()
        {
            if(emptyPosition.X < Size - 1)
            {
                var cell = _desk[emptyPosition.Y, emptyPosition.X + 1];
                _desk[emptyPosition.Y, emptyPosition.X] = cell;
                emptyPosition.X++;
                _desk[emptyPosition.Y, emptyPosition.X] = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MoveRight()
        {
            if (emptyPosition.X > 0)
            {
                var cell = _desk[emptyPosition.Y, emptyPosition.X - 1];
                _desk[emptyPosition.Y, emptyPosition.X] = cell;
                emptyPosition.X--;
                _desk[emptyPosition.Y, emptyPosition.X] = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MoveUp()
        {
            if (emptyPosition.Y < Size - 1)
            {
                var cell = _desk[emptyPosition.Y + 1, emptyPosition.X];
                _desk[emptyPosition.Y, emptyPosition.X] = cell;
                emptyPosition.Y++;
                _desk[emptyPosition.Y, emptyPosition.X] = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MoveDown()
        {
            if (emptyPosition.Y > 0)
            {
                var cell = _desk[emptyPosition.Y - 1, emptyPosition.X];
                _desk[emptyPosition.Y, emptyPosition.X] = cell;
                emptyPosition.Y--;
                _desk[emptyPosition.Y, emptyPosition.X] = null;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
