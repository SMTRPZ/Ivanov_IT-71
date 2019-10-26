using Fifteen.BLL.Commands;
using Fifteen.BLL.DeskGenerators;
using Fifteen.BLL.Factories;
using Fifteen.BLL.WinCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fifteen.BLL.Tests
{
    public class SimpleGeneratorTests
    {
        private readonly AdditionalMethods _helper;
        public SimpleGeneratorTests()
        {
            _helper = new AdditionalMethods();
        }


        [Fact]
        public void SimpleGenerator_When_Size4Seed123_Then_MovedDesk()
        {
            var desk = _helper.GenerateDesk(4);
            int?[,] newDesk = _helper.GetNewDeskWithSize4();

            var simpleGenerator = new SimpleGenerator();
            simpleGenerator.MoveCells(desk, 1, 123);

            Assert.NotEqual(desk.GetDesk(), newDesk);
        }
    }
}
