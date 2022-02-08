using System.Threading.Tasks;
using IISBsuir.Infrastructure.Commands;
using IISBsuir.Services;
using IISBsuir.ViewModels.Base;
using IIsHelper.Models;
using System.Windows.Input;

namespace IISBsuir.ViewModels
{
    internal class GroupViewModel : ViewModel
    {
        private DataService _dataService;

        public MainWindowViewModel _mainModel { get; }

        #region Group

        private Group _group;

        public Group Group
        {
            get => _group;
            private set => Set(ref _group, value);
        }

        #endregion


        #region Команды

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Group = Task.Run(_dataService.BsuirClient.GetGroupInfoAsync).Result;
        }

        #endregion

        /// <summary>
        /// Отладочный конструктор, для визуального дизайнера
        /// </summary>
        public GroupViewModel() : this(null)
        {
        }

        public GroupViewModel(MainWindowViewModel mainModel)
        {
            _mainModel = mainModel;

            _dataService = Task.Run(DataService.GetInstance).Result;

            #region Команды

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

            #endregion
        }
    }
}