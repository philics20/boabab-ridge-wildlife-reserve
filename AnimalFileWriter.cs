using boabab_ridge_wildlife_reserve;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace BaobabRidge
{
    public static class AnimalFileWriter
    {
        public static void RewriteAll(List<Animal> animals)
        {
            string path = AnimalFileReader.DataFilePath;
            string tempPath = path + ".tmp";

            using (var writer = new StreamWriter(tempPath, false, new UTF8Encoding(false)))
            {
                foreach (var a in animals)
                {
                    writer.WriteLine(a.ToFileString());
                }
            }

            if (File.Exists(path))
                File.Delete(path);
            File.Move(tempPath, path);
        }
    }
}