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
    public partial class FrmArac : Form
    {
        static Baglanti baglanti = new Baglanti();
        public string connectionString = $"Data Source={baglanti.Adres};Version=3;";
        public FrmArac()
        {
            InitializeComponent();

        }

        private void FrmArac_Load(object sender, EventArgs e)
        {

            AraclariListele();
        }
        private void txtAracAra_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtAracAra.Text.ToLower();
            foreach (DataGridViewRow row in dataGridViewTumAraclar.Rows)
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

        public void AraclariListele()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM araclar";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewTumAraclar.DataSource = dataTable;
                    }
                }
                connection.Close();
            }
        }
        private void btnaracSil_Click(object sender, EventArgs e)
        {
            string plaka = dataGridViewTumAraclar.SelectedRows[0].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            DialogResult result = MessageBox.Show("Seçilen aracı silmek istediğinizden emin misiniz?", "Araç Silme", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM araclar WHERE plaka = @Plaka";
                    using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@Plaka", plaka);
                        int rowsAffected = deleteCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Araç başarıyla silindi.");
                            AraclariListele();
                        }
                        else
                        {
                            MessageBox.Show("Araç silinirken bir hata oluştu.");
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void btnaracEkle_Click(object sender, EventArgs e)
        {
            FrmAracEkle aracekle = new FrmAracEkle(this);
            aracekle.ShowDialog();
        }
        private void btnaracDuzenle_Click(object sender, EventArgs e)
        {
            FrmAracDuzenle aracduzenle = new FrmAracDuzenle(this);
            aracduzenle.ShowDialog();
        }
        private void btnAracBilgileri_Click(object sender, EventArgs e)
        {
            FrmAracBilgileriTum aracbilgileritum = new FrmAracBilgileriTum(this);
            aracbilgileritum.ShowDialog();
        }


    }
}
