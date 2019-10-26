using Fifteen.BLL.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fifteen.BLL.Tests.Generators
{
    public class GenerateCellTests
    {
        [Fact]
        public void GenerateCell_When_DataIs123_Then_CellNumberIs123()
        {
            var cellFactory = new ConsoleCellFactory();
            var cell = cellFactory.GetNextCell("123");

            Assert.True(cell.Number == 123);
        }
        [Fact]
        public void GenerateCell_When_DataIsminus1_Then_CellNumberIncorrect()
        {
            var cellFactory = new ConsoleCellFactory();
            var cell = cellFactory.GetNextCell("-5");

            Assert.True(cell.Number == -1);
        }
        [Fact]
        public void GenerateCell_When_DataIsString_Then_CellNumberIncorrect()
        {
            var cellFactory = new ConsoleCellFactory();
            var cell = cellFactory.GetNextCell("asfas");

            Assert.True(cell.Number == -1);
        }
    }
}
