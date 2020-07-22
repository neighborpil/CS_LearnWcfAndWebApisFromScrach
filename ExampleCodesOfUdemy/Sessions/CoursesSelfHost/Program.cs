using CoursesServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri tcpBaseAddress = new Uri("net.tcp://localhost:6789/");

            //Uri httpBaseAddress = new Uri("http://localhost:6790");

            ServiceHost Sh = new ServiceHost(typeof(Courses), new Uri[] { tcpBaseAddress});

            var tcpBinding = new NetTcpBinding();
            tcpBinding.ReceiveTimeout = new TimeSpan(0, 1, 0);
            ServiceEndpoint Se = Sh.AddServiceEndpoint(typeof(ICourses),tcpBinding , tcpBaseAddress);

            //ServiceEndpoint httpSe = Sh.AddServiceEndpoint(typeof(ICourses), new BasicHttpBinding(), httpBaseAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            Sh.Description.Behaviors.Add(smb);

            ServiceEndpoint tcpSeMex = Sh.AddServiceEndpoint(typeof(IMetadataExchange),
                                                             MetadataExchangeBindings.CreateMexTcpBinding(),
                                                             "net.tcp://localhost:6789/mex");

            Sh.Open();

            Console.WriteLine("Started.....");

            foreach (var item in Sh.Description.Endpoints)
            {
                Console.WriteLine("Address: " + item.Address.ToString());
                Console.WriteLine("Binding: " + item.Binding.Name.ToString());
                Console.WriteLine("Contract: " + item.Contract.Name.ToString());
            }

            Console.ReadLine();

            Sh.Close();
        }
    }
}
