using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.I
{
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            // yep
        }

        public void Fax(Document d)
        {
            throw new System.NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new System.NotImplementedException();
        }
    }

}
