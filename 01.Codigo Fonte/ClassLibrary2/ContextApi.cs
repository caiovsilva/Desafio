using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class ContextApi : DbContext
    {
        public ContextApi() : base("name=ContextApi")
        {

        }
    }
}
