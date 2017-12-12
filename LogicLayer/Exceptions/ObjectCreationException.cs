using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    [Serializable]
    class ObjectCreationException : Exception
    {
        public ObjectCreationException()
            : base("Object could not be created")
        {
        }
    }
}
