using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace Service1
{
    public partial class Service1 : ServiceBase
    {
        protected static int timi=2;//time in seconds
        protected Timer t;
        public Parameters prms;
        public bool work = true;
        public Service1()
        {
            InitializeComponent();
            initialization();
            
           // while (work) ;
            
       
            

        }

        void initialization()
        {
            prms = new Parameters();//initialize parameters class where all the parameters will be 
            Readfromxml rdfrxml = new Readfromxml("C:\\sht\\config.xml");//read data from xml
            
            prms.hour = rdfrxml.hour;//pass data from xml to parameters 
            prms.minute = rdfrxml.minutes;
            prms.mode = rdfrxml.mode;
            rdfrxml = null;
            t = new Timer();//at this point i will create a timer to trigger a tick event
            t.Interval = timi * 1000;//interval that will the event be handled
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);

            t.Start();//start the timer -tick


        }

       
      
      

        protected override void OnStart(string[] args)
        {
            initialization();
        }

        internal void TestStartupAndStop()
        {
            this.OnStart(null);
            Console.ReadLine();
            this.OnStop();
            
        }

        protected override void OnStop()
        {
            
            t.Dispose();
            
        }




        void t_Elapsed(object sender, ElapsedEventArgs e)//this event is triggered every &timi seconds
        {
            string str = DateTime.Now.TimeOfDay.ToString().Substring(0, 5);//take the time hour:minutes from system
            if (str == prms.hour + ":" + prms.minute)
            {

                System.Diagnostics.Process.Start("shutdown.exe", "-" + prms.mode + " -t 0");


            }
            str = null;
        }




    }
}
