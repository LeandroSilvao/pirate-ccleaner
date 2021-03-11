using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Pirate_CCleaner.Tracer;

namespace Pirate_CCleaner.Cleaners
{
    class Trash
    {
        public enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000001,
            SHERB_NOSOUND = 0x00000004
        }
        LogTracer Log;
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        public static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        public Trash(LogTracer _LogTracer)
        {
            Log = _LogTracer;
            try
            {
                Log.WriteLine($"-----------------", "info");
                Log.WriteLine($"Clearing Trash...", "info");
                uint result = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION);
                Log.WriteLine($"Trash was cleared", "info");
            }
            catch (Exception ex)
            {
                Log.WriteLine($"Error on clear Trash: {ex.Message}", "error");
            }
            Log.WriteLine($"-----------------", "info");

        }
    }
}
