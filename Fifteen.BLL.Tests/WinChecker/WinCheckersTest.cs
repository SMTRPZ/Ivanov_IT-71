using Fifteen.BLL.Commands;
using Fifteen.BLL.WinCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fifteen.BLL.Tests.WinChecker
{
    public class WinCheckersTest
    {
        private readonly AdditionalMethods _helper;

        public WinCheckersTest()
        {
            _helper = new AdditionalMethods();
        }

        [Fact]
        public void SimpleWinChecker_When_UncorrectDesk_Then_FalseResult()
        {
            var desk = _helper.GenerateDesk(4);
            var moveCommand = new MoveDownCommand(desk);
            moveCommand.Execute();
            desk.SetWinner(new SimpleWinChecker());
            bool res = desk.IsInWinPosition();

            Assert.False(res);
        }

        [Fact]
        public void SimpleWinChecker_When_NewDesk_Then_TrueResult()
        {
            var desk = _helper.GenerateDesk(4);
            desk.SetWinner(new SimpleWinChecker());
            bool res = desk.IsInWinPosition();

            Assert.True(res);
        }

        [Fact]
        public void SimpleWinChecker_When_EmptyDesk_Then_FalseResult()
        {
            var desk = new Desk(4);
            desk.SetWinner(new SimpleWinChecker());

            Assert.Throws<NullReferenceException>(testCode: () => desk.IsInWinPosition());
        }
    }
}
