using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Dapper;


namespace AyCanRestorant
{
    public partial class YemekMalzemeTablosu : Form
    {
        public YemekMalzemeTablosu()
        {
            InitializeComponent();
        }

        private void YemekMalzemeTablosu_Load(object sender, EventArgs e)
        {
            // Load Yemek List
            List<YemekListesi> yemekler = new List<YemekListesi>();
            string yemekSql = "SELECT * FROM YEMEKLISTESII ORDER BY YEMEKADI";

            using (var db = SQLConnection.Run())
            {
                yemekler = db.Query<YemekListesi>(yemekSql).AsList();
            }

            comboBoxYemekler.DataSource = yemekler;
            comboBoxYemekler.DisplayMember = "YEMEKADI";
            comboBoxYemekler.ValueMember = "YEMEKID";

            // Load Malzeme List
            List<MalzemeListesi> malzemeler = new List<MalzemeListesi>();
            string malzemeSql = "SELECT * FROM MALZEMELISTESI ORDER BY MALZEMEAD";

            using (var db = SQLConnection.Run())
            {
                malzemeler = db.Query<MalzemeListesi>(malzemeSql).AsList();
            }

            listBoxMalzemeler.DataSource = malzemeler;
            listBoxMalzemeler.DisplayMember = "MALZEMEAD";
            listBoxMalzemeler.ValueMember = "MALZEMEID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int yemekID = (int)comboBoxYemekler.SelectedValue;
            List<YemekListesi> secilenYemekler = new List<YemekListesi>();

            using (var db = SQLConnection.Run())
            {
                try
                {
                    for (int i = 0; i < listBoxMalzemeler.SelectedItems.Count; i++)
                    {

                        string sql = "INSERT INTO IDLER (YEMEKID, MALZEMEID) VALUES (@yemekID, @malzemeID)";

                        var parameters = new DynamicParameters();

                        //var QQ = listBoxMalzemeler.SelectedIndices[i];
                   
                       
                        parameters.Add("malzemeID", ((MalzemeListesi)listBoxMalzemeler.SelectedItems[i]).MALZEMEID);
                        parameters.Add("yemekID", yemekID);

                        db.Execute(sql, parameters) ;
                        //MessageBox.Show(listBoxMalzemeler.SelectedItems[i].ToString());
                    }

                    MessageBox.Show("başarılı");
                }
                catch 
                {
                    
                }
                
            }
           
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxYemekler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


        


  
        

        
    

       
       
    

    

