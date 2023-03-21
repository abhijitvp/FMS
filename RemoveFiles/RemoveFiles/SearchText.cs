using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RemoveFiles
{
    public partial class SearchText : Form
    {
        List<string> tags = new List<string>();
        public SearchText()
        {
            
            InitializeComponent();
        }

        private void SearchText_Load(object sender, EventArgs e)
        {
            string path = @"C:\Abhijit\Code\Other\Code\Code\abhijitvp\TestProjects\RemoveFiles\SearchTestFiles\";
            txtPath.Text = path;

            string exts = "php;cshtml;tpl;html;js;";
            txtExtensions.Text = exts;

            string regex = @"<\w+";
            txtRegularExpression.Text = regex;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            tags = new List<string>();
            string path = txtPath.Text;
            List<string> extensions = new List<String>();

            extensions.AddRange(txtExtensions.Text.Split(';').ToArray<string>());
            extensions.Remove("");

            if (!string.IsNullOrEmpty(path) && System.IO.Directory.Exists(path))
            {
                foreach (string extension in extensions)
                {
                    string[] files = System.IO.Directory.GetFiles(path, string.Format("*.{0}", extension.Trim()), System.IO.SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        try
                        {
                            if (File.Exists(file))
                            {
                                txtFiles.AppendText(file+Environment.NewLine);
                                SearchFile(file,txtRegularExpression.Text);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }

        private void SearchFile(string path, string regexstring)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                Regex regex = new Regex(regexstring);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Try to match each line against the Regex.
                    MatchCollection matches = regex.Matches(line);
                    if (matches!= null && matches.Count>0)
                    {
                        foreach (Match match in matches)
                        {
                            if (!tags.Contains(match.Value))
                            {
                                txtSearch.AppendText(match.Value+Environment.NewLine);
                                tags.Add(match.Value);
                            }
                        }
                    }
                }
            }
        }

    }
}
