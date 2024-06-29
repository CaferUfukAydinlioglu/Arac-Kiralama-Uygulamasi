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
    public partial class FrmMainPage : Form
    {
        int mov;
        int movX;
        int movY;
        public FrmMainPage()
        {           
            InitializeComponent();
        }
        private void FrmMainPage_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;
            int x = (screenRectangle.Width - this.Width) / 2;
            int y = (screenRectangle.Height - this.Height) / 2;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
            FrmMusteri musteriForm = new FrmMusteri();
            FrmGetir(musteriForm);

        }

        private void FrmGetir(Form frm)
        {
            panelMain.Controls.Clear();
            frm.MdiParent = this;
            panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            labelSayfaBilgisi.Text = "Müşteri İşlemleri";
            FrmMusteri musteriForm = new FrmMusteri();
            FrmGetir(musteriForm);
        }

        private void btnArac_Click(object sender, EventArgs e)
        {
            labelSayfaBilgisi.Text = "Araç İşlemleri";
            FrmArac aracForm = new FrmArac();
            FrmGetir(aracForm);
        }

        private void btnKira_Click(object sender, EventArgs e)
        {
            labelSayfaBilgisi.Text = "Araç Kiralama İşlemleri";
            FrmKira kiraForm = new FrmKira();
            FrmGetir(kiraForm);
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            labelSayfaBilgisi.Text = "Ayarlar";

            FrmAyarlar ayarlarForm = new FrmAyarlar();
            FrmGetir(ayarlarForm);
        }
        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Username = string.Empty;
            Properties.Settings.Default.Save();

            DialogResult result = MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FrmGiris loginForm = new FrmGiris();
                loginForm.Show();
                this.Close();
            }
            else
            {
                return;
            }          
        }

        private void panelMove_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov ==1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y -  movY);
            }
        }

        private void panelMove_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

    }
}
