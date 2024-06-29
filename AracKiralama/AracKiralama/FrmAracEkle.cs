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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;


namespace AracKiralama
{
    public partial class FrmAracEkle : Form
    {
        int mov;
        int movX;
        int movY;

        public FrmAracEkle frmAracEkle;
        public FrmArac _frmArac;
        static Baglanti baglanti = new Baglanti();
        public string connectionString = $"Data Source={baglanti.Adres};Version=3;";
        public FrmAracEkle(FrmArac frmArac)
        {
            InitializeComponent();
            _frmArac = frmArac;
        }

        private void FrmAracEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmArac.AraclariListele();
        }

        private void FrmAracEkle_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;
            int x = (screenRectangle.Width - this.Width) / 2;
            int y = (screenRectangle.Height - this.Height) / 2;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
        }

        private void btnGorsel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;)|*.jpg;*.jpeg;*.png;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;
                pictureBox1.ImageLocation = dosyaYolu;
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string plaka = textBox1.Text;
            string marka = textBox2.Text;
            string model = textBox3.Text;
            string yil = textBox4.Text;
            string yakit = comboBox1.Text;
            string vites = comboBox2.Text;
            string kilometre = textBox5.Text;
            string motorGucu = textBox6.Text;
            string kasaTipi = comboBox3.Text;
            string renk = textBox7.Text;
            string hasar = comboBox4.Text;
            string gorselYolu = pictureBox1.ImageLocation;

            if (string.IsNullOrEmpty(plaka) || string.IsNullOrEmpty(marka) || string.IsNullOrEmpty(model) || string.IsNullOrEmpty(yil) ||
                string.IsNullOrEmpty(yakit) || string.IsNullOrEmpty(vites) || string.IsNullOrEmpty(kilometre) || string.IsNullOrEmpty(motorGucu) ||
                string.IsNullOrEmpty(kasaTipi) || string.IsNullOrEmpty(renk) || string.IsNullOrEmpty(hasar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM araclar WHERE plaka = @Plaka";
                using (SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Plaka", plaka);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Bu plaka numarası zaten mevcut.");
                        return;
                    }
                }

                string query = "INSERT INTO araclar (plaka, marka, model, yil, yakit, vites, kilometre, motor_gucu, kasa_tipi, renk, hasar, gorsel) " +
                               "VALUES (@Plaka, @Marka, @Model, @Yil, @Yakit, @Vites, @Kilometre, @MotorGucu, @KasaTipi, @Renk, @Hasar, @Gorsel)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Plaka", plaka);
                    command.Parameters.AddWithValue("@Marka", marka);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@Yil", yil);
                    command.Parameters.AddWithValue("@Yakit", yakit);
                    command.Parameters.AddWithValue("@Vites", vites);
                    command.Parameters.AddWithValue("@Kilometre", kilometre);
                    command.Parameters.AddWithValue("@MotorGucu", motorGucu);
                    command.Parameters.AddWithValue("@KasaTipi", kasaTipi);
                    command.Parameters.AddWithValue("@Renk", renk);
                    command.Parameters.AddWithValue("@Hasar", hasar);
                    command.Parameters.AddWithValue("@Gorsel", gorselYolu);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Araç başarıyla eklendi.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Araç eklenirken bir hata oluştu.");
                    }
                }
                connection.Close();
            }
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
