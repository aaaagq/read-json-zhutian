using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace 读取json分析修改
{
    public class MyZIP
    {
        public static string path1 = "package\\";
        public static string path2 = "package2\\";
        public static string path3 = "temp\\";
        public static string fileName = "..\\package.nw";
        public static string gg = "gg.json";


        public static void ExtractGG(string gg = "gg.json")
        {
            using (ZipArchive archive = ZipFile.OpenRead(fileName))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    Console.WriteLine(entry.FullName);
                    if (entry.FullName == gg)
                    {
                        entry.ExtractToFile(path3 + entry.FullName, true);
                    }
                }
            }
        }
        public static void ExtractToFile()
        {
            using (ZipArchive archive = ZipFile.OpenRead(fileName))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    Console.WriteLine(entry.FullName);
                    if (entry.FullName.EndsWith(".json") && !entry.FullName.Contains("\\"))
                    {
                        entry.ExtractToFile(path1 + entry.FullName, true);
                    }
                }
            }
        }
        public static void Update()
        {
            string file2 = "";
            using (ZipArchive archive = ZipFile.Open(fileName, ZipArchiveMode.Update))
            {
                foreach (string file1 in Directory.GetFiles(path2))
                {
                    file2 = file1.Replace(path2, "");
                    archive.GetEntry(file2).Delete();
                    archive.CreateEntryFromFile(file1, file2);
                }

            }

        }
    }
}
