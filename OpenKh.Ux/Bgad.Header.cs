using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.BinaryMapper;

namespace OpenKh.Ux
{
    public partial class Bgad
    {
        public class Header
        {
            [Data] public uint Magic { get; set; }
            [Data] public ushort Version { get; set; }
            [Data] public ushort IvType { get; set; }
            // header size is always 24 bytes
            [Data] public ushort HeaderSize { get; set; }
            [Data] public ushort NameSize { get; set; }
            [Data] public ushort Encryption { get; set; }
            [Data] public ushort Compression { get; set; }
            [Data] public uint DataSize { get; set; }
            [Data] public uint DecompressedSize { get; set; }

        }
    }
}
