using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace AracKiralama
{
    public partial class FrmGiris : Form
    {
        private System.Drawing.Image close;
        private System.Drawing.Image hide;

        static Baglanti baglanti = new Baglanti();
        public string connectionString = $"Data Source={baglanti.Adres};Version=3;";
        public FrmGiris()
        {
            InitializeComponent();
            Init_Data();
            linkLabel2.Links.Add(0, linkLabel2.Text.Length, "http://www.caferufukaydinlioglu.com.tr/");

            string basePath = AppDomain.CurrentDomain.BaseDirectory; 
            string imagePath1 = System.IO.Path.Combine(basePath, "icons", "show.png");
            string imagePath2 = System.IO.Path.Combine(basePath, "icons", "hide.png");
            close = System.Drawing.Image.FromFile(imagePath1);
            hide = System.Drawing.Image.FromFile(imagePath2);
        }

        private void Init_Data()
        {
            if (Properties.Settings.Default.Username != string.Empty)
            {
                if (Properties.Settings.Default.Remember == true)
                {
                    txtkullaniciAdi.Text = Properties.Settings.Default.Username;
                    chckBeniHatirla.Checked = true;
                }
                else
                {
                    txtkullaniciAdi.Text = Properties.Settings.Default.Username;
                }
            }
        }

        private void Save_Data()
        {
            if (chckBeniHatirla.Checked)
            {
                Properties.Settings.Default.Username = txtkullaniciAdi.Text.Trim(); 
                Properties.Settings.Default.Remember = true; 
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = ""; 
                Properties.Settings.Default.Remember = false; 
                Properties.Settings.Default.Save();
            }
        }
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string username = txtkullaniciAdi.Text;
            string password = txtSifre.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifrenizi giriniz.");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM users WHERE Username=@Username AND Password=@Password";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        FrmMainPage AnaSayfa = new FrmMainPage();
                        AnaSayfa.Show();
                        this.Hide();
                        Save_Data();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                    }
                }
                connection.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnKullaniciOlustur_Click(object sender, EventArgs e)
        {
            FrmKayitOl frmKayitOl = new FrmKayitOl();
            frmKayitOl.Show();
            this.Hide();
        }

        private void btnShow_MouseDown(object sender, MouseEventArgs e)
        {
            btnShow.BackgroundImage = close;
            txtSifre.PasswordChar = '\0';
        }

        private void btnShow_MouseUp(object sender, MouseEventArgs e)
        {
            btnShow.BackgroundImage = hide;
            txtSifre.PasswordChar = '*';
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
