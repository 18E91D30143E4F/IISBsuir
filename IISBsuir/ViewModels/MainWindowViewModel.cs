using IISBsuir.Infrastructure.Commands;
using IISBsuir.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace IISBsuir.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public GroupViewModel GroupView { get; }
        public ProfileViewModel ProfileView { get; }
        public MarkBookViewModel MarkBookView { get; }
        public StudyViewModel StudyView { get; }

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
            GroupView = new GroupViewModel(this);
            ProfileView = new ProfileViewModel(this);
            MarkBookView = new MarkBookViewModel(this);
            StudyView = new StudyViewModel(this);

            #region Команды

            CloseApplicationCommand =
              new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion
        }
    }
}