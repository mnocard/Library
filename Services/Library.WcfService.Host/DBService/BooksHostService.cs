using Library.WcfService.Services;
using System.ServiceModel.Description;
using System.ServiceModel;
using System;
using Library.WcfService.Interfaces;

namespace Library.WcfService.Host.DBService
{
    public class BooksHostService
    {
		private const string _HostUri = "http://localhost:8733/Design_Time_Address/";
		private const string _ServiceAddress = "BooksService";

		public void Initialize()
		{
			var baseAddress = new Uri(_HostUri);
			var selfHost = new ServiceHost(typeof(Books), baseAddress);

			try
			{
				selfHost.AddServiceEndpoint(typeof(IBooks), new WSHttpBinding(), _ServiceAddress);
				var smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;
				selfHost.Description.Behaviors.Add(smb);

				selfHost.Open();
				Console.WriteLine("The BooksService is ready.\nPress <Enter> to terminate the service.");
				Console.ReadLine();
				selfHost.Close();
			}
			catch (CommunicationException ce)
			{
				Console.WriteLine("An exception occurred: {0}", ce.Message);
				Console.ReadLine();
				selfHost.Abort();
			}
		}
	}
}
