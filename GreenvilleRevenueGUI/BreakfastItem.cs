using System;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.ComponentModel;
using System.Threading;
namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Dr. Roger Webster
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // When:  Spring 2020
    // ***********************************************
    class BreakfastItem
    {
        int RandomwaitMax = 0;
        ProgressBar myprogressBar = null;
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();  
        Boolean keepgoing = true;
        String BreakfastItemName = "";
        public delegate void MyCallBack(String BreakfastItem);// call back delegate definition
        public event MyCallBack CallToMakeWhenDone = null;// call back delegate var

        public BreakfastItem(String BreakfastItemNameIn, int RandomwaitMax, ProgressBar progressBarin, MyCallBack callback)
        {
            this.RandomwaitMax = RandomwaitMax;
            BreakfastItemName = BreakfastItemNameIn;
            CallToMakeWhenDone = callback;
 
            myprogressBar = progressBarin;
            myprogressBar.MarqueeAnimationSpeed = 1000;
            myprogressBar.Maximum = RandomwaitMax;
            myprogressBar.Name = "progressBar Item";
            myprogressBar.Size = new System.Drawing.Size(RandomwaitMax, 23);
            myprogressBar.Step = 10;
            myprogressBar.TabIndex = 2;
           
            StateCookingTimer();
        }

        private void StateCookingTimer()
        {
            //Start timer1
            timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Start();
            myprogressBar.PerformStep();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (keepgoing)
            {
                myprogressBar.PerformStep();
                if (myprogressBar.Value.Equals(RandomwaitMax))
                {
                    keepgoing = false;
                    CallToMakeWhenDone(BreakfastItemName);//call back to form1
                    timer1.Stop();
                    timer1.Enabled = false;
                }
            }
        }

    }
}
