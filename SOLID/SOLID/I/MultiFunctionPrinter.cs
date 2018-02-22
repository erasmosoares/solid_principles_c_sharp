using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.I
{
    // ok if you need a multifunction machine
    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            //
        }

        public void Fax(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }
    }
}
