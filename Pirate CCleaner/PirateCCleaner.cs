using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Pirate_CCleaner.Tracer;
using Pirate_CCleaner.Cleaners;

namespace Pirate_CCleaner
{
    public partial class PirateCCleaner : ServiceBase
    {
        LogTracer Log;
        CallCleaners _CallCleaners;

        public PirateCCleaner()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log = new LogTracer("PirateCCleaner");
            Log.WriteLine("Iniciando Pirate CCleaner","info");

            _CallCleaners = new CallCleaners(Log);
            _CallCleaners.CleanersInit();
        }

        public void StartDebug(string[] args)
        {
            OnStart(args);
        }

        protected override void OnStop()
        {
            Log.WriteLine("Pirate CCleaner foi parado", "info");
        }

    }
}
