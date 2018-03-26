using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PEBKAC : Exception
    {
        public string error { get; set; }
        public PEBKAC(string error): this(error,"Relisez bien ce qui est demandé...")
        {

        }
        public PEBKAC(string error, string Message): base(Message)
        {
            this.error = error;
        }
    }
}
