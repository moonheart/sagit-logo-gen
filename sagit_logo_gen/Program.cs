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
            const int offset2 = 0x105000;
            const int offset3 = 0x132E00;
            const int offset4 = 0x32D800;

            var outPath = Path.Combine(rootPath, "logo_new.img");

            var outFile = File.Open(outPath, FileMode.Create);

            byte[] rawData = {
                0x4C, 0x4F, 0x47, 0x4F, 0x21, 0x21, 0x21, 0x21, 0x21, 0x00, 0x00, 0x00,
                0x24, 0x00, 0x00, 0x00, 0x28, 0x08, 0x00, 0x00, 0x97, 0x09, 0x00, 0x00,
                0x6C, 0x19, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x04, 0x08, 0x00, 0x00,
                0x6F, 0x01, 0x00, 0x00, 0xD5, 0x0F, 0x00, 0x00, 0x10, 0x03, 0x00, 0x00
            };

            Stream imgStream = null;

            outFile.Seek(offset0, SeekOrigin.Begin);
            outFile.Write(rawData, 0, rawData.Length);

            outFile.Seek(offset1, SeekOrigin.Begin);
            imgStream = File.Open(Path.Combine(rootPath, "01.png"), FileMode.Open);
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

            outFile.Dispose();
        }
    }
}
