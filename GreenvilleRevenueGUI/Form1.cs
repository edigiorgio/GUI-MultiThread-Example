using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GreenvilleRevenueGUI
{
    //**********************************************
    // Written by: Eric DiGiorgio
    // For: COP 2362 C# Programming II
    // Where: FSW Computer Science Program www.fsw.edu
    // Professor: Dr. Roger Webster
    // When:  Spring 2020
    // ***********************************************
    public partial class Form1 : Form
    {
        int WindowHeight = 380;
        int WindowWidth = 880;
        int totalbreakfastitemsdone = 0;
        delegate void MyCallBack(String BreakfastItem);// call back
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(WindowWidth, WindowHeight);
        }

        async Task MyMain()
        {
            String msg = "";
            var CoffeeTask = PourCoffee(30);
            var eggsTask = FryEggsAsync(180);
            var baconTask = FryBaconAsync(300);
            var toastTask = MakeToastWithButterAndJamAsync(200);
            var pourOJ = PourOJ(30);
            var hashBrowns = HashBrowns(180);

            var allTasks = new List<Task> { CoffeeTask, pourOJ, hashBrowns, eggsTask, baconTask, toastTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished.IsCompleted)
                {
                    if (finished == CoffeeTask)
                    {
                        msg = "Coffee is done";
                        //MessageBox.Show(msg);
                    }
                    if (finished == eggsTask)
                    {
                        msg = "eggs are ready";
                        //MessageBox.Show(msg);
                        Console.WriteLine(msg);
                    }
                    else if (finished == baconTask)
                    {
                        msg = "Bacon is ready";
                        // MessageBox.Show(msg);
                        Console.WriteLine("bacon is ready");
                    }

                    else if (finished == toastTask)
                    {
                        Console.WriteLine("toast is ready");
                    }
                    allTasks.Remove(finished);
                }
            }


        }
        async Task<BreakfastItem> MakeToastWithButterAndJamAsync(int timeinmlsecs)
        {
            //this makes this item wait a little since you want all the food ready at the end
            await Task.Delay(7000);//milliseconds wait to start
            BreakfastItem myitme = new BreakfastItem("Toast", timeinmlsecs, progressBar4, TaskCallBack);
            return myitme;
        }

        async Task<BreakfastItem> FryEggsAsync(int timeinmlsecs)
        {
            //this makes this item wait a little since you want all the food ready at the end
            await Task.Delay(8000);//milliseconds wait to start
            BreakfastItem myitme = new BreakfastItem("Fried Eggs", timeinmlsecs, progressBar2, TaskCallBack);
            return myitme;
        }

        async Task<BreakfastItem> FryBaconAsync(int timeinmlsecs)
        {
            BreakfastItem myitme = new BreakfastItem("Bacon", timeinmlsecs, progressBar1, TaskCallBack);
            return myitme;
        }

        async Task<BreakfastItem> PourCoffee(int timeinmlsecs)
        {
            BreakfastItem myitem = new BreakfastItem("Pour Cofffee", timeinmlsecs, progressBar3, TaskCallBack);
            return myitem;
        }

        async Task<BreakfastItem> PourOJ(int timeinm1secs)
        {
            await Task.Delay(2600);
            BreakfastItem myitem = new BreakfastItem("Pour OJ", timeinm1secs, progressBar5, TaskCallBack);
            return myitem;
        }

        async Task<BreakfastItem> HashBrowns(int timeinm1secs)
        {
            await Task.Delay(8000);//milliseconds wait to start
            BreakfastItem myitem = new BreakfastItem("Hash Browns", timeinm1secs, progressBar6, TaskCallBack);
            return myitem;
        }
        public void TaskCallBack(String BreakfastItemName)
        {
            //MessageBox.Show(BreakfastItemName + " Task is DONE...");
            String msg = BreakfastItemName + " Task is DONE...";
            label6.Text = msg;
            totalbreakfastitemsdone++;
            if (totalbreakfastitemsdone == 6)
            {
                msg = "Breakfast is ready!!";
                label6.Text = msg;
                MessageBox.Show(msg, "Eric's Breakfast Tasks");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            label6.Text = "Making Breakfast with Multi-Tasking!!";
            Task finished = MyMain();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

            this.progressBar1.PerformStep();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar3_Click(object sender, EventArgs e)
        {

        }

        private void progressBar4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}

