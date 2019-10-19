using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoBarDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DodajKontrolki();
        }

        private void DodajKontrolki()
        {
            userControl11.SetNapis(2, "hehehe");
            userControl11.SetNapis(5, "Napis na 6 pasku");
            userControl11.SetNapis(6, "siedem");
            userControl11.SetNapis(9, "ostatni");
            userControl11.ShowValue(3,true);
            userControl11.ShowValue(4, true);
            userControl11.ShowValue(2, true);
            userControl11.SetWarnings(2, 10, 20);
            userControl11.SetLimits(2, -30, 30);
            userControl11.SetLimits(3, 20, 40);
            userControl11.SetKolor(0, Color.Blue);
            userControl11.ShowValue(6, false);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            bar1.Value = (int)((numericUpDown1.Value/numericUpDown1.Maximum)*100);
            for (int i = 0; i < 10; i++)
            {
                if(i!=2 && i!=3)
                    userControl11.SetValue(i, (int)numericUpDown1.Value); 
            }
             
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            bar1.Warning = (int)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            bar1.Alert = (int)numericUpDown3.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bar1.Invalidate();
            if (!checkBox1.Checked)
            {
                bar1.EnableWarning = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
            }
            else
            {
                bar1.EnableWarning = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            userControl11.SetValue(2, (int)numericUpDown4.Value);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            userControl11.SetValue(3, (int)numericUpDown5.Value);
        }
    }
}
