using System;
using System.IO;

namespace ELearning.Commons
{
    public class MyDataHandler
    {
        //public static void DirectoryCopy(string strSource, string Copy_dest)
        //{
        //    DirectoryInfo dirInfo = new DirectoryInfo(strSource);

        //    DirectoryInfo[] directories = dirInfo.GetDirectories();

        //    FileInfo[] files = dirInfo.GetFiles();

        //    foreach (DirectoryInfo tempdir in directories)
        //    {
        //        Console.WriteLine(strSource + "/" + tempdir);

        //        Directory.CreateDirectory(Copy_dest + "/" + tempdir.Name);// creating the Directory   

        //        var ext = System.IO.Path.GetExtension(tempdir.Name);

        //        if (System.IO.Path.HasExtension(ext))
        //        {
        //            foreach (FileInfo tempfile in files)
        //            {
        //                tempfile.CopyTo(Path.Combine(strSource + "/" + tempfile.Name, Copy_dest + "/" + tempfile.Name));

        //            }
        //        }
        //        DirectoryCopy(strSource + "/" + tempdir.Name, Copy_dest + "/" + tempdir.Name);

        //    }

        //    FileInfo[] files1 = dirInfo.GetFiles();

        //    foreach (FileInfo tempfile in files1)
        //    {
        //        tempfile.CopyTo(Path.Combine(Copy_dest, tempfile.Name));

        //    }
        //}

        public static void  CopyDir(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(sourceFolder))
            {
                return;
            }
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            // Get Files & Copy
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);

                // ADD Unique File Name Check to Below!!!!
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }

            // Get dirs recursively and copy files
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyDir(folder, dest);
            }
        }

        public static void MoveDir(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(sourceFolder))
            {
                return;
            }
            CopyDir(sourceFolder, destFolder);
            Directory.Delete(sourceFolder, true);
        }

    }
}
