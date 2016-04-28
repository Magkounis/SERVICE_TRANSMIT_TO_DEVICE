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
       public Timer tmr;
       public PARAMETERS prms;
        
        public Service1()
        {
            InitializeComponent();
            init();
            
                
        }

        void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
           


        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
            stop();
           
        }


        protected void stop()//stop and destroy everything
        {
            prms.Stop = true;//stop everything
            tmr.Stop();//stop the timer
            tmr.Dispose();
            prms = null;


        }

        protected void init()//initialise 
        {
            try
            {
                tmr = new Timer();
                prms = new PARAMETERS();
                tmr.Interval = 2;//interval that the tick will be raised
                tmr.Start();
                tmr.Elapsed += new ElapsedEventHandler(tmr_Elapsed);//tick event
            }
            catch (Exception e)
            {
                writetofile(e.ToString());
                
            }

        }

        protected void writetofile(string s)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Log.txt", true))
            {
                file.WriteLine(s + "|" + DateTime.Now.ToString());

            };


        }

    }
}
