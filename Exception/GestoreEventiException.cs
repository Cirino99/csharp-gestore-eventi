using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi.Exception
{
    public class GestoreEventiException : Exception
    {
        public GestoreEventiException()
        {

        }
        public GestoreEventiException(string? message ) : base(message)
        {

        }
    }
}
