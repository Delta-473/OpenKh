using OpenKh.Common;
using System;
using System.IO;
using System.Text;
using Xe.BinaryMapper;

namespace OpenKh.Ux
{
    public partial class Bgad
    {
        private const uint MagicNumber = 0x42474144;

        public BgadEntry bgadEntry { get; set; }

        // small files in .apk
        private static readonly byte[] key1 = {
            0x5C,0xA5,0x6C,0x58,0x27,0xFA,0x15,0xCF,0x1E,0xCE,0x2A,0x37,0x18,0x09,0x53,0xB8,
            0x01,0xDE,0xBF,0xD0,0xA7,0x1D,0xD6,0xAA,0x6D,0xD1,0xD4,0xF4,0x14,0xA5,0xFB,0xC4
        };
        // downloaded files inside "r" folder
        private static readonly byte[] key2 = {
            0x3c,0x84,0x99,0xbf,0x7e,0xee,0x43,0xbd,0x1b,0x4d,0xde,0x85,0x37,0x25,0xa1,0x10,
            0xf0,0x91,0x4c,0x76,0xc1,0x67,0xbe,0x9d,0x3c,0x90,0x2c,0xbe,0xe7,0x90,0xb0,0x3e
        };
        // encrypted/saved files?
        private static readonly byte[] key3 = {
            0xFB,0x32,0x83,0x3C,0x8C,0xC4,0x03,0x01,0x8A,0xC1,0xEA,0xB9,0x21,0xF5,0x6C,0x26,
            0x18,0xA4,0xAF,0x7E,0x38,0xCC,0xC9,0xCF,0x52,0x67,0xAA,0x19,0xFD,0xBA,0x32,0x0C
        };

        static void Xor8bDecrypt(byte[] buf, int length, int key)
        {
            for (int i = 0; i < length; i++)
            {
                key = 0x19660D * key + 0x3C6EF35F;
                buf[i] = (byte)((buf[i] ^ key) & 0xFF);
            }
        }

        void Xor32bDecrypt(int[] data, int length, int key)
        {
            int count = (length + 3) >> 2, i;
            for (i = 0; i < count; i++)
            {
                key = 0x19660D * key + 0x3C6EF35F;
                data[i] ^= key;
            }
        }

        public Bgad()
        {

        }

        public Bgad(string name, ushort ivType, ushort compression, ushort encryption, Stream stream)
        {
            // setting header
            bgadEntry.header.Magic = MagicNumber;
            bgadEntry.header.Version = 2;
            bgadEntry.header.IvType = ivType;
            bgadEntry.header.HeaderSize = 24;
            bgadEntry.header.NameSize = (ushort)name.Length;
            bgadEntry.header.Encryption = encryption;
            bgadEntry.header.Compression = compression;
            bgadEntry.header.DataSize = (uint)stream.Length;

            bgadEntry.Name = name;
            bgadEntry.Data = stream;
            
        }

        public Stream Encrypt(Stream stream)
        {
            switch (bgadEntry.header.Encryption)
            {
                // no encryption
                case 0:
                    return stream;
                // xor8b
                case 1:
                    throw new NotImplementedException("xor8b encryption not supported yet");
                // xor32b
                case 2:
                    throw new NotImplementedException("xor32b encryption not supported yet");
                // chacha8
                case 3:
                    throw new NotImplementedException("ChaCha8 encryption not supported yet");
                default:
                    throw new NotImplementedException("Unknown encryption type " + bgadEntry.header.Encryption);
            }
        }

        public Stream Decrypt(Stream stream)
        {
            switch (bgadEntry.header.Encryption)
            {
                // no encryption
                case 0:
                    return stream;
                // xor8b
                case 1:
                    throw new NotImplementedException("xor8b encryption not supported yet");
                // xor32b
                case 2:
                    throw new NotImplementedException("xor32b encryption not supported yet");
                // chacha8
                case 3:
                    throw new NotImplementedException("ChaCha8 encryption not supported yet");
                default:
                    throw new NotImplementedException("Unknown encryption type " + bgadEntry.header.Encryption);
            }
        }

        public Stream Compress(Stream stream)
        {
            switch (bgadEntry.header.Compression)
            {
                // no compression
                case 0:
                    return stream;
                // unknown compression used in FF
                case 1:
                    throw new NotImplementedException("Unknown compression type 1 not implemented, used in Final Fantasy");
                // zlib
                case 2:
                    throw new NotImplementedException("Zlib compression not supported yet");
                default:
                    throw new NotImplementedException("Unknown compression type " + bgadEntry.header.Compression);
            }
        }

        public Stream Decompress(Stream stream)
        {
            switch (bgadEntry.header.Compression)
            {
                // no compression
                case 0:
                    return stream;
                // unknown compression used in FF
                case 1:
                    throw new NotImplementedException("Unknown compression type 1 not implemented, used in Final Fantasy");
                case 2:
                    throw new NotImplementedException("Zlib decompression not supported yet");
                default:
                    throw new NotImplementedException("Unknown compression type " + bgadEntry.header.Compression);
            }
        }

        public static bool IsValid(Stream stream)
        {
            if (stream.SetPosition(0).ReadUInt32() != MagicNumber)
                return false;
            return true;
        }

        //public static Bgad Read(Stream stream) =>
        //    new Bgad(stream.SetPosition(0));

        public void Write(Stream stream)
        {

        }
    }
}
