using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ColorContraster
{
    /// <summary>
    /// Logique d'interaction pour AProposDe.xaml
    /// </summary>
    public partial class AProposDe : Window
    {
        public AProposDe()
        {
            InitializeComponent();
            DataContext = new ViewModels.AboutVM();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoLink(object sender, MouseButtonEventArgs e)
        {
            if(sender is TextBlock tb)
            {
                string url = tb.Text;
                OpenBrowser(url);
            }
        }

        private static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
