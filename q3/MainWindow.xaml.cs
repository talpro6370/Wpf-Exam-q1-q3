using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Shapes;

namespace q3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm;
        public MainWindow()
        {
            vm = new MainWindowViewModel();
            InitializeComponent();
            this.DataContext = vm;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = "";

            pressToStartBtn.IsEnabled = false;
            string url = userResult.Text;

            Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    text = client.DownloadString(url);
                }

                int size = System.Text.ASCIIEncoding.ASCII.GetByteCount(text); // casting from ascii table.

                Action uiwork = () =>
                {

                    resultTxtBlock.Text = $"The size is: {size} bytes";
                    pressToStartBtn.IsEnabled = true;
                };

                SafeInvoke(uiwork);
            });
        }
        private void SafeInvoke(Action action)
        {
            if (Dispatcher.CheckAccess())
            {
                action.Invoke();
                return;
            }
            this.Dispatcher.BeginInvoke(action);
        }
    }
}
