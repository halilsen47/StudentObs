using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public sealed class StudentNullException : NullException
    {
        public StudentNullException(string entityName) : base($"The request with name: {entityName} is null")
        {

        }
    }
}
