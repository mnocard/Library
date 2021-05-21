using Library.WcfService.Host.DBService;
using Library.WcfService.Host.HostService;

using System.Threading.Tasks;

namespace Library.WcfService.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bs = new BooksService();
            bs.Initialize();
        }
    }
}