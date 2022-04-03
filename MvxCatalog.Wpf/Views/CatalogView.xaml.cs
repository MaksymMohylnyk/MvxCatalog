using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Threading;
using System.Globalization;

namespace MvxCatalog.Wpf.Views
{
    /// <summary>
    /// Логика взаимодействия для CatalogView.xaml
    /// </summary>
    public partial class CatalogView : MvxWpfView
    {
        public CatalogView()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.Language);
            InitializeComponent();
        }

        private bool flag = false;
        private string langType = "ru-RU";

        private void StyleButton_Click(object sender, RoutedEventArgs e)
        {
            //Uri в цикле это relative uri с ним if не работает

            if (flag == false)
            {
                Uri uri = new Uri("Styles/DarkTheme.xaml", UriKind.Relative);

                ResourceDictionary dictionary = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dictionary);

                flag = true;
            }
            else
            {
                Uri uri = new Uri("Styles/WhiteTheme.xaml", UriKind.Relative);

                ResourceDictionary dictionary = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dictionary);

                flag = false;
            }
        }

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            if (langType == "ru-RU")
                langType = "en";
            else
                langType = "ru-RU";
            MainWindow.ChangeLocalization(langType);
        }
    }
}
