using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    [Serializable]
    class CouldNotReadFileException : NullReferenceException
    {
        public CouldNotReadFileException()
        : base() { }

        public CouldNotReadFileException(string message)
            : base("Path " + message + " could not be found") { }

        public CouldNotReadFileException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public CouldNotReadFileException(string message, Exception innerException)
            : base(message, innerException) { }

        public CouldNotReadFileException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
