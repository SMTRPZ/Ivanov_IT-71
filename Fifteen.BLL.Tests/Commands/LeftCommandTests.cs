using Fifteen.BLL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fifteen.BLL.Tests.Commands
{
    public class LeftCommandTests
    {
        private readonly AdditionalMethods _helper;

        public LeftCommandTests()
        {
            _helper = new AdditionalMethods();
        }

        [Fact]
        public void MoveLeftCommand_When_NewDesk_Then_DeskDoesntChange()
        {
            var newDesk = _helper.GenerateDesk(4);
            var desk = _helper.GenerateDesk(4);
            var moveCommand = new MoveLeftCommand(desk);
            moveCommand.Execute();

            Assert.Equal(newDesk.GetDesk(), desk.GetDesk());
        }
        [Fact]
        public void MoveLeftCommand_When_NewDesk_Then_NoMoving()
        {
            var desk = _helper.GenerateDesk(4);
            var moveCommand = new MoveLeftCommand(desk);
            bool res = moveCommand.Execute();

            Assert.False(res);
        }
    }
}
