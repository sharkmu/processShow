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
using System.Text.RegularExpressions;


namespace processShower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string processNameV;
            string last;
            foreach(var i in Process.GetProcesses()) 
            {
                processNameV = i.ToString();
                last = processNameV.Substring(processNameV.LastIndexOf(' ') + 1);
                last = Regex.Replace(last, "\\)", "");
                last = Regex.Replace(last, "\\(", "");
                listBox1.Items.Add(last);
                Console.WriteLine("test");
            }
        }
    }
}
