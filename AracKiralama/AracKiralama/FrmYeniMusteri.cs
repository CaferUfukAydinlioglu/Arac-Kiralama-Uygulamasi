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

namespace AracKiralama
{
    public partial class FrmYeniMusteri : Form
    {
        int mov;
        int movX;
        int movY;

        public FrmAracKirala _frmAracKirala;
        static Baglanti baglanti = new Baglanti();
        string connectionString = $"Data Source={baglanti.Adres};Version=3;";
        public FrmYeniMusteri(FrmAracKirala frmAracKirala)
        {
            InitializeComponent();
            _frmAracKirala = frmAracKirala;
        }
        private void FrmYeniMusteri_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = textBox1.BackColor;

            MaskedTextBox textBox5 = new MaskedTextBox();
            textBox5.Mask = "(999) 999 9999";
            textBox5.PromptChar = ' ';
            textBox5.ResetOnPrompt = false;
            textBox5.Location = new System.Drawing.Point(20, 20);
            textBox5.Width = 200;
            textBox5.KeyPress += new KeyPressEventHandler(textBox5_KeyPress);

            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;
            int x = (screenRectangle.Width - this.Width) / 2;
            int y = (screenRectangle.Height - this.Height) / 2;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
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
                lbl1.Visible = true; lbl1.Text = "*";
                lbl2.Visible = true; lbl2.Text = "*";
                lbl3.Visible = true; lbl3.Text = "*";
                lbl4.Visible = true; lbl4.Text = "*";
                lbl5.Visible = true; lbl5.Text = "*";
                lbl6.Visible = true; lbl6.Text = "*";
                lbl7.Visible = true; lbl7.Text = "*";
                lbl8.Visible = true; lbl8.Text = "*";

                return;
            }
            else
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
                    }
                    else
                    {
                        MessageBox.Show("Kişi eklenirken bir hata oluştu.");
                    }
                }
                connection.Close();
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmYeniMusteri_FormClosing(object sender, FormClosingEventArgs e)
        {
            _frmAracKirala.MusaitKisileriGetir();
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
