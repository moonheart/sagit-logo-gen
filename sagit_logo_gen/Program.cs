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
            const int offset1 = 0x4200;
            const int offset2 = 0x10C600;
            const int offset3 = 0x2A2600;
            const int offset4 = 0x2D0400;
            const int offset5 = 0x8BF200;

            var outPath = Path.Combine(rootPath, "logo_new.img");

            var outFile = File.Open(outPath, FileMode.Create);
            outFile.Write(new byte[0xEAE000], 0, 0xEAE000);

            byte[] rawData = {
                0x4C, 0x4F, 0x47, 0x4F, 0x21, 0x21, 0x21, 0x21, 0x21, 0x00, 0x00, 0x00,
                0x63, 0x08, 0x00, 0x00, 0x13, 0x15, 0x00, 0x00, 0x82, 0x16, 0x00, 0x00,
                0xF9, 0x45, 0x00, 0x00, 0x42, 0x08, 0x00, 0x00, 0xB0, 0x0C, 0x00, 0x00,
                0x6F, 0x01, 0x00, 0x00, 0x77, 0x2F, 0x00, 0x00, 0x77, 0x2F, 0x00, 0x00
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
