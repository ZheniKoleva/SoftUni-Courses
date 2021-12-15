using System;
using System.IO;
using System.Threading.Tasks;

namespace _04.CopyBinary2
{
    class Program
    {
        static async Task Main(string[] args)
        {
             File.Copy("copyMe.png", "../../../copyMe-Copy.png");            
        }
    }
}
