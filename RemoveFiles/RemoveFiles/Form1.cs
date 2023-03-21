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
using System.Text.RegularExpressions;

namespace RemoveFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"D:\Abhijit\WK\Reviews\2018\10.Capego\1.1 CX Code\Services 1.10 Source Code";
            textBox1.Text = path;

            string exts = "dll;exe;pdb;gif;jpeg;jpg;png;bmp;zip;pdf;xls;xlsx;doc;docx;rtf;csv;gz;msi,cache;swf;tmp;ico;mp3;mp4;bak;png;mdb;";
            textBox2.Text = exts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            List<string> extensions = new List<String>();

            extensions.AddRange(textBox2.Text.Split(';').ToArray<string>());
            extensions.Remove("");
            RemoveFiles(path, extensions);
            txtMessage.AppendText("Done!");
        }

        private void RemoveFiles(string path, List<string> extensions)
        {
            if (!string.IsNullOrEmpty(path) && System.IO.Directory.Exists(path))
            {
                foreach (string extension in extensions)
                {
                    int cnt = 0;
                    string[] files = System.IO.Directory.GetFiles(path, string.Format("*.{0}", extension.Trim()), System.IO.SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        try
                        {
                            if (File.Exists(file))
                            {
                                System.IO.File.Delete(file);
                                cnt++;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    txtMessage.AppendText("removed: " + extension + "Files: " + cnt + Environment.NewLine);
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            List<string> paths = new List<String>();
            paths.Add(@"C:\Temp");
            paths.Add(@"C:\Program Files (x86)\WK");
            paths.Add(@"C:\ProgramData\WK");
            paths.Add(@"C:\ProgramData\IsolatedStorage");
            paths.Add(@"C:\ProgramData\WK_Install");
            paths.Add(@"C:\Users\apatil\AppData\Roaming\WK");
            paths.Add(@"C:\Users\apatil\AppData\Local\Wk");
            foreach (string path in paths)
            {
                try
                {
                    System.IO.Directory.Delete(path, true);
                }
                catch (Exception ex)
                {
                    txtMessage.AppendText(ex.Message + Environment.NewLine);
                }
            }
        }

        private void btnCleanOSA_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            List<string> extensions = new List<String>();
            string exts = "pdb;gif;jpeg;jpg;png;bmp;zip;xls;xlsx;doc;docx;rtf;csv;gz;msi,cache;swf;tmp;ico;mp3;mp4;bak;png;mp4;xml;pas;vif;" +
                "dfm;dcu;bpl;pak;emf;dat;chm;cab;sni;txt;mdb;for;dcp;dlf;cache;spf;map;dbg;nfm;bks;cs;vb;";

            extensions.AddRange(exts.Split(';').ToArray<string>());
            extensions.Remove("");
            RemoveFiles(path, extensions);


            string[] files = System.IO.Directory.GetFiles(path, "Microsoft.*", System.IO.SearchOption.AllDirectories);
            foreach (string file in files)
            {
                try
                {
                    System.IO.File.Delete(file);
                }
                catch (Exception ex)
                {

                }
            }
            txtMessage.AppendText("Done!");
        }

        private void btn_RemoveDuplicate_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            string[] files = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);
            txtMessage.AppendText("Total Files: " + files.Length + Environment.NewLine);
            try
            {
                foreach (string file in files)
                {
                    if (File.Exists(file))
                    {
                        FileInfo info = new FileInfo(file);

                        var dupFiles = (from i in files
                                        where i.Contains(info.Name) && i != info.FullName
                                        select i).ToList();

                        if (dupFiles != null && dupFiles.Count > 0)
                        {
                            foreach (string dup in dupFiles)
                            {
                                if (File.Exists(dup))
                                {
                                    FileInfo dupFileInfo = new FileInfo(dup);

                                    if (info.Length == dupFileInfo.Length)
                                    {
                                        System.IO.File.Delete(dup);
                                        txtMessage.AppendText("removed: " + dup + Environment.NewLine);
                                    }
                                }
                            }

                        }
                    }

                }
                txtMessage.AppendText("Removed Duplicates" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                txtMessage.AppendText(ex.Message + Environment.NewLine);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"D:\Temp\MyFile.txt");
            List<string> tags = new List<string>();

            foreach (string s in lines)
            {
                string input = s;

                string regularExpressionPattern1 = @"\<(.*?)\>";
                Regex regex = new Regex(regularExpressionPattern1, RegexOptions.Singleline);
                MatchCollection collection = regex.Matches(input);

                for (int i = 0; i < collection.Count; i++)
                {
                    Match m = collection[i];
                    var stripped = m.Groups[1].Value.Replace("/", "");

                    tags.Add(stripped);
                }
            }

            tags = tags.Distinct().ToList().OrderBy(q => q).ToList();



            string path = @"D:\Temp\MyTest.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string[] createText = tags.ToArray();
                File.WriteAllLines(path, createText, Encoding.UTF8);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            string appendText = "This is extra text" + Environment.NewLine;
            File.AppendAllText(path, appendText, Encoding.UTF8);


        }

        private void button3_Click(object sender, EventArgs e)
        {
                string[] lines2 = File.ReadAllLines(@"D:\Temp\MyTest.txt");
                List<string> tags2 = new List<string>();

                foreach (string s in lines2)
                {
                    tags2.Add(string.Format("\"{0}\":{{\"Attributes\":[]}},", s));

                }



                string path2 = @"D:\Temp\MyTest2.txt";

                // This text is added only once to the file.
                if (!File.Exists(path2))
                {
                    // Create a file to write to.
                    string[] createText = tags2.ToArray();
                    File.WriteAllLines(path2, createText, Encoding.UTF8);
                }

            }
        
    }
}
