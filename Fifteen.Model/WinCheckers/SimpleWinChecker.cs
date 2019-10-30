using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.WinCheckers
{
    public class SimpleWinChecker : IWinChecker
    {
        public bool IsDeskInWinState(Cell[,] desk)
        {
            int previousNumber = -1;
            var size = desk.GetLength(0);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (desk[i, j] != null)
                    {
                        if (i == 0 && j == 0)
                        {
                            previousNumber = desk[i, j].Number;
                        }
                        else if (desk[i, j].Number > previousNumber)
                        {
                            previousNumber = desk[i, j].Number;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (i != size - 1 || j != size - 1)
                        return false;
            return true;
        }
    }
}
