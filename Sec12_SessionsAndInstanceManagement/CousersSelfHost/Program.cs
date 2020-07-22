using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using CourseServiceLibrary;

namespace CousersSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:50001");
            Uri httpBaseAddress = new Uri("http://localhost:50002");

            var serviceHost = new ServiceHost(typeof(Courses), new Uri[] {tcpBaseAddress, httpBaseAddress});

            var tcpBinding = new NetTcpBinding();
            tcpBinding.ReceiveTimeout = new TimeSpan(0, 1, 0);

            var tcpServiceEndpoint = serviceHost.AddServiceEndpoint(typeof(ICourses), tcpBinding, tcpBaseAddress);
            var httpServiceEndpoint =
                serviceHost.AddServiceEndpoint(typeof(ICourses), new BasicHttpBinding(), httpBaseAddress);

            var serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);

            var tcpServiceMexEndpoint = serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexTcpBinding(),
                "net.tcp://localhost:50001/mex");

            serviceHost.Open();

            Console.WriteLine("Started.....");

            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine("Address: " + endpoint.Address.ToString());
                Console.WriteLine("Binding: " + endpoint.Binding.Name.ToString());
                Console.WriteLine("Contract: " + endpoint.Contract.Name.ToString());
            }

            Console.ReadKey();

            serviceHost.Close();
        }
    }
}
