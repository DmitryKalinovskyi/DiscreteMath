using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace MatrixRelation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CultureInfo culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ".";

            // Set the current culture to the one we created
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }

}
