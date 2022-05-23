using System;
using System.IO;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string fileName = Path.GetFileNameWithoutExtension(input);
            string extension = Path.GetExtension(input);
            extension = extension.Remove(0, 1);
            
            //int indxOfLastFile = input.LastIndexOf('\\');
            //string file = input.Substring(indxOfLastFile + 1);

            //int indxOfExtension = file.LastIndexOf('.');
            //string extension = file.Substring(indxOfExtension + 1);
            //string fileName = file.Substring(0, indxOfExtension);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");

        }
    }
}
