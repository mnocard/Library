using Library.WcfService.Host.DBService;
using Library.WcfService.Host.HostService;

using System.Threading.Tasks;

namespace Library.WcfService.Host
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            BooksService.BooksDBCreate(args);
            BooksService.ChangeDBCollate(args);
            BooksService.FillDbWithSqlScript(args);

            var th = new TestHost();
            await Task.Run(() => th.Initialize());
        }
    }
}