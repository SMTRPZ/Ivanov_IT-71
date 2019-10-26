using Fifteen.BLL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fifteen.BLL.Tests.Commands
{
    public class RightCommandTests
    {
        private readonly AdditionalMethods _helper;

        public RightCommandTests()
        {
            _helper = new AdditionalMethods();
        }

        [Fact]
        public void MoveCommRight_When_NewDesk_Then_RightMoving()
        {
            var desk = _helper.GenerateDesk(4);
            var moveCommand = new MoveDownCommand(desk);
            bool res = moveCommand.Execute();

            Assert.True(res);
        }
        [Fact]
        public void MoveCommRight_When_NewDesk_Then_DeskChanged()
        {
            var newDesk = _helper.GenerateDesk(4);
            var desk = _helper.GenerateDesk(4);
            var moveCommand = new MoveDownCommand(desk);
            moveCommand.Execute();

            Assert.NotEqual(newDesk.GetDesk(), desk.GetDesk());
        }
        [Fact]
        public void MoveCommRightandAndUndo_When_NewDesk_Then_CorrectUndo()
        {
            var newDesk = _helper.GenerateDesk(4);
            var desk = _helper.GenerateDesk(4);
            var moveCommand = new MoveDownCommand(desk);
            moveCommand.Execute();

            moveCommand.Undo();

            Assert.Equal(newDesk.GetDesk(), desk.GetDesk());
        }
    }
}
