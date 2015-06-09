using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;


namespace Course_proj
{
    public partial class Form1 : Form
    {

        int totalHits = 0;

        public int getCPUCounter()
        {

            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            // всегда начинается с 0
            dynamic firstValue = cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            // now matches task manager reading
            dynamic secondValue = cpuCounter.NextValue();

            return secondValue;

        }


        private void Timer1_Tick(Object sender, EventArgs e)
        {
            int cpuPercent = getCPUCounter();
            if (cpuPercent >= 90)
            {
                totalHits = totalHits + 1;
             /*   if (totalHits == 60)
                {
                    Interaction.MsgBox("ALERT 90% usage for 1 minute");
                    totalHits = 0;
                }*/
            }
            else
            {
                totalHits = 0;
            }
            label1.Text = cpuPercent + " % CPU";
            label2.Text = totalHits + " seconds over 20% usage";        }

        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {            
                  
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           // label1.Text = Temperature.TemperatureCheck.CurrentValue; 
        }
    }
}
