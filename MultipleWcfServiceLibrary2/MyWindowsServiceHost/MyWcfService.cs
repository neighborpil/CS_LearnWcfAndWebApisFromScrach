using MultipleWcfServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsServiceHost
{
    public partial class MyWcfService : ServiceBase
    {
        private ServiceHost _serviceHost = null;
        public MyWcfService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _serviceHost = new ServiceHost(typeof(MultipleService), new Uri("net.tcp://localhost:9001/MyService"));
            _serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (_serviceHost != null)
            {
                _serviceHost.Close();
            }

            _serviceHost = null;
        }
    }
}
