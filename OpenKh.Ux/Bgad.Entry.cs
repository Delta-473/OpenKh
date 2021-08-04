using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.BinaryMapper;

namespace OpenKh.Ux
{
    public partial class Bgad
    {
        public class BgadEntry
        {
            [Data(0)] public byte[] RawData { get; set; }
            [Data] public Header header { get; set; }
            [Data] public string Name { get; set; }
            [Data] public Stream Data { get; set; }
        }
    }
}
