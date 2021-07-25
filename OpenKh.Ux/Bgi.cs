using OpenKh.Common;
using System;
using System.IO;
using Xe.BinaryMapper;

namespace OpenKH.Ux
{
    public class Bgi
    {
        private const uint MagicNumber = 0x89424749;

        private class Header
        {
            [Data] public uint Magic { get; set; }
            [Data] public uint Encryption { get; set; } // maybe this is the version number instead more research needed
            [Data] public uint Version { get; set; } // or encryption flag
        }

        public Bgi()
        {

        }

        public Bgi(Stream stream)
        {

        }

        public static bool IsValid(Stream stream)
        {
            if (stream.SetPosition(0).ReadUInt32() != MagicNumber)
                return false;
            return true;
        }

        public static Bgi Read(Stream stream) =>
            new Bgi(stream.SetPosition(0));

        public void Write(Stream stream)
        {

        }
    }
}
