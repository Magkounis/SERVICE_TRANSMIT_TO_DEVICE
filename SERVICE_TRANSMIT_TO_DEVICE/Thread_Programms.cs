using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SERVICE_TRANSMIT_TO_DEVICE
{
    class Thread_Programms
    {
        protected Thread SecondaryThread;//initialize the secondary thread that will check the sql
        //public delegate void ...;
        private Thread_Programms()

        {
            SecondaryThread=new Thread(checksql);
            



        }


        protected void writetologfile(string s)//if there is an excep[tion write it to a log file
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Log.txt", true))
            {
                file.WriteLine(s + "|" + DateTime.Now.ToString() + "\n");

            };


        }

        protected void checksql()
        {

        }




    }
}
