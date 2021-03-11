using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Pirate_CCleaner.Tracer;

namespace Pirate_CCleaner.Cleaners
{
    class CallCleaners
    {
        TempsFolders _TempsFolder;
        LogTracer Log;
        Info _Info;
        public CallCleaners(LogTracer _LogTracer)
        {
            Log = _LogTracer;
            _Info = new Info();
            _TempsFolder = new TempsFolders(_LogTracer, _Info);
        }

        public void CleanersInit()
        {
            Log.WriteLine("Method: CleanersInit, started...", "info");
            if (Properties.Settings.Default.TempFolders) _TempsFolder.Delete();
            if (Properties.Settings.Default.Trash) new Trash(Log);
            new Services(Log);
        }

    }
}
