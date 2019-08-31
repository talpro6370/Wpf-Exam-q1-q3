using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prism.Commands;
namespace q3
{
    public class MainWindowViewModel
    {
        public DelegateCommand myButtonDelegateCommand { get; set; }
        private bool proccessIsOver;
        private string textResult;
        private string url { get; set; }
        public UrlResult result { get; set; }
        public MainWindowViewModel()
        {
            myButtonDelegateCommand = new DelegateCommand(ExecuteButtonDelegateCommand, CanExecuteButtonDelegateCommand);
            proccessIsOver = true;
            result = new UrlResult() { Result = "Please wait..." };
            Task.Run(() =>
            {
                while (true)
                {
                    myButtonDelegateCommand.RaiseCanExecuteChanged();
                    Thread.Sleep(300);
                }
            });
        }
        public bool CanExecuteButtonDelegateCommand()
        {
            return proccessIsOver;
        }
        private async void ExecuteButtonDelegateCommand()
        {
            proccessIsOver = false;
            await Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    textResult = client.DownloadString(url);
                }
                int urlSize = textResult.Length;
                result.Result = $"Size if : {urlSize}";
            });
            proccessIsOver = true;
        }
    }
}
