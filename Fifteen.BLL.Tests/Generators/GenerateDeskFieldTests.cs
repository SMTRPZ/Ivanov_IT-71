using Fifteen.BLL.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fifteen.BLL.Tests.Generators
{
    public class GenerateDeskFieldTests
    {
        [Fact]
        public void GenerateDeskField_When_SizeIs3_Then_CorrectLength()
        {
            var deskFieldFactory = new ConsoleDeskFieldGenerator();
            var desk = deskFieldFactory.GenerateDeskField(3);

            Assert.True(desk.Length == 9);
        }
        [Fact]
        public void GenerateDeskField_When_SizeIs3_Then_CorrectNumbers()
        {
            var deskFieldFactory = new ConsoleDeskFieldGenerator();
            var desk = deskFieldFactory.GenerateDeskField(3);

            Assert.True(desk[1, 1].Number == 5);
        }
        [Fact]
        public void GenerateDeskField_When_SizeIs3_Then_LastCellNull()
        {
            var deskFieldFactory = new ConsoleDeskFieldGenerator();
            var desk = deskFieldFactory.GenerateDeskField(3);

            Assert.True(desk[2, 2] == null);
        }
    }
}
