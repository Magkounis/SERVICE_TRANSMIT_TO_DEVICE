using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace SERVICE_TRANSMIT_TO_DEVICE
{
    public partial class Service1 : ServiceBase
    {
        
        public Service1()
        {
            InitializeComponent();
            Timer tmr = new Timer();
            tmr.Interval = 2;
            tmr.Start();
            tmr.Elapsed += new ElapsedEventHandler(tmr_Elapsed);
                
        }

        void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
           


        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
