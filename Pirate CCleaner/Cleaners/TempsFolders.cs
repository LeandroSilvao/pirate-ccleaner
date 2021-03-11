using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirate_CCleaner.Tracer;

namespace Pirate_CCleaner.Cleaners
{
    class TempsFolders
    {
        LogTracer Log;
        Info _Info;
        Utils _Utils = new Utils();

        public TempsFolders(LogTracer _LogTracer, Info Info)
        {
            Log = _LogTracer;
            _Info = Info;
            _Info.Disks = DriveInfo.GetDrives();
            _Info.TempsPath = new List<string>();

            foreach (DriveInfo drive in _Info.Disks)
            {
                var UserPath = new DirectoryInfo($"{drive}Users");
                if (UserPath.Exists)
                {
                    foreach (DirectoryInfo folder in UserPath.GetDirectories())
                    {
                        var AppDataPath = new DirectoryInfo($"{UserPath}\\{folder}\\AppData\\Local\\Temp");
                        if (AppDataPath.Exists)
                        {
                            _Info.TempsPath.Add(AppDataPath.FullName);
                        }
                    }
                }
            }
        }

        public void Delete()
        {
            Log.WriteLine("Clearing temp folders...", "info");
            Log.WriteLine($"-----------------", "info");
            foreach (string Path in _Info.TempsPath)
            {
                var TempFolder = new DirectoryInfo(Path);
                Log.WriteLine($"{Path} - Total File and Folder {TempFolder.GetFiles().Length + TempFolder.GetDirectories().Length}", "info");
                _Utils.ClearFolder(Path);
                Log.WriteLine($"{Path} - Cleared", "info");
                Log.WriteLine($"Remaining files and folders: {TempFolder.GetFiles().Length + TempFolder.GetDirectories().Length}", "info");
                Log.WriteLine($"-----------------", "info");
            }
            Log.WriteLine("All Temp folders was cleared", "info");
        }


    }
}
