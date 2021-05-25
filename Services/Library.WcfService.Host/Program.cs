using Library.DAL;
using Library.WcfService.Host.DBService;

namespace Library.WcfService.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BooksDBInitializer.BooksDBCreate();
            //BooksDBInitializer.ChangeDBCollate();
            //BooksDBInitializer.FillDbWithSqlScript();

            var bs = new BooksService();
            bs.Initialize();
        }
    }
}