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
    public partial class FrmKira : Form
    {
        static Baglanti baglanti = new Baglanti();
        public string connectionString = $"Data Source={baglanti.Adres};Version=3;";

        public FrmKira()
        {
            InitializeComponent();
        }

        private void FrmKira_Load(object sender, EventArgs e)
        {
            MusaitAraclariGetir();
            KiralananAraclariGetir();
        }

        public void MusaitAraclariGetir()
        {
            string query = "SELECT * FROM araclar WHERE kiralik = 0";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewMusait.DataSource = dataTable;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void KiralananAraclariGetir()
        {
            string query = "SELECT * FROM araclar WHERE kiralik = 1";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewKiralik.DataSource = dataTable;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnKiraArac_Click(object sender, EventArgs e)
        {
            FrmAracKirala kira = new FrmAracKirala(this);
            kira.ShowDialog();
        }

        private void btnMusaitAracBilgisi_Click(object sender, EventArgs e)
        {
            FrmAracBilgileri aracbilgileri = new FrmAracBilgileri(this);
            aracbilgileri.ShowDialog();
        }

        private void btnKiralikAracBilgisi_Click(object sender, EventArgs e)
        {
            FrmAracBilgileriKiralik aracbilgileri2 = new FrmAracBilgileriKiralik(this);
            aracbilgileri2.ShowDialog();
        }

        private void btnKiraBitir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kirayı bitirmeye emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            string plaka = dataGridViewKiralik.SelectedRows[0].Cells["plakaDataGridViewTextBoxColumn1"].Value.ToString();
            string tcKimlik = dataGridViewKiralik.SelectedRows[0].Cells["tcnoDataGridViewTextBoxColumn1"].Value.ToString();

            string query = "UPDATE araclar SET kiralik = 0 WHERE plaka = @plaka";
            string query2 = "UPDATE kisiler SET kisi_plaka ='Yok', kisi_kiralik = 0 WHERE tc_kimlik_numarasi = @tc_kimlik_numarasi";

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
                        command.Parameters.AddWithValue("@tcNo", tcKimlik);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            KiralananAraclariGetir();
                            MusaitAraclariGetir();
                            MessageBox.Show("İşlem Başarılı", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


    }
}
