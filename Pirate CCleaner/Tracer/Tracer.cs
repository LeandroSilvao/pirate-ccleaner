using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirate_CCleaner.Tracer
{
    class LogTracer
    {
        private string FileName;
        public LogTracer(string fileName)
        {
            FileName = fileName;
            if (!File.Exists($"{Properties.Settings.Default.TracerPath}{fileName} - {DateTime.Now.ToString("dd.MM.yyyy")}.log")) 
            {
                try
                {
                    File.Create($"{Properties.Settings.Default.TracerPath}{fileName} - {DateTime.Now.ToString("dd.MM.yyyy")}.log").Close();
                }
                catch(Exception err)
                {
                    WriteLine(err.Message, "error");
                    throw (err);
                }
            }
        }

        public void WriteLine(string txt, string Type)
        {
            switch (Type)
            {
                case "error":
                    Type = "[ERROR]";
                    break;
                case "info":
                    Type = "[INFO]";
                    break;
                case "warning":
                    Type = "[WARNING]";
                    break;
            }
            using (StreamWriter Reg = File.AppendText($"{Properties.Settings.Default.TracerPath}{FileName} - {DateTime.Now.ToString("dd.MM.yyyy")}.log"))
            {
                Reg.WriteLine($"{Type}{DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss.FFF] ")}{txt}");
                Reg.Flush();
            }
        }
    }
}
