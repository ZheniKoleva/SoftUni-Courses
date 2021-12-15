using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = "../../../Resourses";
            string zipDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Archive.zip";
            string extractDestination = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Archive";

            ZipFile.CreateFromDirectory(startPath, zipDestination);
            ZipFile.ExtractToDirectory(zipDestination, extractDestination);
        }
    }
}
