using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Commands
{
    public abstract class Command
    {
        protected Desk desk;
        public Command(Desk desk)
        {
            this.desk = desk;
        }
        public abstract bool Execute();
        public abstract void Undo();
    }
}
