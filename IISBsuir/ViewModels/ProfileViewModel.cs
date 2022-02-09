using System.Net.Http;
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
        public MainWindowViewModel MainModel { get; }

        private DataService _dataService;

        #region Свойства

        #region Информация о студенте

        private StudentInfo _studentInfo;
        public StudentInfo StudentInfo
        {
            get => _studentInfo;
            set => Set(ref _studentInfo, value);
        }

        #endregion

        #region Статус последнего запроса

        private HttpResponseMessage _lastResponseMessage;
        public HttpResponseMessage LastResponseMessage
        {
            get => _lastResponseMessage;
            set => Set(ref _lastResponseMessage, value);
        }

        #endregion

        #endregion

        #region Команды

        public ICommand RefreshDataCommand { get; }
        private void OnRefreshDataCommandExecuted(object p)
        {
            StudentInfo = Task.Run(_dataService.BsuirClient.GetUserInfoAsync).Result;
            // if (_dataService != null)
            //   Task.Run(_dataService.BsuirClient.GetUserInfoAsync)
            //      .ContinueWith(task => StudentInfo = task.Result);
        }

        public ICommand SendUserProfileCommand { get; }
        private void OnSendUserProfileCommandExecuted(object p)
        {
            var studInfo = p as StudentInfo;
            LastResponseMessage = Task.Run(() => _dataService.BsuirClient.PutStudentInfoAsync(studInfo)).Result;
            // if (_dataService != null)
            //   Task.Run(() => _dataService.BsuirClient.PutStudentInfoAsync(studInfo))
            //      .ContinueWith(task => LastResponseMessage = task.Result);
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
            //Task.Run(DataService.GetInstance)
            //  .ContinueWith(task => _dataService = task.Result);

            //_studentInfo = Task.Run(_dataService.BsuirClient.GetUserInfoAsync).Result;

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);
            SendUserProfileCommand = new LambdaCommand(OnSendUserProfileCommandExecuted);
        }
    }
}