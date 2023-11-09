using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provodnik
{
    internal class Explorer
    {
        public static List<DriveInfo> GetDrives()
        {
            Arrow arrow = new Arrow(0, 0);
            List<DriveInfo> drives = new List<DriveInfo>(DriveInfo.GetDrives());
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Этот компьютер");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            foreach (DriveInfo drive in drives)
                Console.WriteLine("  " + drive + "  Свободно " + drive.TotalFreeSpace / 1073741824 + " ГБ из " + drive.TotalSize / 1073741824);
            return drives;
        }

        public static void GetFiles(string path)
        {
            while (true)
            {
                int position;
                Arrow arrow = new Arrow(0, 0);
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("Проводник");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                Console.Write("  Название");
                Console.SetCursorPosition(70, 2);
                Console.WriteLine("Дата создания");
                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                //files = Explorer.GetFiles(path);
                int length = 2;
                foreach (string directory in directories)
                {
                    length++;

                    Console.Write("  " + directory);
                    Console.SetCursorPosition(70, length);
                    Console.WriteLine(File.GetCreationTime(directory));
                }
                foreach (string file in files)
                {
                    length++;
                    Console.WriteLine("  " + file);
                    Console.SetCursorPosition(70, length);
                    Console.WriteLine(File.GetCreationTime(file));
                }
                arrow = new Arrow(3, length);
                position = arrow.CheckPos() - 3;
                if (position != -3)
                {
                    if (directories.Length >= position && directories.Length > 0)
                    {
                        Explorer.GetFiles(directories[position]);
                    }
                    else
                    {
                        Process.Start(new ProcessStartInfo { FileName = files[position - directories.Length], UseShellExecute = true });
                    }
                }
                else
                {
                    return;
                }
                //return Files;
            }
        }
    }
}