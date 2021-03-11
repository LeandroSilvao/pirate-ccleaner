using Pirate_CCleaner.Tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Pirate_CCleaner.Cleaners
{
    class Services
    {
        LogTracer Log;
        int Count = 0;
        bool error = false;

        public Services(LogTracer _LogTracer)
        {
            Log = _LogTracer;

            Log.WriteLine("Parando servicos desnecessarios...", "info");

            ServiceController[] WServices = ServiceController.GetServices();
            string[] CServices = Properties.Settings.Default.Services.Split(';');

            foreach (ServiceController service in WServices)
            {
                if (CServices.Contains(service.ServiceName))
                {
                    Log.WriteLine($"Checando status do servico: {service.DisplayName}...", "info");

                    if (service.Status != ServiceControllerStatus.Stopped)
                    {
                        try
                        {
                            service.Stop();
                            Log.WriteLine($"Servico: {service.DisplayName} e dependências  foram parados.", "info");
                            Count++;
                        }
                        catch (Exception ex)
                        {
                            error = true;
                            Log.WriteLine($"Erro ao parar servico: {service.DisplayName}.", "info");
                            Log.WriteLine(ex.Message, "info");
                        }
                    }
                }
            }
            if (Count > 0)
            {
                Log.WriteLine($"Quantidade de servicos parados: {Count}.", "info");
            }
            else
            {
                if (!error) Log.WriteLine($"Nenhum serviço foi parado pois todos ja estavam parados.", "info");
            }
        }
    }
}
