using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public class MoveDownCommand : ICommand
    {
        private Desk desk;
        public MoveDownCommand(Desk desk)
        {
            this.desk = desk;
        }
        public bool Execute()
        {
            return desk.MoveDown();
        }

        public void Undo()
        {
            desk.MoveUp();
        }
    }
}
