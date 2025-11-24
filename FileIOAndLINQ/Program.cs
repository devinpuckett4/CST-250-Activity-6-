using System;
using System.Windows.Forms;

namespace FileIOAndLINQ
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // Launch the WinForms UI (fully-qualified to avoid namespace mismatch)
            Application.Run(new FileIOAndLINQ.PresentationLayer.FrmVerseList());
        }
    }
}
