using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
            linkLabel2.Links.Add(0, linkLabel2.Text.Length, "http://www.caferufukaydinlioglu.com.tr/");

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var target = e.Link.LinkData as string;

            if (target != null)
            {
                System.Diagnostics.Process.Start(target);
            }
        }
    }
}
