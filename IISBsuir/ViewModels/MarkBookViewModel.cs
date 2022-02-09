using System.Threading.Tasks;
using IISBsuir.Services;
using IISBsuir.ViewModels.Base;
using IIsHelper.Models;

namespace IISBsuir.ViewModels
{
    internal class MarkBookViewModel : ViewModel
    {
        public MainWindowViewModel MainModel { get; }

        private DataService _dataService;

        #region Список отметок по семестрам

        private MarkBook _markBook;

        public MarkBook MarkBook
        {
            get => _markBook;
            set => Set(ref _markBook, value);
        }

        #endregion

        /// <summary>
        /// Отладочный конструктор
        /// </summary>
        public MarkBookViewModel() : this(null)
        {
            MarkBook = Task.Run(_dataService.BsuirClient.GetMarkBookAsync).Result;
        }

        public MarkBookViewModel(MainWindowViewModel mainWindowModel)
        {
            _dataService = Task.Run(DataService.GetInstance).Result;
            MainModel = mainWindowModel;
        }
    }
}