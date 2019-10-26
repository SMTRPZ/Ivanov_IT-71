using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.BLL.DeskGenerators
{
    public class SimpleGenerator : IDeskGenerator
    {
        public void MoveCells(Desk desk, int iterationsCount, int? seed = null)
        {
            var size = desk.Size;
            var randomizer = new Random(seed == null ? DateTime.Now.Millisecond : (int)seed);
            for(int i = 0; i < iterationsCount * (size * size - 1); i++)
            {
                switch (randomizer.Next() % 4)
                {
                    case 0:
                        desk.MoveUp();
                        break;
                    case 1:
                        desk.MoveRight();
                        break;
                    case 2:
                        desk.MoveDown();
                        break;
                    case 3:
                        desk.MoveLeft();
                        break;
                }
            }
        }
    }
}
