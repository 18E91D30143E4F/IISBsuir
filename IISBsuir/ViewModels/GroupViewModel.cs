using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Windows.Input;
using BsuirHelper.Models;
using IISBsuir.Infrastructure.Commands;
using IISBsuir.Services;
using IISBsuir.ViewModels.Base;

namespace IISBsuir.ViewModels
{
    internal class GroupViewModel : ViewModel
    {
        private DataService _dataService;

        public MainWindowViewModel _mainModel { get; }

        #region Groups : <Group>

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
            _group = _dataService.BsuirClient.GetGroupInfoAsync().Result;
        }

        #endregion

        public GroupViewModel(MainWindowViewModel mainModel)
        {
            _mainModel = mainModel;

            _dataService = DataService.BuildDataService().Result;

            #region Команды

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

            #endregion
        }
    }
}