using Library.Wpf.ServiceReference1;
using Library.Wpf.ServiceReference2;

namespace Library.Wpf.Infrastructure.Interfaces
{
    public interface IServiceManager
    {
        CalculatorClient GetTestService();

        BooksServiceClient GetBooksService();
    }
}
