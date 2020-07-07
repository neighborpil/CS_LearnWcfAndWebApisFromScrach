using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MulServiceLibrary;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // declarative endpoint is in the App.config file

            // Programmatically added endpoint
            Uri httpBaseAddress = new Uri("http://localhost:50010/MyHttpEndPoint");

            var serviceHost = new ServiceHost(typeof(MulService), httpBaseAddress);
            var serviceEndPoint =
                serviceHost.AddServiceEndpoint(typeof(IMulService), new BasicHttpBinding(), httpBaseAddress);
            
            serviceHost.Open();

            Console.WriteLine("Started...");

            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"Address: {endpoint.Address}");
                Console.WriteLine($"Binding: {endpoint.Binding.Name}");
                Console.WriteLine($"Contract: {endpoint.Contract.Name}");
            }

            Console.ReadLine();

            serviceHost.Close();
        }
    }
}
