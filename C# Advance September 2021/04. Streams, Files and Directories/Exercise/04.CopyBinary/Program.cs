using System;
using System.IO;
using System.Threading.Tasks;

namespace _04.CopyBinary
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using FileStream reader = new FileStream("copyMe.png", FileMode.Open, FileAccess.Read);
            long size = reader.Length;
            byte[] buffer = new byte[4096];
            long readBytes = 0;

            using FileStream writer = new FileStream("../../../copyMe-Copy.png", FileMode.Create, FileAccess.Write);
            while (readBytes < size)
            {
                int dataToRead = (int)Math.Min(buffer.Length, size - readBytes);

                int readData = await reader.ReadAsync(buffer, 0, dataToRead);

                await writer.WriteAsync(buffer, 0, dataToRead);
                readBytes += dataToRead;
            }
        }
    }
}
