using DOfficeCore.Infrastructure.Commands;
using DOfficeCore.ViewModels.Core;
using Library.Wpf.Infrastructure.Interfaces;
using System.Windows.Input;

namespace Library.Wpf.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Поля
        private IServiceManager testService;
        #endregion

        public MainWindowViewModel(IServiceManager serviceManager)
        {
            testService = serviceManager;

            #region Команды
            ChangeTitleCommand = new LambdaCommand(OnChangeTitleCommandExecuted, CanChangeTitleCommandExecute);
            ServiceAddTestCommand = new LambdaCommand(OnServiceAddTestCommandExecuted, CanServiceAddTestCommandExecute);
            #endregion
        }

        #region Свойства
        #region Тест

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


        #region NumA : string - Первое число

        /// <summary>Первое число</summary>
        private string _NumA;

        /// <summary>Первое число</summary>
        public string NumA
        {
            get => _NumA;
            set => Set(ref _NumA, value);
        }

        #endregion

        #region NumB : string - Второе число

        /// <summary>Второе число</summary>
        private string _NumB;

        /// <summary>Второе число</summary>
        public string NumB
        {
            get => _NumB;
            set => Set(ref _NumB, value);
        }

        #endregion

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


        #region Тест сервиса
        /// <summary>Тест сервиса</summary>
        public ICommand ServiceAddTestCommand { get; }
        /// <summary>Тест сервиса</summary>
        private void OnServiceAddTestCommandExecuted(object parameter)
        {
            var service = testService.GetTestService();

            NumB = service.Add(double.Parse(NumA), double.Parse(NumB)).ToString();
        }

        private bool CanServiceAddTestCommandExecute(object parameter) => true;


        #endregion
        #endregion
    }
}
