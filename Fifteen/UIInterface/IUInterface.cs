using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen.UIInterface
{
    public interface IUInterface
    {
        void ShowInfoMessage(string message);
        void ShowErrorMessage(string message);
        void ShowSuccessMessage(string message);
        void ShowDesk(int?[,] numbers);
    }
}
