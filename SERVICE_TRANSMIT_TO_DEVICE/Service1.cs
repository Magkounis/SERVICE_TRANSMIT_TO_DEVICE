using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Data.SqlClient;

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
            //    /*
            prms.Server = "SRV\\SRVSQL";
            prms.Password="lili";
            prms.Database = "test";


            while (true) ;

             
             //   */
                
        }

        void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            SqlConnection myConnection = new SqlConnection("user id=sa;" +"password="+prms.Password+";server="+prms.Server+";" + "database="+prms.Database+"; " +"connection timeout=1");
            try
            {
                myConnection.Open();//try open the connection to the sql server



                myConnection.Close();
                myConnection.Dispose();

            }
            catch (Exception sqle)
            {
                writetologfile(sqle.ToString());
                stop();
            }

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



        }

        protected void init()//initialise 
        {
            try
            {
                tmr = new Timer();
                prms = new PARAMETERS();
                tmr.Interval = 2000;//interval that the tick will be raised
                tmr.Start();
                tmr.Elapsed += new ElapsedEventHandler(tmr_Elapsed);//tick event
            }
            catch (Exception e)
            {
                writetologfile(e.ToString());
                stop();
            }

        }

        protected void writetologfile(string s)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Log.txt", true))
            {
                file.WriteLine(s + "|" + DateTime.Now.ToString()+"\n");

            };


        }


        internal void TestStartupAndStop()
        {
            this.OnStart(null);
            Console.ReadLine();
            this.OnStop();

        }

    }
}
