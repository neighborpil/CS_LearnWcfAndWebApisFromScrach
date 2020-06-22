using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using MultipleWcfServiceLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:50010");
            var serviceHost = new ServiceHost(typeof(MultipleService), baseAddress);

            // 파라미터(CBA순이다. Contract, Binding, Address)
            var serviceEndpoint =
                serviceHost.AddServiceEndpoint(typeof(IMultipleService), new WSHttpBinding(), baseAddress);

            var serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceMetadataBehavior.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);

            serviceHost.Open();

            Console.WriteLine("Started");
            Console.ReadLine();

            serviceHost.Close();


        }
    }
}
