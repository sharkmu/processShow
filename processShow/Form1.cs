using System.Collections.Generic;
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
            var processList = new List<string>();
            foreach (var i in Process.GetProcesses()) 
            {
                processNameV = i.ToString();
                last = processNameV.Substring(processNameV.LastIndexOf(' ') + 1);
                last = Regex.Replace(last, "[()]", "");
                processList.Add(last);  
            }
            RemoveDuplicates(processList);

            void RemoveDuplicates(List<string> list)
            {
                HashSet<string> uniqueElements = new HashSet<string>();
                List<string> duplicates = new List<string>();

                foreach (var item in list)
                {
                    if (uniqueElements.Contains(item))
                    {
                        duplicates.Add(item);
                    }
                    else
                    {
                        uniqueElements.Add(item);
                    }
                }

                foreach (var duplicate in duplicates)
                {
                    list.RemoveAll(item => item == duplicate);
                }

                list.Sort();

                foreach (var i in list)
                {
                    listBox1.Items.Add(i);
                }
            }
        }
    }
}