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
    {
        //Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjale;User ID=abdomm_Moussadjale;Password=***********;Trust Server Certificate=True

        public SqlConnection scn = new SqlConnection(@"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjale;User ID=abdomm_Moussadjale;Password=10101030");

        public SqlCommand scd = new SqlCommand();
        public SqlDataAdapter sda = new SqlDataAdapter();
        public DataSet ds = new DataSet();
        public SqlCommandBuilder builder;

        public string query;
        string connection = @"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjale;User ID=abdomm_Moussadjale;Password=10101030";

        public DataTable dt = new DataTable();
        public BindingSource bs = new BindingSource();
        //insert
        public void Ajouter(string query)
        {   scn.Open();
            scd = new SqlCommand(query, scn);
            scd.CommandType = CommandType.Text;
            scd.Connection = scn;
            scd.ExecuteNonQuery();
            scn.Close();
        }
        //read/select

        //update
        public int Modifier(string query)
        {
         
            scd.ExecuteNonQuery();
            //scn.Close();
            return scd.ExecuteNonQuery();
        }
        public void Enregistrer ( DataGridView dg)
        {

                    sda = new SqlDataAdapter(query, connection);
                    builder = new SqlCommandBuilder(sda);
                    sda.Fill(dt);
                  //  sda.Update(dt);
                    bs.DataSource = dt;
                    dg.DataSource = bs;
           
            try
            {
                    // Save changes from the DataTable back to the database
                    sda.Update(dt);

                    // Optionally, refresh the DataGridView to reflect any changes
                    dt.Clear();
                    sda.Fill(dt);
                
                

                MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /* try
             {
                 scd.Connection = scn;
                 scd.CommandText = query;
                 builder = new SqlCommandBuilder(sda);

                 sda.SelectCommand = scd;

                 scn.Open();
                 sda.Update(ds, "dt" + tab);

                 ds.Clear();
                 sda.Fill(ds, "dt" + tab);
                 dg.DataSource = ds.Tables["dt" + tab];

                 MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }
          
        //delete
        
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

            sda = new SqlDataAdapter(query, connection);
            builder = new SqlCommandBuilder(sda);
            sda.Fill(dt);
            bs.DataSource = dt;
            dg.DataSource = bs;

            /*scd.Connection = scn;
            scd.CommandText = query;
            sda.SelectCommand = scd;
            sda.Fill(ds, "dt" + tab);
            dg.DataSource = ds.Tables["dt" + tab];*/
        }
    }
}
