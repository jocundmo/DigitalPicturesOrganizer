using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DigitalPicturesOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string currentDir = Directory.GetCurrentDirectory();
            SortedSet<string> sorted = new SortedSet<string>();
            string[] existingFiles = Directory.GetFiles(currentDir, "???.*");

            if (!int.TryParse(Path.GetFileNameWithoutExtension(existingFiles[existingFiles.Length - 1]), out counter))
                throw new Exception(string.Format("{0} is not a recorgnized format like '016.jpg'"));

            counter++;
            //foreach (string s in existingFiles)
            //{
            //    sorted.Add(s);
            //}
            string[] subDirs = Directory.GetDirectories(currentDir);
            foreach (string dir in subDirs)
            {
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    File.Move(file, Path.Combine(currentDir, GetFileName(counter) + Path.GetExtension(file)));
                    counter++;
                }
            }
        }

        public static string GetFileName(int counter)
        {
            counter++;
            return string.Format(counter.ToString("000"));
        }
    }
}
