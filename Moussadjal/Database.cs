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
using System.Windows.Forms;

namespace Moussadjal
{
    public class Database
    {//Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjale;User ID=abdomm_Moussadjale;Password=***********;Trust Server Certificate=True
        public Guna2ComboBox comb2 = null;
        public SqlConnection scn = new SqlConnection(@"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjale;User ID=abdomm_Moussadjale;Password=10101030");
        public SqlCommand scd = new SqlCommand();
        public SqlDataAdapter sda= new SqlDataAdapter();
        public DataSet ds = new DataSet();
        DataTable dt;
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
        public void remlirCombo(string table,  Guna2ComboBox comb, string dm , string vm)
        {
            scn.Open();
            scd.Connection = scn;
            scd.CommandText = $"select DISTINCT {vm}, {dm} from {table}" ;
            sda.SelectCommand = scd;
            sda.Fill(ds, "dt" + table);
            comb.DataSource = ds.Tables["dt" + table];
            comb.DisplayMember = dm;
            comb.ValueMember = vm;
            dt = ds.Tables[table];
            scn.Close();
        }
        //methode de remplissage datagridview 
        public void remplirgridview(string query, string tab, DataGridView dg)
        {
            scd.Connection = scn;
            scd.CommandText = query;
            sda.SelectCommand = scd;
            sda.Fill(ds, "dt" + tab);
            dg.DataSource = ds.Tables["dt" + tab];
        }
        //abdou
    }
}
