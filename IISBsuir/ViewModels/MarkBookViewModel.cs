using IISBsuir.ViewModels.Base;

namespace IISBsuir.ViewModels
{
    internal class MarkBookViewModel : ViewModel
    {
        public MainWindowViewModel MainModel { get; }

        public MarkBookViewModel(MainWindowViewModel mainWindowModel)
        {
            MainModel = mainWindowModel;
        }
    }
}