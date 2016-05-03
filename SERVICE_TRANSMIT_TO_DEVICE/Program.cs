using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace SERVICE_TRANSMIT_TO_DEVICE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)//check if there is a user interaction to run it as simple exe
            {

                Service1 service1 = new Service1();
                service1.TestStartupAndStop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }

            //ServiceBase[] ServicesToRun;
            // ServicesToRun = new ServiceBase[] 
            //{ 
            //	new Service1() 
            //};
            //   ServiceBase.Run(ServicesToRun);
        }
    }
}
