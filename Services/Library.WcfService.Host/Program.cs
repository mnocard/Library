using Library.WcfService.Host.HostService;
using Library.WcfService.Interfaces;
using Library.WcfService.Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Threading.Tasks;

namespace Library.WcfService.Host
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var th = new TestHost();
            await Task.Run(() => th.Initialize());


        }
    }
}