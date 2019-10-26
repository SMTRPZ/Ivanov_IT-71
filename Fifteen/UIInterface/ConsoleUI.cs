using Fifteen.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.UIInterface
{
    public class ConsoleUI : IUInterface
    {
        private readonly int fieldSize;
        private const int topPosition = 3;
        private const int leftPosition = 5;
        private const int cellsWidth = 6;
        private const int cellsHeight = 3;
        private bool isFieldShown;

        private int?[,] previousCellsState;
        public ConsoleUI(int fieldSize)
        {
            this.fieldSize = fieldSize;
        }

        public void ShowInfoMessage(string message)
        {
            if (isFieldShown)
                ClearLine(topPosition + fieldSize * cellsHeight + 2);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowErrorMessage(string message)
        {
            if (isFieldShown)
                ClearLine(topPosition + fieldSize * cellsHeight + 2);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowSuccessMessage(string message)
        {
            if (isFieldShown)
                ClearLine(topPosition + fieldSize * cellsHeight + 2);

            Console.SetCursorPosition(leftPosition + 5, topPosition + fieldSize * 3 + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ShowDesk(int?[,] numbers)
        {
            if (!isFieldShown)
            {
                ClearPage();
                PaintDeskBorder(fieldSize * cellsWidth, fieldSize * cellsHeight);
                for (int i = 0; i < fieldSize; i++)
                    for (int j = 0; j < fieldSize; j++)
                    {
                        if(numbers[i, j] != null)
                            ShowCell(new Point(leftPosition + j * cellsWidth, topPosition + i * cellsHeight), numbers[i, j].ToString());
                    }
                isFieldShown = true;
            } else
            {
                for(int i = 0; i < fieldSize; i ++)
                    for(int j = 0; j < fieldSize; j++)
                    {
                        if (numbers[i, j] != previousCellsState[i, j])
                        {
                            if (numbers[i, j] != null)
                                ShowCell(new Point(leftPosition + j * cellsWidth, topPosition + i * cellsHeight), numbers[i, j].ToString());
                            else
                                ClearCellSpace(leftPosition + j * cellsWidth, topPosition + i * cellsHeight);
                        }
                    }
            }
            previousCellsState = numbers;
        }

        private void ClearLine(int topPos)
        {
            Console.SetCursorPosition(0, topPos);
            Console.WriteLine(new string(' ', 120));
            Console.SetCursorPosition(0, topPos);
        }

        private void ClearPage()
        {
            for(int i = 0; i < 100; i++)
                ClearLine(i);
            Console.SetCursorPosition(0, 0);
        }

        private void ClearCellSpace(int horPos, int topPos)
        {
            for (int i = 0; i < cellsHeight; i++)
                ClearSpace(horPos, topPos + i, cellsWidth);
        }

        private void ClearSpace(int horPos, int topPos, int length)
        {
            Console.SetCursorPosition(horPos, topPos);
            Console.WriteLine("      ");
            Console.SetCursorPosition(horPos, topPos);
        }

        private void PaintDeskBorder(int horSize, int verSize)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(leftPosition - 1, topPosition - 1);
            Console.Write("\u250C{0}\u2510", new string('\u2500', horSize));
            for(int i = 0; i < verSize; i++)
            {
                Console.SetCursorPosition(leftPosition - 1, topPosition + i);
                Console.Write("\u2502");
                Console.SetCursorPosition(leftPosition + horSize, topPosition + i);
                Console.Write("\u2502");
            }
            Console.SetCursorPosition(leftPosition - 1, topPosition + verSize);
            Console.Write("\u2514{0}\u2518", new string('\u2500', horSize));
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void ShowCell(Point startPoint, string data)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var str = data.Length == 3 ? data : data.Length == 2 ? $"{data} " : $" {data} ";
            Console.SetCursorPosition(startPoint.X, startPoint.Y);
            Console.Write("\u250C\u2500\u2500\u2500\u2500\u2510"); 
            Console.SetCursorPosition(startPoint.X, startPoint.Y + 1);
            Console.WriteLine($"\u2502 {str}\u2502");
            Console.SetCursorPosition(startPoint.X, startPoint.Y + 2);
            Console.WriteLine("\u2514\u2500\u2500\u2500\u2500\u2518");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
