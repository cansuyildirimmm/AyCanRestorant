using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AyCanRestorant
{
    public partial class frmMenu : Form
    {
        List<MalzemeListesi> malzemeListesi = new List<MalzemeListesi>();
        private object baglanti;

        public SqlCommand komut { get; private set; }

        public frmMenu()
        {

            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT * FROM MALZEMELISTESI ORDER BY MALZEMEID");

            using (SqlCommand cmd = new SqlCommand(sql, SQLConnection.Run()))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MalzemeListesi malzeme = new MalzemeListesi();

                        malzeme.MALZEMEID = Convert.ToInt32(dr["MALZEMEID"]);
                        malzeme.MALZEMEAD = dr["MALZEMEAD"].ToString();
                        malzeme.MALZEMEBILGISI = dr["MALZEMEBILGISI"].ToString();
                        malzeme.MALZEMEADEDI = Convert.ToDouble(dr["MALZEMEADEDI"]);

                        malzemeListesi.Add(malzeme);
                    }
                }
            }

            dataGridView1.DataSource = malzemeListesi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void load()
        {
            string sql = string.Format("SELECT * FROM MALZEMELISTESI ORDER BY MALZEMEID");

            using (SqlCommand cmd = new SqlCommand(sql, SQLConnection.Run()))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MalzemeListesi malzeme = new MalzemeListesi();

                        malzeme.MALZEMEID = Convert.ToInt32(dr["MALZEMEID"]);
                        malzeme.MALZEMEAD = dr["MALZEMEAD"].ToString();
                        malzeme.MALZEMEBILGISI = dr["MALZEMEBILGISI"].ToString();
                        malzeme.MALZEMEADEDI = Convert.ToDouble(dr["MALZEMEADEDI"]);

                        malzemeListesi.Add(malzeme);
                    }
                }
            }

            dataGridView1.DataSource = malzemeListesi;
        }
        
        
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                
                string kayit = "insert into MALZEMELISTESI(MALZEMEAD,MALZEMEBILGISI,MALZEMEADEDI) values (@MALZEMEAD,@MALZEMEBILGISI,@MALZEMEADEDI)";

                using (SqlCommand komut = new SqlCommand(kayit, SQLConnection.Run()))
                {
                    komut.Parameters.AddWithValue("@MALZEMEAD", textBoxMalzemeAd.Text);
                    komut.Parameters.AddWithValue("@MALZEMEBILGISI", textBoxMalzemeBilgisi.Text);
                    komut.Parameters.AddWithValue("@MALZEMEADEDI", textBoxMalzemeAdedi.Text);

                    komut.ExecuteNonQuery();
                }

                using (var db = SQLConnection.Run())
                {
                    string sorgu = "SELECT TOP 1 MALZEMEID FROM MALZEMELISTESI ORDER BY MALZEMEID DESC";
                    using (SqlCommand cmd = new SqlCommand(sorgu, SQLConnection.Run()))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                MalzemeListesi malzeme = new MalzemeListesi();
                                int malzemeid = Convert.ToInt32(dr["MALZEMEID"]);
                                malzeme.MALZEMEID = malzemeid;
                                malzeme.MALZEMEAD = textBoxMalzemeAd.Text;
                                malzeme.MALZEMEBILGISI = textBoxMalzemeBilgisi.Text;
                                malzeme.MALZEMEADEDI = Convert.ToDouble(textBoxMalzemeAdedi.Text);

                                malzemeListesi.Add(malzeme);
                            }
                        }
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = malzemeListesi;

                MessageBox.Show("İşlem başarıyla gerçekleştirildi.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)

        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    var selected = (MalzemeListesi)selectedRow.DataBoundItem;

                    DeleteSelectedRow(selected.MALZEMEID);

                    malzemeListesi.Remove(selected);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = malzemeListesi;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete");
            }
             

        }
        private void DeleteSelectedRow(int malzemeID)
        {
            using (var db = SQLConnection.Run())
            {
                string deleteSql = "DELETE FROM MALZEMELISTESI WHERE MALZEMEID = @MalzemeID";
                db.Execute(deleteSql, new { MalzemeID = malzemeID });
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = SQLConnection.Run())
            {
                string sorgu = "UPDATE MALZEMELISTESI SET MALZEMEAD=@MALZEMEAD, MALZEMEBILGISI=@MALZEMEBILGISI, MALZEMEADEDI=@MALZEMEADEDI WHERE MALZEMEID=@MALZEMEID";
                int malzemeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                db.Execute(sorgu, new {
                    MALZEMEID = malzemeId,
                    MALZEMEAD = textBoxMalzemeAd.Text,
                    MALZEMEBILGISI = textBoxMalzemeBilgisi.Text,
                    MALZEMEADEDI = textBoxMalzemeAdedi.Text,
                });

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                var selected = (MalzemeListesi)selectedRow.DataBoundItem;

                selected.MALZEMEAD = textBoxMalzemeAd.Text;
                selected.MALZEMEBILGISI = textBoxMalzemeBilgisi.Text;
                selected.MALZEMEADEDI = Convert.ToDouble(textBoxMalzemeAdedi.Text);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = malzemeListesi;

            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            var selected = (MalzemeListesi)selectedRow.DataBoundItem;

            string ad = selected.MALZEMEAD; //dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string bilgi = selected.MALZEMEBILGISI; //dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            double adet = selected.MALZEMEADEDI;// dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            textBoxMalzemeAd.Text = ad;
            textBoxMalzemeBilgisi.Text = bilgi;
            textBoxMalzemeAdedi.Text = adet.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
