using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.Bonuses
{
    public abstract class BonusBase
    {
        protected readonly Desk _desk;
        public BonusBase(Desk desk)
        {
            _desk = desk;
        }
        public abstract void Use();
    }
}
