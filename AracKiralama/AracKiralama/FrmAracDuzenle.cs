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

namespace AracKiralama
{

    public partial class FrmAracDuzenle : Form
    {
        int mov;
        int movX;
        int movY;

        public FrmArac _frmArac;
        static Baglanti baglanti = new Baglanti();
        public string connectionString = $"Data Source={baglanti.Adres};Version=3;";
        public FrmAracDuzenle(FrmArac frmArac)
        {
            InitializeComponent();
            _frmArac = frmArac;
        }

        private void FrmAracDuzenle_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;
            int x = (screenRectangle.Width - this.Width) / 2;
            int y = (screenRectangle.Height - this.Height) / 2;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);



            textBox1.Enabled = false;
            string plaka = _frmArac.dataGridViewTumAraclar.SelectedRows[0].Cells["dataGridViewTextBoxColumn1"].Value.ToString();

            if (string.IsNullOrEmpty(plaka))
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz aracın plakasını girin.");
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM araclar WHERE plaka = @Plaka";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Plaka", plaka);
                    SQLiteDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        MessageBox.Show("Belirtilen plakaya sahip araç bulunamadı.");
                        return;
                    }

                    textBox1.Text = reader["plaka"].ToString();
                    textBox2.Text = reader["marka"].ToString();
                    textBox3.Text = reader["model"].ToString();
                    textBox4.Text = reader["yil"].ToString();
                    comboBox1.Text = reader["yakit"].ToString();
                    comboBox2.Text = reader["vites"].ToString();
                    textBox5.Text = reader["kilometre"].ToString();
                    textBox6.Text = reader["motor_gucu"].ToString();
                    comboBox3.Text = reader["kasa_tipi"].ToString();
                    textBox7.Text = reader["renk"].ToString();
                    comboBox4.Text = reader["hasar"].ToString();
                    string gorselYolu = reader["gorsel"].ToString();
                    if (!string.IsNullOrEmpty(gorselYolu))
                    {
                        pictureBox1.ImageLocation = gorselYolu;
                        reader.Close();
                    }
                    reader.Close();

                }
                connection.Close();
            }
        }

        private void FrmAracDuzenle_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmArac.AraclariListele();
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

        private void btnKaydet_click(object sender, EventArgs e)
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
                string query = "UPDATE araclar SET marka = @Marka, model = @Model, yil = @Yil, yakit = @Yakit, vites = @Vites, " +
                               "kilometre = @Kilometre, motor_gucu = @MotorGucu, kasa_tipi = @KasaTipi, renk = @Renk, hasar = @Hasar, gorsel = @Gorsel";

                query += " WHERE plaka = @Plaka";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
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
                    command.Parameters.AddWithValue("@Plaka", plaka);
                    command.Parameters.AddWithValue("@Gorsel", gorselYolu);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Araç bilgileri başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Araç bilgileri güncellenirken bir hata oluştu.");
                    }
                }
                connection.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov ==1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y -  movY);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }
    }
}
