using Provodnik;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int position;
            string path;
            List<DriveInfo> drives = new List<DriveInfo>();
            string[] files;
            Arrow arrow = new Arrow(0, 0);
            while (true)
            {
                drives = Explorer.GetDrives();
                arrow = new Arrow(2, drives.Count + 1);
                position = arrow.CheckPos();
                if (position == 0)
                {
                    Console.SetCursorPosition(0, drives.Count + 2);
                    break;
                }
                path = drives[position - 2].Name;
                Explorer.GetFiles(path);
            }
        }
    }
}