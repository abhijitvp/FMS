using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveFiles
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string f1 = textBox1.Text;
            string f2 = textBox2.Text;
            if(string.IsNullOrEmpty(f1)) f1 = @"C:\Abhijit\WK\7.i-Firm\Tickets\ARCHITECT-2010 - Php Upgrade\ini Files\php8Default.ini";
            if(string.IsNullOrEmpty(f2)) f2 = @"C:\Abhijit\WK\7.i-Firm\Tickets\ARCHITECT-2010 - Php Upgrade\ini Files\php8QA.ini";

            string fileName1 = Path.GetFileName(f1);
            string fileName2 = Path.GetFileName(f2);

            Print(String.Format("File 1: {0}", fileName1));
            Print(String.Format("File 2: {0}", fileName2));

            List<Config> config1 = GetConfigs(f1);
            List<Config> config2 = GetConfigs(f2);

            

            var common1 = (from i in config1 
                           join j in config2  on i.Key equals j.Key
                           where i.Val1 == j.Val1
                        select i).ToList();

            var common2 = (from i in config1
                          join j in config2 on i.Key equals j.Key
                          where i.Val1 != j.Val1 && i.Key != "extension"
                           select new Config { Key = i.Key, Val1=i.Val1, Val2=j.Val1 }).ToList();

            var onlyInFirst = (from i in config1
                          where !config2.Exists(j => j.Key == i.Key)
                          select i).ToList();

            var onlyInSecond = (from i in config2
                               where !config1.Exists(j => j.Key == i.Key) && i.Key != "extension"
                                select i).ToList();

            var ext1 = (from i in config1
                        where i.Key == "extension"
                        select i.Val1).ToList();

            var ext2 = (from i in config2
                        where i.Key == "extension"
                        select i.Val1).ToList();

            var onlyInFirstExt = ext1.Except(ext2).ToList();
            var onlyInSecondExt = ext2.Except(ext1).ToList();

            Print("");

            //Print("Common settings with same values");
            //PrintConfigs(common1);
            
            Print("Common settings with different values");
            PrintConfigs(common2, true);
            
            Print(string.Format("In {0} Only", fileName1));
            PrintConfigs(onlyInFirst);

            Print(string.Format("In {0} Only", fileName2));
            PrintConfigs(onlyInSecond);


            Print(string.Format("Extensions only in {0}", fileName1));
            PrintExtensions(onlyInFirstExt);

            Print(string.Format("Extensions only in {0}", fileName2));
            PrintExtensions(onlyInSecondExt);



        }

        private void PrintConfigs(List<Config> configs, bool showVal2 =false)
        {

            string line = string.Format("Total Count: {0}", configs.Count);
            Print(line);
            foreach (var config in configs)
            {
                line = string.Format("{0} = {1}", config.Key, config.Val1);
                if (showVal2)
                {
                    line = string.Format("{0} = {1}", line, config.Val2);
                }
                Print(line);
            }
            Print(String.Empty);
        }

        private void PrintExtensions(List<string> exts)
        {

            string line = string.Format("Total Count: {0}", exts.Count);
            Print(line);
            foreach (var ext in exts)
            {
                line = string.Format("{0}", ext);
                Print(line);
            }
            Print(String.Empty);
        }

        private void Print(string line)
        {
            txtMessage.AppendText(line + Environment.NewLine);
            Console.WriteLine(line);
        }

        private List<Config> GetConfigs(string f1)
        {
            List<Config> keys = new List<Config>();
            try
            {
                // Read a text file line by line.  
                string[] lines = File.ReadAllLines(f1);
                
                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line.Trim()) && !line.Trim().StartsWith(";"))
                    {
                        if (line.Contains("="))
                        {
                            var key = line.Split('=')[0].Trim();
                            var val = line.Split('=')[1].Trim();

                            keys.Add(new Config { Key = key, Val1 = val });
                        }

                        //txtMessage.AppendText(line + Environment.NewLine);
                        //Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return keys;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMessage.Clear();
        }
    }


    public class Config
    {
        public string Key;
        public string Val1;
        public string Val2;
    }
}
