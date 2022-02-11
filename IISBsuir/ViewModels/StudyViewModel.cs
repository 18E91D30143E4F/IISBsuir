using System.Threading.Tasks;
using IISBsuir.Services;
using IISBsuir.ViewModels.Base;
using IIsHelper.Models;

namespace IISBsuir.ViewModels
{
    internal class StudyViewModel : ViewModel
    {
        public MainWindowViewModel MainModel { get; }

        private DataService _DataService;

        #region Ведомостички

        private MarkSheet[] _MarkSheets;

        public MarkSheet[] MarkSheets
        {
            get => _MarkSheets;
            set => Set(ref _MarkSheets, value);
        }

        #endregion

        #region Справки

        private Certificate[] _Certificates;

        public Certificate[] Certificates
        {
            get => _Certificates;
            set => Set(ref _Certificates, value);
        }

        #endregion

        /// <summary>
        /// Отладочный конструктор
        /// </summary>
        public StudyViewModel() : this(null)
        {
            MarkSheets = Task.Run(_DataService.BsuirClient.GetMarkSheetAsync).Result;
            Certificates = Task.Run(_DataService.BsuirClient.GetCertificatesAsync).Result;
        }

        public StudyViewModel(MainWindowViewModel mainModel)
        {
            MainModel = mainModel;

            _DataService = Task.Run(DataService.GetInstance).Result;
        }
    }
}