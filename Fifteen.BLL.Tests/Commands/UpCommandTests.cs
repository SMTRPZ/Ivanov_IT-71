using Fifteen.BLL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fifteen.BLL.Tests.Commands
{
    public class UpCommandTests
    {
        private readonly AdditionalMethods _helper;

        public UpCommandTests()
        {
            _helper = new AdditionalMethods();
        }

        [Fact]
        public void MoveUpCommandAndUndo_When_NewDesk_Then_DeskDoesntChange()
        {
            var newDesk = _helper.GenerateDesk(4);
            var desk = _helper.GenerateDesk(4);
            var moveCommand = new MoveUpCommand(desk);
            moveCommand.Execute();

            Assert.Equal(newDesk.GetDesk(), desk.GetDesk());
        }
        [Fact]
        public void MoveUpCommandAndUndo_When_NewDesk_Then_NoMoving()
        {
            var desk = _helper.GenerateDesk(4);
            var moveCommand = new MoveUpCommand(desk);
            bool res = moveCommand.Execute();

            Assert.False(res);
        }
    }
}
