using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace AracKiralama
{
    public partial class FrmKayitOl : Form
    {
        private System.Drawing.Image close;
        private System.Drawing.Image hide;

        static Baglanti baglanti = new Baglanti();
        public string connectionString = $"Data Source={baglanti.Adres};Version=3;";
        public FrmKayitOl()
        {
            InitializeComponent();
            linkLabel2.Links.Add(0, linkLabel2.Text.Length, "http://www.caferufukaydinlioglu.com.tr/");
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath1 = System.IO.Path.Combine(basePath, "icons", "show.png");
            string imagePath2 = System.IO.Path.Combine(basePath, "icons", "hide.png");
            close = System.Drawing.Image.FromFile(imagePath1);
            hide = System.Drawing.Image.FromFile(imagePath2);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGirisSayfasi_Click(object sender, EventArgs e)
        {
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Show();
            this.Hide();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            string username = txtkullaniciAdi.Text;
            string password = txtSifre.Text;
            string confirmPassword = txtSifreTekrar.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Şifreler eşleşmiyor.");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string query = "INSERT INTO users (Username, Password) VALUES (@username, @password)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla eklendi.");
                            FrmGiris frmGiris = new FrmGiris();
                            frmGiris.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kayıt eklenirken bir hata oluştu.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
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

        private void btnShow2_MouseDown(object sender, MouseEventArgs e)
        {
            btnShow2.BackgroundImage = close;
            txtSifreTekrar.PasswordChar = '\0';
        }

        private void btnShow2_MouseUp(object sender, MouseEventArgs e)
        {
            btnShow2.BackgroundImage = hide;
            txtSifreTekrar.PasswordChar = '*';
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
