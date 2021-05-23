using Library.Wpf.Infrastructure.Interfaces;
using Library.Wpf.ServiceReference1;
using Library.Wpf.ServiceReference2;

namespace Library.Wpf.Infrastructure.Services
{
    class ServiceManager : IServiceManager
    {
        private CalculatorClient _CalculatorClient;
        private BooksServiceClient _BooksServiceClient;
        public ServiceManager()
        {
            _CalculatorClient = new CalculatorClient();
            _BooksServiceClient = new BooksServiceClient();
        }
        public CalculatorClient GetTestService()
        {
            return _CalculatorClient;
        }

        public BooksServiceClient GetBooksService()
        {
            return _BooksServiceClient;
        }
    }
}
