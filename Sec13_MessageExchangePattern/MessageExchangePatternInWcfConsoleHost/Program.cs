using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using MessageExchangePatternInWcfLibrary;

namespace MessageExchangePatternInWcfConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpBaseAddress = new Uri("http://localhost:50010/");

            var serviceHost = new ServiceHost(typeof(MessageExchangePattern), new Uri[] {httpBaseAddress});
            var serviceEndpoint =
                serviceHost.AddServiceEndpoint(typeof(IMessageExchangePattern), new BasicHttpBinding(), httpBaseAddress);

            var serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);

            var tcpServiceEndpointMex = serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexTcpBinding(), "http://localhost:50010/mex");

            serviceHost.Open();

            Console.WriteLine("[WCF Started]");

            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine($"Address: {endpoint.Address}");
                Console.WriteLine($"Binding: {endpoint.Binding.Name}");
                Console.WriteLine($"Contract: {endpoint.Contract.Name}");
            }

            Console.ReadKey();

            Console.WriteLine("[WCF Ended]");
            serviceHost.Close();
        }
    }
}
