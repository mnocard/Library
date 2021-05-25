using DOfficeCore.Infrastructure.Commands;
using DOfficeCore.ViewModels.Core;

using Library.Wpf.Infrastructure.Interfaces;
using Library.Wpf.Model;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Controls;
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

        #region DataTable : DataTable - Данные для таблицы издателств с количество книг по жанрам

        /// <summary>Данные для таблицы издателств с количество книг по жанрам</summary>
        private DataTable _DataTable;

        /// <summary>Данные для таблицы издателств с количество книг по жанрам</summary>
        public DataTable DataTable
        {
            get => _DataTable;
            set => Set(ref _DataTable, value);
        }

        #region BooksWithoutAuthors : ObservableCollection<Book> - Книги

        /// <summary>Книги без авторов</summary>
        private ObservableCollection<Book> _Books;

        /// <summary>Книги без авторов</summary>
        public ObservableCollection<Book> Books
        {
            get => _Books;
            set => Set(ref _Books, value);
        }

        #endregion

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
            Books = new ObservableCollection<Book>(service.GetBooksWithoutAuthor().Select(b => b.ToVM()));
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
            Books = new ObservableCollection<Book>(service.GetBooksWithFewGenres().Select(b => b.ToVM()));
        }
        private bool CanGetBooksWithFewGenresCommandExecute(object parameter) => true;

        #endregion

        #region Количество книг, написанных в определенном жанре для каждого из издательств
        /// <summary>Количество книг, написанных в определенном жанре для каждого из издательств</summary>
        public ICommand GetPublichsersBooksCommand { get; }
        /// <summary>Количество книг, написанных в определенном жанре для каждого из издательств</summary>
        private void OnGetPublichsersBooksCommandExecuted(object parameter)
        {
            if (parameter is DataGrid dgrdMaGrid)
            {
                var service = _ServiceManager.GetBooksService();
                var publishers = service.GetPublichsersBooks().Select(b => b.ToVM()).ToList();
                var genres = publishers.SelectMany(p => p.Books.SelectMany(b => b.Genres.Select(g => g.GenreName))).Distinct().ToList();

                DataTable = new DataTable();
                DataTable.Columns.Add(new DataColumn("Издатели"));
                foreach (var item in genres)
                {
                    DataTable.Columns.Add(new DataColumn(item));
                }

                foreach (var publisher in publishers)
                {
                    var newRow = DataTable.NewRow();
                    newRow[0] = publisher.PublisherName;
                    for (int i = 1; i < DataTable.Columns.Count; i++)
                    {
                        newRow[i] = 0;
                        foreach (var book in publisher.Books)
                        {
                            if (book.Genres.Any(b => b.GenreName == DataTable.Columns[i].ColumnName))
                            {
                                newRow[i] = int.Parse(newRow[i].ToString()) + 1;
                            }
                        }
                    }

                    DataTable.Rows.Add(newRow);
                }
                dgrdMaGrid.ItemsSource = DataTable.AsDataView();
            }
        }
        private bool CanGetPublichsersBooksCommandExecute(object parameter) => true;

        #endregion

        #endregion
    }
}
