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
using System.Windows.Controls;

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
     
        public void Enregistrer(string query, DataGridView dg)
        {
            try
            {
                scn.Open();
                using (sda = new SqlDataAdapter(query, connection))
                {
                    builder = new SqlCommandBuilder(sda);

                    sda.Update(dt);

                    dt.Clear();
                    sda.Fill(dt);

                    bs.DataSource = dt;
                    dg.DataSource = bs;
                     MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                scn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Enregistrer2T(string qt1, string qt2, string query, DataGridView dg)
        {
            try
            {
                scn.Open();
                // تحديث جدول Bien
                using (SqlDataAdapter adapterBien = new SqlDataAdapter(qt1, connection))
                {
                    new SqlCommandBuilder(adapterBien);
                    adapterBien.Fill(dt);
                    adapterBien.Update(dt);
                }

                // تحديث جدول Description_de_bien
                using (SqlDataAdapter adapterDesc = new SqlDataAdapter(qt2, connection))
                {
                    new SqlCommandBuilder(adapterDesc);
                    adapterDesc.Update(dt);
                }

                // إعادة تعبئة البيانات
                dt.Clear();
                using (sda = new SqlDataAdapter(query, connection))
                {
                    sda.Fill(dt);
                }

                dg.DataSource = dt;
                MessageBox.Show("تم حفظ التغييرات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                scn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في حفظ التغييرات: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*var ds = new DataSet();
            
            // Fill and update first table
            using (var adapter1 = new SqlDataAdapter(table1Query, connection))
            {
                new SqlCommandBuilder(adapter1);
                var dt1 = new DataTable();
                adapter1.Fill(dt1);
                adapter1.Update(dt1);
            }
            
            // Fill and update second table
            using (var adapter2 = new SqlDataAdapter(table2Query, connection))
            {
                new SqlCommandBuilder(adapter2);
                var dt2 = new DataTable();
                adapter2.Fill(dt2);
                adapter2.Update(dt2);
            }
            
            // Refresh the joined view
            using (var adapterJoin = new SqlDataAdapter(joinQuery, connection))
            {
                var dt = new DataTable();
                adapterJoin.Fill(dt);
                dg.DataSource = dt;
            }
            
            MessageBox.Show("تم حفظ التغييرات بنجاح!", "نجاح", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("خطأ في حفظ التغييرات: " + ex.Message, "خطأ", 
                       MessageBoxButtons.OK, MessageBoxIcon.Error);*/
        }
        //delete

        public void Suprimer(string query)
        {
            if (scn.State != ConnectionState.Open)
                scn.Open();
            SqlCommand cmd = new SqlCommand(query, scn);
            cmd.ExecuteNonQuery();
            scn.Close();
            MessageBox.Show("Suppression effectuée avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public DataSet search(string query , DataGridView dg)
        {
            SqlCommand cmd = new SqlCommand(query, scn);
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dp.Fill(ds);
            return ds;
        }
        public void remplirgridview(string query, DataGridView dg)
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
        public void EmptyDataGridView(DataGridView dg)
        {
            dt = new DataTable(); // Replace with fresh empty DataTable
            bs.DataSource = dt;
            dg.DataSource = bs;
        }
    }
}
