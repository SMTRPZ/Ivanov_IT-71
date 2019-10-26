using Fifteen.BLL.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Tests
{
    public class AdditionalMethods
    {
        internal Desk GenerateDesk(int size)
        {
            var desk = new Desk(size);
            desk.SetGenerator(new ConsoleDeskFieldGenerator());
            desk.GenerateDesk();
            return desk;
        }

        internal int?[,] GetNewDeskWithSize4()
        {
            return new int?[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, null } };
        }
    }
}
