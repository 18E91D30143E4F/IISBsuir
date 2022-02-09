using System.Threading.Tasks;
using System.Windows.Input;
using IISBsuir.Infrastructure.Commands;
using IISBsuir.Services;
using IISBsuir.ViewModels.Base;
using IIsHelper.Models;

namespace IISBsuir.ViewModels
{
    internal class ProfileViewModel : ViewModel
    {
        private readonly DataService _dataService;
        public MainWindowViewModel MainModel { get; }

        #region Информация о студенте

        private StudentInfo _studentInfo;
        public StudentInfo StudentInfo
        {
            get => _studentInfo;
            set => Set(ref _studentInfo, value);
        }

        #endregion

        #region Команды

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            StudentInfo = Task.Run(_dataService.BsuirClient.GetUserInfoAsync).Result;
        }

        public ICommand SendUserProfileCommand { get; }

        private void OnSendUserProfileCommandExecuted(object p)
        {
            var studInfo = p as StudentInfo;

            Task.Run(() => _dataService.BsuirClient.PutStudentInfoAsync(studInfo));
        }

        #endregion

        /// <summary>
        /// Отладочный конструктор для дизайнера
        /// </summary>
        public ProfileViewModel() : this(null)
        {
            _studentInfo = Task.Run(DataService.GetInstance().BsuirClient.GetUserInfoAsync).Result;
        }

        public ProfileViewModel(MainWindowViewModel mainWindowView)
        {
            MainModel = mainWindowView;

            _dataService = Task.Run(DataService.GetInstance).Result;
            _studentInfo = Task.Run(_dataService.BsuirClient.GetUserInfoAsync).Result;

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
            SendUserProfileCommand = new LambdaCommand(OnSendUserProfileCommandExecuted);
        }
    }
}