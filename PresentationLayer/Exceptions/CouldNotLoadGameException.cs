using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    [Serializable]
    class CouldNotLoadGameException : Exception
    {
        public CouldNotLoadGameException()
            : base("No previous game could be loaded, start new game")
        {
        }
    }
}
