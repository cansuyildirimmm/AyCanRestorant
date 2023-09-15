using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyCanRestorant
{
    public partial class Form2 : Form
    {
        List<YemekListesi> yemekListesi = new List<YemekListesi>();
        private object baglanti;

        public SqlCommand komut { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT * FROM YEMEKLISTESII ORDER BY YEMEKID");

            using (SqlCommand cmd = new SqlCommand(sql, SQLConnection.Run()))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        YemekListesi yemek = new YemekListesi();

                        yemek.YEMEKID = dr["YEMEKID"] == DBNull.Value ? 0 :  Convert.ToInt32(dr["YEMEKID"]);
                        yemek.YEMEKADI = dr["YEMEKADI"].ToString();
                        yemek.ACIKLAMA = dr["ACIKLAMA"].ToString();
                        yemek.FIYAT = Convert.ToDecimal(dr["FIYAT"]);

                        yemekListesi.Add(yemek);

                    }
                }
            }

            dataGridView1.DataSource = yemekListesi;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                string kayit = "insert into YEMEKLISTESII(YEMEKADI,ACIKLAMA,FIYAT) values (@YEMEKADI,@ACIKLAMA,@FIYAT) SET @ID = SCOPE_IDENTITY()";

                using (SqlCommand komut = new SqlCommand(kayit, SQLConnection.Run()))
                {
                    komut.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //var newIdParam = komut.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    komut.Parameters.Add("@YEMEKADI",SqlDbType.VarChar).Value = textBoxYemekAdı.Text;
                    //komut.Parameters.AddWithValue("@YEMEKADI", textBoxYemekAdı.Text);
                    komut.Parameters.AddWithValue("@ACIKLAMA", textBoxAcıklama.Text);
                    //!!!
                    komut.Parameters.AddWithValue("@FIYAT",SqlDbType.Decimal).Value =textBoxFiyat.Text;

                    komut.ExecuteNonQuery();
                     id = Convert.ToInt32(komut.Parameters["@ID"].Value);

                }

                YemekListesi yemek = new YemekListesi()
                {
                    ACIKLAMA = textBoxAcıklama.Text,
                    FIYAT = textBoxFiyat.Text == "" ? 0 : Convert.ToInt32(textBoxFiyat.Text),
                    YEMEKADI = textBoxYemekAdı.Text,
                    YEMEKID = id
                };

                yemekListesi.Add(yemek);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = yemekListesi;

                MessageBox.Show("İşlem başarıyla gerçekleştirildi.");
            }
            catch( Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void DeleteSelectedRow(int yemekID)
        {
            using (var db = SQLConnection.Run())
            {
                string deleteSql = "DELETE FROM YEMEKLISTESII WHERE YEMEKID = @YemekID";
                db.Execute(deleteSql, new { YemekID = yemekID });
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    var selected = (YemekListesi)selectedRow.DataBoundItem;

                    DeleteSelectedRow(selected.YEMEKID);

                    yemekListesi.Remove(selected);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = yemekListesi;

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

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            using (var db = SQLConnection.Run())
            {
                //!!!
                string sorgu = "UPDATE YEMEKLISTESII SET YEMEKADI=@YEMEKADI, ACIKLAMA=@ACIKLAMA, FIYAT=@FIYAT WHERE YEMEKID=@YEMEKID";

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                var selected = (YemekListesi)selectedRow.DataBoundItem;

                int yemekId = selected.YEMEKID; //Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                db.Execute(sorgu, new
                {
                    YEMEKID = yemekId,
                    YEMEKADI = textBoxYemekAdı.Text,
                    ACIKLAMA = textBoxAcıklama.Text,
                    FIYAT = Convert.ToDecimal(textBoxFiyat.Text),
                });

                //DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                //var selected = (YemekListesi)selectedRow.DataBoundItem;

                selected.YEMEKADI = textBoxYemekAdı.Text;
                selected.ACIKLAMA = textBoxAcıklama.Text;
                selected.FIYAT = Convert.ToDecimal(textBoxFiyat.Text);


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = yemekListesi;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            var selected = (YemekListesi)selectedRow.DataBoundItem;

            string ad = selected.YEMEKADI; //dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string bilgi = selected.ACIKLAMA; //dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            decimal adet = selected.FIYAT;// dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            textBoxYemekAdı.Text = ad;
            textBoxAcıklama.Text = bilgi;
            textBoxFiyat.Text = adet.ToString();
        }
    }
}
