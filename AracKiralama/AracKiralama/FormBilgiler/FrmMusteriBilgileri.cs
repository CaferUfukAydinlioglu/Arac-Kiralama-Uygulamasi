using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AracKiralama
{
    public partial class FrmMusteriBilgileri : Form
    {
        int mov;
        int movX;
        int movY;

        public FrmMusteri _frmMusteri;
        static Baglanti baglanti = new Baglanti();
        public string connectionString = $"Data Source={baglanti.Adres};Version=3;";
        public FrmMusteriBilgileri(FrmMusteri frmMusteri)
        {
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;
            int x = (screenRectangle.Width - this.Width) / 2;
            int y = (screenRectangle.Height - this.Height) / 2;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);

            InitializeComponent();
            _frmMusteri = frmMusteri;

        }

        private void FrmMusteriBilgileri_Load(object sender, EventArgs e)
        {
            string tcNo = _frmMusteri.dataGridViewMusteriListesi.SelectedRows[0].Cells["dataGridViewTextBoxColumn12"].Value.ToString();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM kisiler WHERE tc_kimlik_numarasi = @tc_kimlik_numarasi";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tc_kimlik_numarasi", tcNo);
                    SQLiteDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        MessageBox.Show("Kişi bulunamadı!");
                        return;
                    }

                    textBox1.Text = reader["tc_kimlik_numarasi"].ToString();
                    textBox2.Text = reader["isim"].ToString();
                    textBox3.Text = reader["soyisim"].ToString();
                    textBox4.Text = reader["meslek"].ToString();
                    textBox5.Text = reader["cep_telefonu"].ToString();
                    textBox6.Text = reader["email"].ToString();
                    textBox7.Text = reader["ehliyet_no"].ToString();
                    richTextBox1.Text = reader["adres"].ToString();
                    textBox8.Text = reader["ehliyet_turu"].ToString();
                    richTextBox2.Text = reader["notlar"].ToString();
                    txtKiralananArac.Text = reader["kisi_plaka"].ToString();

                    string gorselYolu = reader["kisi_gorsel"].ToString();
                    if (!string.IsNullOrEmpty(gorselYolu) && gorselYolu != "0" && File.Exists(gorselYolu))
                    {
                        pictureBox1.ImageLocation = gorselYolu;
                        pictureBox1.Visible = true;
                        pictureBoxHide.Visible = false;
                    }
                    else
                    {
                        pictureBox1.Visible = false;
                        pictureBoxHide.Visible = true;
                    }

                    reader.Close();
                }
                connection.Close();
            }
        }


        private void btnAracBilgileri_Click(object sender, EventArgs e)
        {
            if (txtKiralananArac.Text == "Yok")
            {
                MessageBox.Show("Kişinin kiraladığı bir araç bulunamadı .");
                return;
            }
            FrmMusteriArac frmMusteriArac = new FrmMusteriArac(this);
            frmMusteriArac.ShowDialog();
            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelMove_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panelMove_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
    }
}
