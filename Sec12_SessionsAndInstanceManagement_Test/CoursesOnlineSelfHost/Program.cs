using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using CourseOnlineServiceLibrary;

namespace CoursesOnlineSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqliteHelper = new SqliteHelper();
            sqliteHelper.CreateTable();

            var tcpBaseAddress = new Uri("net.tcp://localhost:50001");
            var serviceHost = new ServiceHost(typeof(CoursesOnline), new Uri[] {tcpBaseAddress});
            var serviceEndpoint =
                serviceHost.AddServiceEndpoint(typeof(ICoursesOnline), new NetTcpBinding(), tcpBaseAddress);

            var serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);

            var tctServiceEndpointMex = serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexTcpBinding(),
                "net.tcp://localhost:50001/mex");

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
