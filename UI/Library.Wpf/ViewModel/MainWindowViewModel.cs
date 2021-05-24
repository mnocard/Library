using DOfficeCore.Infrastructure.Commands;
using DOfficeCore.ViewModels.Core;
using Library.Wpf.Infrastructure.Interfaces;
using Library.Wpf.ServiceReference2;

using System.Collections.Generic;
using System.Windows.Input;

namespace Library.Wpf.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Поля
        private IServiceManager _ServiceManager;
        #endregion

        public MainWindowViewModel(IServiceManager serviceManager)
        {
            _ServiceManager = serviceManager;

            #region Команды
            ChangeTitleCommand = new LambdaCommand(OnChangeTitleCommandExecuted, CanChangeTitleCommandExecute);
            ServiceAddTestCommand = new LambdaCommand(OnServiceAddTestCommandExecuted, CanServiceAddTestCommandExecute);
            GetBooksWithoutAuthorCommand = new LambdaCommand(OnGetBooksWithoutAuthorCommandExecuted, CanGetBooksWithoutAuthorCommandExecute);
            GetBooksWithFewGenresCommand = new LambdaCommand(OnGetBooksWithFewGenresCommandExecuted, CanGetBooksWithFewGenresCommandExecute);
            GetPublichsersBooksCommand = new LambdaCommand(OnGetPublichsersBooksCommandExecuted, CanGetPublichsersBooksCommandExecute);
            #endregion
        }

        #region Свойства

        #region BooksWithoutAuthors : IEnumerable<Book> - Книги

        /// <summary>Книги без авторов</summary>
        private IEnumerable<BookType> _Books;

        /// <summary>Книги без авторов</summary>
        public IEnumerable<BookType> Books
        {
            get => _Books;
            set => Set(ref _Books, value);
        }

        #endregion

        #region Publishers : IEnumerable<PublisherType> - Издательства

        /// <summary>Издательства</summary>
        private IEnumerable<PublisherType> _Publishers;

        /// <summary>Издательства</summary>
        public IEnumerable<PublisherType> Publishers
        {
            get => _Publishers;
            set => Set(ref _Publishers, value);
        }

        #endregion

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
            var service = _ServiceManager.GetTestService();
            NumB = service.Add(double.Parse(NumA), double.Parse(NumB)).ToString();
        }

        private bool CanServiceAddTestCommandExecute(object parameter) => true;


        #endregion

        #region Получение книг, у которых не указан автор
        /// <summary>Получение книг, у которых не указан автор</summary>
        public ICommand GetBooksWithoutAuthorCommand { get; }
        /// <summary>Получение книг, у которых не указан автор</summary>
        private void OnGetBooksWithoutAuthorCommandExecuted(object parameter)
        {
            var service = _ServiceManager.GetBooksService();
            Books = service.GetBooksWithoutAuthor();
        }
        private bool CanGetBooksWithoutAuthorCommandExecute(object parameter) => true;

        #endregion

        #region Получение книг, у которых несколько авторов
        /// <summary>Получение книг, у которых несколько авторов</summary>
        public ICommand GetBooksWithFewGenresCommand { get; }
        /// <summary>Получение книг, у которых несколько авторов</summary>
        private void OnGetBooksWithFewGenresCommandExecuted(object parameter)
        {
            var service = _ServiceManager.GetBooksService();
            Books = service.GetBooksWithFewGenres();
        }
        private bool CanGetBooksWithFewGenresCommandExecute(object parameter) => true;

        #endregion

        #region Количество книг, написанных в определенном жанре для каждого из издательств
        /// <summary>Количество книг, написанных в определенном жанре для каждого из издательств</summary>
        public ICommand GetPublichsersBooksCommand { get; }
        /// <summary>Количество книг, написанных в определенном жанре для каждого из издательств</summary>
        private void OnGetPublichsersBooksCommandExecuted(object parameter)
        {
            var service = _ServiceManager.GetBooksService();
            Publishers = service.GetPublichsersBooks();
        }
        private bool CanGetPublichsersBooksCommandExecute(object parameter) => true;

        #endregion

        #endregion
    }
}
