using IISBsuir.Infrastructure.Commands;
using IISBsuir.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace IISBsuir.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна

        private string _Title = "IIS Bsuir";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region Команды

        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand =
                new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion
        }
    }
}