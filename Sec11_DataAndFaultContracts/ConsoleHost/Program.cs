using MulServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpBaseAddress = new Uri("http://localhost:50011/MyHttpEndPoint");

            var serviceHost = new ServiceHost(typeof(MulService), httpBaseAddress);

            var basicHttpBinding = new BasicHttpBinding();

            var serviceEndpoint = serviceHost.AddServiceEndpoint(typeof(IMulService), basicHttpBinding, httpBaseAddress);

            var serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceMetadataBehavior.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);

            serviceHost.Open();

            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"Address: {endpoint.Address}");
                Console.WriteLine($"Binding: {endpoint.Binding.Name}");
                Console.WriteLine($"Contract: {endpoint.Contract.Name}");
                Console.WriteLine($"OpenTimeout: {endpoint.Binding.OpenTimeout}");
                Console.WriteLine($"CloseTimeout: {endpoint.Binding.CloseTimeout}");
            }

            Console.ReadKey();

            serviceHost.Close();

        }
    }
}
