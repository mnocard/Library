using Library.Wpf.Infrastructure.Interfaces;
using Library.Wpf.ServiceReference1;

namespace Library.Wpf.Infrastructure.Services
{
    class ServiceManager : IServiceManager
    {
        private CalculatorClient _CalculatorClient;
        public ServiceManager()
        {
            _CalculatorClient = new CalculatorClient();
        }
        public CalculatorClient GetTestService()
        {
            return _CalculatorClient;
        }
    }
}
