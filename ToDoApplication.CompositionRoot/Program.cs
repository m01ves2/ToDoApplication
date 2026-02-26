using WinFormsApp = System.Windows.Forms.Application;

namespace ToDoApplication.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Main знает только CR
            var form = CompositionRoot.AppBuilder.BuildForm();
            WinFormsApp.Run(form);
        }
    }
}