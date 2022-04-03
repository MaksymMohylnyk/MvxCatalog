using MvvmCross.Platforms.Wpf.Views;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace MvxCatalog.Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MvxWindow
    {
        public MainWindow()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.Language);
            InitializeComponent();
        }

        public static void ChangeLocalization(string cultureAndLanguage)
        {
            Properties.Settings.Default.Language = cultureAndLanguage;
            Properties.Settings.Default.Save();

            MessageBox.Show("Restart app to change language", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
