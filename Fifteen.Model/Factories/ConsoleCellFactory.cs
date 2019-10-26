using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Factories
{
    public class ConsoleCellFactory : ICellFactory
    {
        public Cell GetNextCell(string data)
        {
            if (int.TryParse(data, out int number) && number > 0)
                return new Cell(number);
            else
                return new Cell(-1);
        }
        //public static ConsoleCellFactory GetInstance()
        //{
        //    Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
        //    return Nested.instance;
        //}
        //private class Nested
        //{
        //    internal static readonly ConsoleCellFactory instance = new ConsoleCellFactory();
        //}
    }
}
