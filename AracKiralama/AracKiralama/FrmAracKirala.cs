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
    public partial class FrmAracKirala : Form
    {
        int mov;
        int movX;
        int movY;

        public FrmKira _frmKira;
        static Baglanti baglanti = new Baglanti();
        public string connectionString = $"Data Source={baglanti.Adres};Version=3;";
        public FrmAracKirala(FrmKira frmKira)
        {
            InitializeComponent();
            _frmKira = frmKira;
        }

        private void FrmAracKirala_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;
            int x = (screenRectangle.Width - this.Width) / 2;
            int y = (screenRectangle.Height - this.Height) / 2;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);

            BilgileriGetir();
            MusaitKisileriGetir();
        }


        public void MusaitKisileriGetir()
        {
            string query = "SELECT * FROM kisiler WHERE kisi_kiralik = 0";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BilgileriGetir()
        {
            textBox1.Enabled = false;
            string plaka = _frmKira.dataGridViewMusait.SelectedRows[0].Cells["plakaDataGridViewTextBoxColumn"].Value.ToString();

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
                    textBox8.Text = reader["yakit"].ToString();
                    textBox9.Text = reader["vites"].ToString();
                    textBox5.Text = reader["kilometre"].ToString();
                    textBox6.Text = reader["motor_gucu"].ToString();
                    textBox10.Text = reader["kasa_tipi"].ToString();
                    textBox7.Text = reader["renk"].ToString();
                    textBox11.Text = reader["hasar"].ToString();
                    string gorselYolu = reader["gorsel"].ToString();

                    if (!string.IsNullOrEmpty(gorselYolu))
                    {
                        pictureBox1.ImageLocation = gorselYolu;
                        reader.Close();
                    }

                    reader.Close();
                }
            }
        }

        private void btnAracKirala_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Aracı kiralamaya emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            string plaka = textBox1.Text;
            string tcKimlik = dataGridView1.SelectedRows[0].Cells["columnTC"].Value.ToString();
            DateTime baslangicTarihi = dateTimePicker1.Value;
            DateTime bitisTarihi = dateTimePicker2.Value;

            string query = "UPDATE araclar SET baslangic = @baslangic, bitis = @bitis, tc_no = @tcNo, kiralik = 1 WHERE plaka = @plaka";
            string query2 = "UPDATE kisiler SET kisi_plaka = @kisi_plaka, kisi_kiralik = 1 WHERE tc_kimlik_numarasi = @tc_kimlik_numarasi";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@kisi_plaka", plaka);
                        command.Parameters.AddWithValue("@tc_kimlik_numarasi", tcKimlik);
                        int rowsAffected = command.ExecuteNonQuery();
                    }

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@plaka", plaka);
                        command.Parameters.AddWithValue("@baslangic", baslangicTarihi);
                        command.Parameters.AddWithValue("@bitis", bitisTarihi);
                        command.Parameters.AddWithValue("@tcNo", tcKimlik);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Araç başarıyla kiralandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Araç kiralama işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FrmAracKirala_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmKira.MusaitAraclariGetir();
            _frmKira.KiralananAraclariGetir();
        }

        private void txtMusteriAra_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtMusteriAra.Text.ToLower();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool foundInRow = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchValue) && !string.IsNullOrEmpty(searchValue))
                    {
                        cell.Style.BackColor = Color.FromArgb(153, 223, 71);
                        foundInRow = true;
                    }
                    else
                    {
                        cell.Style.BackColor = Color.FromArgb(71, 75, 79);
                    }
                }
                row.Selected = foundInRow;
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

        private void btnYeni_Click(object sender, EventArgs e)
        {
            FrmYeniMusteri frmYeniMusteri = new FrmYeniMusteri(this);
            frmYeniMusteri.ShowDialog();
        }
    }    
}
