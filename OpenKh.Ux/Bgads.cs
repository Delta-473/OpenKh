using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenKh.Ux;

namespace OpenKh.Ux
{
    class Bgads
    {
        private List<Bgad> bgadList = new List<Bgad>();
        
        public Bgads()
        { 
        }

        public Bgads(Stream data)
        {

        }

        public void AppendBgad(Bgad var)
        {
            bgadList.Add(var);
        }

        public void RemoveBgad()
        {

        }

        public override string ToString()
        {
            return "Not implemented";
        }
    }
}
