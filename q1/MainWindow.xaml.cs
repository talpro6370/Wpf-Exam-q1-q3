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
using System.Windows.Shapes;

namespace q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void ILoveWpfBtn_Click(object sender, RoutedEventArgs e)
        {
            NewWindow s = new NewWindow($"Height slider value is: { heightSliderStatus.Text }", $"Width slider value is: { widthSliderStatus.Text }", $"Text is: { btnContentTxtBox.Text }");
            s.Show();
            myMainWin.Visibility = Visibility.Hidden;

        }
    }
}
