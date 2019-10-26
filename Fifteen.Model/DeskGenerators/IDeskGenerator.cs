using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.DeskGenerators
{
    public interface IDeskGenerator
    {
        void MoveCells(Desk desk, int iterationsCount, int? seed = null);
    }
}
