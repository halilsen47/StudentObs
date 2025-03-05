using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public abstract class NullException : Exception
    {
        protected NullException(string message) : base(message)
        {

        }
    }
}
