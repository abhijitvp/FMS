using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveFiles
{
    
    public partial class CSP : Form
    {
        List<CSPValues> cspvalues = new List<CSPValues>();
        public CSP()
        {
            InitializeComponent();
        }

        private void CSP_Load(object sender, EventArgs e)
        {
           
        }

        private void btnShowCSP_Click(object sender, EventArgs e)
        {
            
            string input = txtInput.Text.Trim();
            //input = @"connect-src 'self' *.cchifirmdev.com *.google.com *.akamaihd.net www.google-analytics.com ssl.google-analytics.com jsmeter.google-analytics.com saltmstore.google-analytics.com saltoffer.google-analytics.com ajax.googleapis.com api.raygun.io cdnjs.cloudflare.com m.addthis.com caifirmprdstorage.blob.core.windows.net *.segment.com *.segment.io *.mixpanel.com *.cchifirm.us *.acclipse.com *.cchifirm.ca wss://*.cchifirm.us wss://*.acclipse.com wss://*.cchifirm.ca *.can-ifirm-dev.com *.can-ifirm-qc.com *.can-ifirm-stg.com *.randomuser.me *.sentry.io *.mxpnl.net *.wistia.com *.twitter.com *.litix.io api.ipify.org wss://*.appcues.net stats.g.doubleclick.net fast.appcues.com api.appcues.net notify.bugsnag.com browser.pipe.aria.microsoft.com; font-src 'self' data: *.wolterskluwer.io fonts.gstatic.com sxt.cdn.skype.com cdnjs.cloudflare.com themes.googleusercontent.com fast.fonts.net webfonts.zohostatic.com *.fontawesome.com maxcdn.bootstrapcdn.com cdn.joinhoney.com appsforoffice.microsoft.com; media-src 'self' blob: data: ssl.gstatic.com embed-ssl.wistia.com *.akamaihd.net; object-src 'self' data: www.gstatic.com silverlight.dlservice.microsoft.com go2.microsoft.com; worker-src 'self' blob:; upgrade-insecure-requests; frame-ancestors 'self' https://outlook.office.com https://outlook.office365.com https://www.office.com https://*.officeapps.live.com https://*.online.office.com https://office.live.com https://wolterskluwer-my.sharepoint.com/; script-src-elem 'self' 'unsafe-inline' 'unsafe-eval' pi.pardot.com *.gstatic.com *.google-analytics.com fast.wistia.net cdn.raygun.io googletagmanager.com appsforoffice.microsoft.com ajax.aspnetcdn.com maps.google.com; report-uri https://eastus-swscsp.azurewebsites.net/reporting/iFirmCSPALPHA/enforce";

            List<string> sections = input.Split(';').ToList();

            foreach (string str in sections)
            {
                string str2 = str.Trim();
                string name = string.Empty;
                List<string> vals = new List<string>();
                if (str2.Contains(" "))
                {
                    name = str2.Substring(0, str2.IndexOf(" ")).Trim();
                    vals = str2.Trim().Substring(str2.IndexOf(" ")).Trim().Split(' ').ToList();
                }
                cspvalues.Add(new CSPValues
                {
                    section = name,
                    values = vals
                });

            }

            //write
            StringBuilder sb = new StringBuilder();
            foreach(CSPValues cspvalue in cspvalues)
            {
                sb.Append("" + cspvalue.section + Environment.NewLine);
                foreach(string val in cspvalue.values)
                {
                    sb.Append("\t" + val + Environment.NewLine);
                }
                //sb.Append("\b");
            }
            txtOut.Text = sb.ToString();
        }

        private void btnCSPText_Click(object sender, EventArgs e)
        {
            if(cspvalues !=null && cspvalues.Count()>0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (CSPValues cspvalue in cspvalues)
                {
                    sb.Append(cspvalue.section);
                    foreach (string val in cspvalue.values)
                    {
                        sb.Append(" " + val.Trim());
                    }
                    sb.Append("; ");
                }
                txtCSPText.Text = sb.ToString();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtCSPText.Clear();
            txtInput.Clear();
            txtOut.Clear();
            cspvalues = new List<CSPValues>();
        }
    }
}
