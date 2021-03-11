using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirate_CCleaner.Cleaners
{
    class Utils
    {
        public void ClearFolder(string Path)
        {
            DirectoryInfo dir = new DirectoryInfo(Path);
            try
            {
                foreach (FileInfo fi in dir.GetFiles())
                {
                    try { fi.Delete(); }
                    catch (IOException ex) { }
                    catch (Exception ex) { }
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    ClearFolder(di.FullName);
                    try { di.Delete(); }
                    catch (IOException ex) { }
                    catch (Exception ex) { }
                }
            }
            catch (IOException ex) { }
            catch (Exception ex) { }
        }
    }
}
