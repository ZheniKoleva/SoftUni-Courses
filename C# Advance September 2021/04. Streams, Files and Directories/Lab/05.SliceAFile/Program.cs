using System;
using System.IO;
using System.Threading.Tasks;

namespace _05.SliceAFile
{
    class Program
    {
        static async Task Main(string[] args)
        {           
            const int PARTS = 4;

            using FileStream reader = new FileStream("sliceMe.txt", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[(int)Math.Ceiling(reader.Length / (double)PARTS)];

            for (int i = 1; i <= PARTS; i++)
            {
                int dataRead = await reader.ReadAsync(buffer, 0, buffer.Length);

                using FileStream writer = new FileStream($"../../../Part-{i}.txt", FileMode.OpenOrCreate, FileAccess.Write);
                await writer.WriteAsync(buffer);
            }
        }
    }
}
