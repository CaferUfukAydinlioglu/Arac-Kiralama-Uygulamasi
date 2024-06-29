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
using System.IO;

namespace AracKiralama
{
    public partial class FrmMusteri : Form
    {
        static Baglanti baglanti = new Baglanti();
        string connectionString = $"Data Source={baglanti.Adres};Version=3;";
        public FrmMusteri()
        {
            InitializeComponent();
        }

        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = textBox1.BackColor;
            EkleVeListele();

            MaskedTextBox textBox5 = new MaskedTextBox();
            textBox5.Mask = "(999) 999 9999";
            textBox5.PromptChar = ' ';
            textBox5.ResetOnPrompt = false;
            textBox5.Location = new System.Drawing.Point(20, 20);
            textBox5.Width = 200;
            textBox5.KeyPress += new KeyPressEventHandler(textBox5_KeyPress);
        }

        private void btnGorselSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;)|*.jpg;*.jpeg;*.png;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;
                pictureBox1.ImageLocation = dosyaYolu;
                pictureBoxHide.Visible = false;
                pictureBox1.Visible = true;
            }
        }
        
        private void EkleVeListele()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string query = "SELECT * FROM kisiler";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewMusteriListesi.DataSource = dataTable;
            }
        }

        public void lblGoster()
        {
            lbl1.Visible = true; lbl1.Text = "*";
            lbl2.Visible = true; lbl2.Text = "*";
            lbl3.Visible = true; lbl3.Text = "*";
            lbl4.Visible = true; lbl4.Text = "*";
            lbl5.Visible = true; lbl5.Text = "*";
            lbl6.Visible = true; lbl6.Text = "*";
            lbl7.Visible = true; lbl7.Text = "*";
            lbl8.Visible = true; lbl8.Text = "*";
        }
        public void lblGizle()
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
        }
        private void btnmusteriYeniKayit_Click(object sender, EventArgs e)
        {
            string tcKimlik = textBox1.Text;
            string isim = textBox2.Text;
            string soyisim = textBox3.Text;
            string meslek = textBox4.Text;
            string cepTelefonu = textBox5.Text;
            string email = textBox6.Text;
            string adres = richTextBox1.Text;
            string ehliyetNo = textBox7.Text;
            string ehliyetTuru = textBox8.Text;
            string notlar = richTextBox2.Text;
            string gorselYolu = pictureBox1.ImageLocation;
    
            if (string.IsNullOrWhiteSpace(tcKimlik) || string.IsNullOrWhiteSpace(isim) || string.IsNullOrWhiteSpace(soyisim) ||
                string.IsNullOrWhiteSpace(cepTelefonu) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(adres) || string.IsNullOrWhiteSpace(ehliyetNo) || string.IsNullOrWhiteSpace(ehliyetTuru))
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.");
                lblGoster();
                return;
            }
            else
            {
                lblGizle();
            }
            if (textBox1.Text.Length < 11)
            {
                MessageBox.Show("Lütfen 11 haneli bir kimlik numarası giriniz.");
                return;
            }
            if (textBox5.Text.Length < 10)
            {
                MessageBox.Show("Lütfen 10 haneli bir telefon numarası giriniz.");
                return;
            }

            string formattedCepNo = $"({cepTelefonu.Substring(0, 3)}) {cepTelefonu.Substring(3, 3)} {cepTelefonu.Substring(6)}";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM kisiler WHERE tc_kimlik_numarasi = @TcKimlik";
                using (SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@TcKimlik", tcKimlik);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Bu T.C. Kimlik numarası zaten mevcut.");
                        return;
                    }
                }

                string query = "INSERT INTO kisiler (tc_kimlik_numarasi, isim, soyisim, meslek, cep_telefonu, email, adres, ehliyet_no, ehliyet_turu, notlar, kisi_gorsel) " +
                               "VALUES (@TcKimlik, @Isim, @Soyisim, @Meslek, @CepTelefonu, @Email, @Adres, @EhliyetNo, @EhliyetTuru, @Notlar, @GorselYolu)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TcKimlik", tcKimlik);
                    command.Parameters.AddWithValue("@Isim", isim);
                    command.Parameters.AddWithValue("@Soyisim", soyisim);
                    command.Parameters.AddWithValue("@Meslek", meslek);
                    command.Parameters.AddWithValue("@CepTelefonu", formattedCepNo);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Adres", adres);
                    command.Parameters.AddWithValue("@EhliyetNo", ehliyetNo);
                    command.Parameters.AddWithValue("@EhliyetTuru", ehliyetTuru);
                    command.Parameters.AddWithValue("@Notlar", notlar);
                    command.Parameters.AddWithValue("@GorselYolu", gorselYolu);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kişi başarıyla eklendi.");
                        EkleVeListele();
                        BilgileriTemizle();
                    }
                    else
                    {
                        MessageBox.Show("Kişi eklenirken bir hata oluştu.");
                    }
                }
                connection.Close();
            }
        }



        private void btnmusteriSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewMusteriListesi.SelectedRows.Count > 0)
            {
                string tcKimlik = dataGridViewMusteriListesi.SelectedRows[0].Cells["dataGridViewTextBoxColumn12"].Value.ToString();
                DialogResult result = MessageBox.Show("Seçili kişiyi silmek istediğinizden emin misiniz?", "Kişi Silme", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    SilVeListele(tcKimlik);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kişiyi seçin.");
            }
        }

        private void SilVeListele(string tcKimlik)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))  
            {
                string query = "DELETE FROM kisiler WHERE tc_kimlik_numarasi = @TcKimlik";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@TcKimlik", tcKimlik);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    EkleVeListele();

                }
                connection.Close();
            }
        }
        private void btnmusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridViewMusteriListesi.SelectedRows.Count > 0)
            {
                string tcKimlik = textBox1.Text;
                string isim = textBox2.Text;
                string soyisim = textBox3.Text;
                string meslek = textBox4.Text;
                string cepTelefonu = textBox5.Text;
                string email = textBox6.Text;
                string adres = richTextBox1.Text;
                string ehliyetNo = textBox7.Text;
                string ehliyetTuru = textBox8.Text;
                string notlar = richTextBox2.Text;
                string gorselYolu = "";
                string formattedTelNo = $"({cepTelefonu.Substring(0, 3)}) {cepTelefonu.Substring(3, 3)} {cepTelefonu.Substring(6)}";
                if (pictureBox1.Visible)
                {
                    gorselYolu = pictureBox1.ImageLocation;
                }

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string query = "UPDATE kisiler SET isim = @Isim, soyisim = @Soyisim, meslek = @Meslek, cep_telefonu = @CepTelefonu, email = @Email, adres = @Adres, ehliyet_no = @EhliyetNo, ehliyet_turu = @EhliyetTuru, notlar = @Notlar, kisi_gorsel = @Gorsel WHERE tc_kimlik_numarasi = @TcKimlik";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Isim", isim);
                        command.Parameters.AddWithValue("@Soyisim", soyisim);
                        command.Parameters.AddWithValue("@Meslek", meslek);
                        command.Parameters.AddWithValue("@CepTelefonu", formattedTelNo);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Adres", adres);
                        command.Parameters.AddWithValue("@EhliyetNo", ehliyetNo);
                        command.Parameters.AddWithValue("@EhliyetTuru", ehliyetTuru);
                        command.Parameters.AddWithValue("@Notlar", notlar);
                        command.Parameters.AddWithValue("@TcKimlik", tcKimlik);
                        command.Parameters.AddWithValue("@Gorsel", gorselYolu);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kişi bilgileri başarıyla güncellendi.");
                            EkleVeListele();
                            BilgileriTemizle();
                        }
                        else
                        {
                            MessageBox.Show("Kişi bilgileri güncellenirken bir hata oluştu.");
                        }
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kişiyi seçin.");
            }
        }
        private void txtMusteriAra_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtMusteriAra.Text.ToLower();

            foreach (DataGridViewRow row in dataGridViewMusteriListesi.Rows)
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

        private void btnBilgileriGetir_Click(object sender, EventArgs e)
        {
            if (dataGridViewMusteriListesi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewMusteriListesi.SelectedRows[0];
                textBox1.Text = selectedRow.Cells["dataGridViewTextBoxColumn12"].Value.ToString();
                textBox2.Text = selectedRow.Cells["dataGridViewTextBoxColumn13"].Value.ToString();
                textBox3.Text = selectedRow.Cells["dataGridViewTextBoxColumn14"].Value.ToString();
                textBox4.Text = selectedRow.Cells["dataGridViewTextBoxColumn15"].Value.ToString();

                string formattedPhoneNumber = selectedRow.Cells["dataGridViewTextBoxColumn16"].Value.ToString();
                string unformattedPhoneNumber = formattedPhoneNumber.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                textBox5.Text = unformattedPhoneNumber;

                textBox6.Text = selectedRow.Cells["dataGridViewTextBoxColumn17"].Value.ToString();
                richTextBox1.Text = selectedRow.Cells["dataGridViewTextBoxColumn18"].Value.ToString();
                textBox7.Text = selectedRow.Cells["dataGridViewTextBoxColumn19"].Value.ToString();
                textBox8.Text = selectedRow.Cells["dataGridViewTextBoxColumn20"].Value.ToString();
                richTextBox2.Text = selectedRow.Cells["dataGridViewTextBoxColumn21"].Value.ToString();
                string tcKimlik = selectedRow.Cells["dataGridViewTextBoxColumn12"].Value.ToString();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))  
                {
                    connection.Open();
                    string query = "SELECT kisi_gorsel FROM kisiler WHERE tc_kimlik_numarasi = @TcKimlik";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TcKimlik", tcKimlik);
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblGizle();
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

                            }
                            else
                            {
                                MessageBox.Show("Kişi bilgileri bulunamadı.");
                            }
                        }
                    }
                    connection.Close();
                }
                btnmusteriGuncelle.Enabled = true;
                textBox1.Enabled = false;
                btnmusteriYeniKayit.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lütfen bir kişi seçin.");
            }
        }

        private void btnBilgileriTemizle_Click(object sender, EventArgs e)
        {
            BilgileriTemizle();
            lblGizle();
        }

        private void BilgileriTemizle()
        {
            btnmusteriGuncelle.Enabled = false;
            btnmusteriYeniKayit.Enabled = true;
            textBox1.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            richTextBox1.Clear();
            textBox7.Clear();
            textBox8.Clear();
            richTextBox2.Clear();
            pictureBox1.ImageLocation = null;
            pictureBox1.Visible = false;
            pictureBoxHide.Visible = true;
            btnGorselSec.Enabled = true;
        }

        private void btnMusteriProfili_Click_1(object sender, EventArgs e)
        {
            FrmMusteriBilgileri frmMusteriBilgileri = new FrmMusteriBilgileri(this);
            frmMusteriBilgileri.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text.All(c => !char.IsLetterOrDigit(c)))
            {
                textBox1.SelectionStart = 0;
            }
            else
            {
                textBox1.SelectionStart = textBox1.Text.Length;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text.All(c => !char.IsLetterOrDigit(c)))
            {
                textBox1.ForeColor = textBox1.BackColor;
            }
            else
            {
                textBox1.ForeColor = Color.Black;

            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskedTextBox mtb = sender as MaskedTextBox;
            if (mtb != null)
            {
                if (mtb.SelectionStart == 0 && !char.IsControl(e.KeyChar))
                {
                    mtb.SelectionStart = 0;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
