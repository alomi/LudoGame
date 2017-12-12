using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    [Serializable]
    class NoChosenMoveException : Exception
    {
        public NoChosenMoveException()
            : base("No piece has been chosen before making move")
        {
        }
    }
}
