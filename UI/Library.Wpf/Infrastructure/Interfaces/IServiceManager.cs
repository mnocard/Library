using Library.Wpf.ServiceReference1;

namespace Library.Wpf.Infrastructure.Interfaces
{
    public interface IServiceManager
    {
        CalculatorClient GetTestService();
    }
}
