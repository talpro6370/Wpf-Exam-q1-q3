using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace q1
{
    public class MainWindowViewModel
    {
        public string height { get; set; }
        public string width { get; set; }
        public string btnText { get; set; }
        public DelegateCommand delegateCommand { get; set; }

        public MainWindowViewModel()
        {
            delegateCommand = new DelegateCommand(ExecuteCommand, CanExecuteDelegateCommand);
        }
        
        private bool CanExecuteDelegateCommand()
        {
            return true;
        }
        private void ExecuteCommand()
        {
            NewWindow nWin = new NewWindow(height,width,btnText);
            nWin.Show();
        }
    }
}
