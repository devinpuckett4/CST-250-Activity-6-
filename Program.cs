using System;
using System.Windows.Forms;
using FileIOAndLINQ.PresentationLayer;

namespace FileIOAndLINQ
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(new FrmVerseList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "FATAL STARTUP ERROR:\n\n" + ex.ToString(),
                    "App Crashed – Copy This Text",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}