using System;
using System.IO;

namespace sagit_logo_gen
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;

            const int offset0 = 0x4000;
            const int offset1 = 0x5000;
            const int offset2 = 0x2B000;
            const int offset3 = 0x1C1000;
            const int offset4 = 0x1EF000;
            const int offset5 = 0x7DE000;

            var outPath = Path.Combine(rootPath, "logo_new.img");

            var outFile = File.Open(outPath, FileMode.Create);
            outFile.Write(new byte[0xDCCFFF], 0, 0xDCCFFF);

            byte[] rawData = {
                0x4C, 0x4F, 0x47, 0x4F, 0x21, 0x21, 0x21, 0x21, 0x05, 0x00, 0x00, 0x00,
                0x2B, 0x00, 0x00, 0x00, 0xC1, 0x01, 0x00, 0x00, 0xEF, 0x01, 0x00, 0x00,
                0xDE, 0x07, 0x00, 0x00, 0x26, 0x00, 0x00, 0x00, 0x96, 0x01, 0x00, 0x00,
                0x2E, 0x00, 0x00, 0x00, 0xEF, 0x05, 0x00, 0x00, 0xEF, 0x05, 0x00, 0x00
            };

            Stream imgStream = null;

            outFile.Seek(offset0, SeekOrigin.Begin);
            outFile.Write(rawData, 0, rawData.Length);

            outFile.Seek(offset1, SeekOrigin.Begin);
            imgStream = File.Open(Path.Combine(rootPath, "01.bmp"), FileMode.Open);
            imgStream.CopyTo(outFile);
            imgStream.Dispose();

            outFile.Seek(offset2, SeekOrigin.Begin);
            imgStream = File.Open(Path.Combine(rootPath, "02.bmp"), FileMode.Open);
            imgStream.CopyTo(outFile);
            imgStream.Dispose();

            outFile.Seek(offset3, SeekOrigin.Begin);
            imgStream = File.Open(Path.Combine(rootPath, "03.bmp"), FileMode.Open);
            imgStream.CopyTo(outFile);
            imgStream.Dispose();

            outFile.Seek(offset4, SeekOrigin.Begin);
            imgStream = File.Open(Path.Combine(rootPath, "04.bmp"), FileMode.Open);
            imgStream.CopyTo(outFile);
            imgStream.Dispose();

            outFile.Seek(offset5, SeekOrigin.Begin);
            imgStream = File.Open(Path.Combine(rootPath, "05.bmp"), FileMode.Open);
            imgStream.CopyTo(outFile);
            imgStream.Dispose();

            outFile.Dispose();
        }
    }
}
