using Library.WcfService.Host.DBService;
using System.Threading.Tasks;

namespace Library.WcfService.Host
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await BooksService.BooksDBInitialize(args);

            //var th = new TestHost();
            //await Task.Run(() => th.Initialize());
        }
    }
}