using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Pirate_CCleaner
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        static void Main()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {

#if DEBUG // Run service like DEBUG
                PirateCCleaner Service = new PirateCCleaner();
                Service.StartDebug(new string[2]);
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
               
#else //Run like release
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1()
                };
                ServiceBase.Run(ServicesToRun);
#endif

            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new PirateCCleaner()
                };
                ServiceBase.Run(ServicesToRun);
            }
            
        }
    }
}
