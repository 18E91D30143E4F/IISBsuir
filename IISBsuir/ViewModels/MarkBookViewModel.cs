using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using IISBsuir.Infrastructure.Commands;
using IISBsuir.Services;
using IISBsuir.ViewModels.Base;
using IIsHelper.Models;

namespace IISBsuir.ViewModels
{
    internal class MarkBookViewModel : ViewModel
    {
        public MainWindowViewModel MainModel { get; }

        private DataService _dataService;

        #region Выделенная страница

        private string _selectedPageKey;
        public string SelectedPageKey
        {
            get => _selectedPageKey;
            set
            {
                Set(ref _selectedPageKey, value);
                OnPropertyChanged(nameof(SelectedMarkPage));
            }
        }

        private MarkPage _selectedPage;
        public MarkPage SelectedMarkPage
        {
            get => MarkBook.MarkPages[SelectedPageKey];
            set => Set(ref _selectedPage, value);
        }

        #endregion

        #region Список отметок по семестрам

        private MarkBook _markBook;
        public MarkBook MarkBook
        {
            get => _markBook;
            set => Set(ref _markBook, value);
        }

        #endregion

        #region Команды

        public ICommand EditComboCommand { get; }

        private void OnEditCombodCommandExecuted(object p)
        {
            int a = 5;
            //Group = Task.Run(_dataService.BsuirClient.GetGroupInfoAsync).Result;
        }

        #endregion

        /// <summary>
        /// Отладочный конструктор
        /// </summary>
        public MarkBookViewModel() : this(null)
        {
            MarkBook = Task.Run(_dataService.BsuirClient.GetMarkBookAsync).Result;
            SelectedPageKey = MarkBook.MarkPages.Keys
                .FirstOrDefault();
        }

        public MarkBookViewModel(MainWindowViewModel mainWindowModel)
        {
            _dataService = Task.Run(DataService.GetInstance).Result;
            MarkBook = Task.Run(_dataService.BsuirClient.GetMarkBookAsync).Result;
            SelectedPageKey = MarkBook.MarkPages.Keys
              .FirstOrDefault();
            MainModel = mainWindowModel;

            EditComboCommand = new LambdaCommand(OnEditCombodCommandExecuted);
        }
    }
}