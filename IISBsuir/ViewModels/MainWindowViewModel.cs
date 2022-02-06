using System.Windows.Media;
using IISBsuir.ViewModels.Base;

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

    }
}