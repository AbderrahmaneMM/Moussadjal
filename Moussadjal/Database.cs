using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;
using ZXing;
using Guna.UI2.WinForms;

namespace Moussadjal
{
    public class Database
    {//Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjale;User ID=abdomm_Moussadjale;Password=***********;Trust Server Certificate=True
        public Guna2ComboBox comb2 = null;
        public SqlConnection scn = new SqlConnection(@"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjale;User ID=abdomm_Moussadjale;Password=10101030");
        public SqlCommand scd = new SqlCommand();
        public SqlDataAdapter sda= new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public void FillscdToInsert(string query)
        {   scn.Open();
            scd = new SqlCommand(query, scn);
            scd.CommandType = CommandType.Text;
            scd.Connection = scn;
            scd.ExecuteNonQuery();
            scn.Close();
        }
        // Select counte 
        public int FillscdToSelectCount(string query) 
        {
            scn.Open();
            scd = new SqlCommand(query, scn);
            scd.CommandType = CommandType.Text;
            scd.Connection = scn;
            int result = (int)scd.ExecuteScalar();
            scn.Close();
            return result;
        }
        // méthode de remplisage coombobox
        public void remlirCombo(string table,  Guna2ComboBox comb)
        {
            scd.Connection = scn;
            scd.CommandText = "select DISTINCT numero_sequentiel, designation from " + table;
            sda.SelectCommand = scd;
            sda.Fill(ds, "dt" + table);
            comb.DataSource = ds.Tables["dt" + table];
            comb.DisplayMember = "numero_sequentiel";
            comb.ValueMember = "designation";
          //  comb2 = comb;
           // comb2.ValueMember = "designation";
          //  comb2 = comb;
          // comb2.ValueMember = "id_realisateur";
        }
        public void remlirCombo2(string table, Guna2ComboBox comb)
        {
            scd.Connection = scn;
            scd.CommandText = "select * from " + table;
            sda.SelectCommand = scd;
            sda.Fill(ds, "dt" + table);
            comb.DataSource = ds.Tables["dt" + table];
            comb.DisplayMember = "designation ";
            comb.ValueMember = "Id_lieu";

            //  comb2 = comb;
            // comb2.ValueMember = "id_realisateur";
        }

    }
}
