using DOfficeCore.Infrastructure.Commands;
using DOfficeCore.ViewModels.Core;
using System.Windows.Input;

namespace Library.Wpf.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            #region Команды
            ChangeTitleCommand = new LambdaCommand(OnChangeTitleCommandExecuted, CanChangeTitleCommandExecute);
            #endregion
        }

        #region Свойства

        #region Заголовок окна
        /// <summary>Заголовок окна</summary>
        private string _Title = "Библиотекарь";
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        /// <summary>Тестовый текстбокс</summary>
        private string _TbTest = "Тестовый текстбокс";
        /// <summary>Тестовый текстбокс</summary>
        public string TbTest
        {
            get => _TbTest;
            set => Set(ref _TbTest, value);
        }

        #endregion

        #endregion

        #region Команды


        #region Изменение заголовка окна
        /// <summary>Изменение заголовка окна</summary>
        public ICommand ChangeTitleCommand { get; }
        /// <summary>Изменение заголовка окна</summary>
        private void OnChangeTitleCommandExecuted(object parameter)
        {
            Title = TbTest;
        }

        private bool CanChangeTitleCommandExecute(object parameter) => true;


        #endregion
        #endregion
    }
}
