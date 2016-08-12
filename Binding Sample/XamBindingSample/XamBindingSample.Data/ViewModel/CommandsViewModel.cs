using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace XamBindingSample.ViewModel
{
    public class CommandsViewModel : ViewModelBase
    {
        private readonly IDialogService _dialogService;
        private RelayCommand _sayHelloCommand;
        private RelayCommand<string> _showMessageCommand;

        public RelayCommand SayHelloCommand
        {
            get
            {
                return _sayHelloCommand
                       ?? (_sayHelloCommand = new RelayCommand(
                           () =>
                           {
                               _dialogService.ShowMessage("Are you enjoying this?", "Hello Evolve!");
                           }));
            }
        }

        public RelayCommand<string> ShowMessageCommand
        {
            get
            {
                return _showMessageCommand
                       ?? (_showMessageCommand = new RelayCommand<string>(
                           message =>
                           {
                               _dialogService.ShowMessage(message, "Message:");
                           },
                           message => !string.IsNullOrEmpty(message)));
            }
        }

        public CommandsViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    }
}