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
            const int offset2 = 0x5F4000;
            const int offset3 = 0x78A000;
            const int offset4 = 0x7B8000;
            const int offset5 = 0xDA7000;

            var outPath = Path.Combine(rootPath, "logo_new.img");

            var outFile = File.Open(outPath, FileMode.Create);
            outFile.Write(new byte[0x1396000], 0, 0x1396000);
            
            byte[] rawData = {
                0x4C, 0x4F, 0x47, 0x4F, 0x21, 0x21, 0x21, 0x21, 0x05, 0x00, 0x00, 0x00,
                0xEF, 0x05, 0x00, 0x00, 0xF4, 0x05, 0x00, 0x00, 0x96, 0x01, 0x00, 0x00,
                0x8A, 0x07, 0x00, 0x00, 0x2E, 0x00, 0x00, 0x00, 0xB8, 0x07, 0x00, 0x00,
                0xEF, 0x05, 0x00, 0x00, 0xA7, 0x0D, 0x00, 0x00, 0xEF, 0x05, 0x00, 0x00
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
