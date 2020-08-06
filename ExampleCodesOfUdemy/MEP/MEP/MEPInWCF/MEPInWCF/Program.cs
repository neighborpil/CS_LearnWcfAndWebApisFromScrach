using MEPInWCFLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace MEPInWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri httpBaseAddress = new Uri("http://localhost:6789/");

            ServiceHost Sh = new ServiceHost(typeof(MEP), new Uri[] { httpBaseAddress });

            ServiceEndpoint Se = Sh.AddServiceEndpoint(typeof(IMEP), new WSDualHttpBinding(), httpBaseAddress);


            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            Sh.Description.Behaviors.Add(smb);

            ServiceEndpoint tcpSeMex = Sh.AddServiceEndpoint(typeof(IMetadataExchange),
                                                             MetadataExchangeBindings.CreateMexHttpBinding(),
                                                             "http://localhost:6789/mex");

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
