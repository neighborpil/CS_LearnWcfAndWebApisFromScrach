using System;
using System.CodeDom;
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
            //Uri httpBaseAddress = new Uri("http://localhost:50010");
            Uri httpBaseAddress = new Uri("http://localhost:50010/MyHttpEndPoint");
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:50011");
            var serviceHost = new ServiceHost(typeof(MultipleService), new Uri[]{ tcpBaseAddress , httpBaseAddress});

            // 파라미터(CBA순이다. Contract, Binding, Address)
            //var serviceEndpoint =
            //    serviceHost.AddServiceEndpoint(typeof(IMultipleService), new WSHttpBinding(), baseAddress);
            var tcpServiceEndpoint =
                serviceHost.AddServiceEndpoint(typeof(IMultipleService), new NetTcpBinding(), tcpBaseAddress);
            var httpServiceEndpoint =
                serviceHost.AddServiceEndpoint(typeof(IMultipleService), new BasicHttpBinding(), httpBaseAddress);

            // 만약 binding을 등록하지 않으면 BasicHttpBinding이 된다

            /*
            var serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceMetadataBehavior.HttpGetEnabled = true; // true : Human readable format, false: Machine readable format
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
            */
            // 만약 httpGetEnabled가 false일 경우
            var serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceMetadataBehavior.HttpGetEnabled = false; // true : Human readable format, false: Machine readable format
            serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);

            var httpServiceEndpointMex = serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexHttpBinding(), "http://localhost:50010/MyHttpEndPoint/mex");


            var tcpServiceEndpointMex = serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexTcpBinding(), "net.tcp://localhost:50011/mex");


            serviceHost.Open(); // 실행 위해 관리자 모드 필요

            Console.WriteLine("Started");
            foreach (var endpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine($"Address: {endpoint.Address}");
                Console.WriteLine($"Binding: {endpoint.Binding.Name}");
                Console.WriteLine($"Contract: {endpoint.Contract.Name}");
            }

            Console.ReadLine();

            serviceHost.Close();


        }
    }
}
