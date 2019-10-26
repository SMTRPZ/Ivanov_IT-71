using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Factories
{
    public class ConsoleDeskFieldGenerator : IDeskFieldFactory
    {
        ICellFactory _cellFactory;

        public ConsoleDeskFieldGenerator()
        {
            _cellFactory = new ConsoleCellFactory();
        }

        public Cell[,] GenerateDeskField(int size)
        {
            var cells = new Cell[size, size];
            var cellNumber = 1;
            for (int i = 0; i < size; i++)
                for (int j = 0; j  < size; j++)
                {
                    if(i == size - 1 && j == size - 1)
                        break;
                    cells[i, j] = _cellFactory.GetNextCell(cellNumber.ToString());
                    cellNumber++;
                }
            return cells;
        }
    }
}
