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
using Moussadjal.UserControler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using Microsoft.Practices.CompositeUI.Commands;

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

        public static  DataTable dt = new DataTable();
        public BindingSource bs = new BindingSource();
       
      //Open&Close connection
        public void Open() 
        {
            if (scn.State == ConnectionState.Closed)
            { 
              scn.Open();
            }
        }
        public void Close()
        {
            if (scn.State == ConnectionState.Open)
            {
                scn.Close();
            }
        }
        //insert
        public void Ajouter(string query)
        {   Open();
            scd = new SqlCommand(query, scn);
            scd.CommandType = CommandType.Text;
            scd.Connection = scn;
            scd.ExecuteNonQuery();
            Close();
        }
        //read/select

        public string SELECT(string qu)
        {
            Open();
            scd = new SqlCommand(qu, scn);
            scd.CommandType = CommandType.Text;
            scd.Connection = scn;
           
            if (scd.ExecuteScalar() != null) 
            {
                return scd.ExecuteScalar().ToString();
            }
            else   Close(); return "";
        }

        //update

        public void Enregistrer(string query)
        {DGVdescription dgv = new DGVdescription();
            try
            {
                Open();
                using (sda = new SqlDataAdapter(query, connection)) 
                { 
                  builder = new SqlCommandBuilder(sda);

                    dgv.dtgdve.DataSource = dt;
      
                    sda.Update(dt);

                     MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Enregistrer2T(string qt1, string qt2)
        {
            DGVdescription dgv = new DGVdescription();

            try
            {
                Open();

                // Filter modified rows for each table
                DataTable bienChanges = dt.Clone();
                DataTable descChanges = dt.Clone();

                foreach (DataRow row in dt.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        bool bienChanged =
                            !row["numero_dinventaire", DataRowVersion.Original].Equals(row["numero_dinventaire"]) ||
                            !row["Id_lieu", DataRowVersion.Original].Equals(row["Id_lieu"]);

                        bool descChanged =
                            !row["numero_sequentiel", DataRowVersion.Original].Equals(row["numero_sequentiel"]) ||
                            !row["division", DataRowVersion.Original].Equals(row["division"]) ||
                            !row["designation", DataRowVersion.Original].Equals(row["designation"]) ||
                            !row["annee", DataRowVersion.Original].Equals(row["annee"]) ||
                            !row["observation", DataRowVersion.Original].Equals(row["observation"]);

                        if (bienChanged)
                            bienChanges.ImportRow(row);

                        if (descChanged)
                            descChanges.ImportRow(row);
                    }
                }

                // Update Bien table
                if (bienChanges.Rows.Count > 0)
                {
                    using (sda = new SqlDataAdapter(qt1, connection))
                    {
                        builder = new SqlCommandBuilder(sda);
                        sda.Update(bienChanges);
                    }
                }

                // Update Description_de_bien table
                if (descChanges.Rows.Count > 0)
                {
                    using (sda = new SqlDataAdapter(qt2, connection))
                    {
                        builder = new SqlCommandBuilder(sda);
                        sda.Update(descChanges);
                    }
                }

                MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }

        //delete

        public void Suprimer(string query)
        {
            if (scn.State != ConnectionState.Open)
                Open();
            SqlCommand cmd = new SqlCommand(query, scn);
            cmd.ExecuteNonQuery();
            Close();
            MessageBox.Show("Suppression effectuée avec succès", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Select counte 
        public int FillscdToSelectCount(string query) 
        {
            Open();
            scd = new SqlCommand(query, scn);
            scd.CommandType = CommandType.Text;
            scd.Connection = scn;
            int  result = (int)scd.ExecuteScalar();
            Close();
            return result;
        }
        public DataTable DtOfSelect(string query)
        {
            Open();
            scd = new SqlCommand(query, scn);
          sda = new SqlDataAdapter(scd);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            Close();
            return  dataTable;
        }
        // méthode de remplisage coombobox
        public void remlirCombo(string table,  Guna2ComboBox comb, string dm , string vm)
        {
            Open();
            scd.Connection = scn;
            scd.CommandText = $"select DISTINCT {vm}, {dm} from {table}" ;
            sda.SelectCommand = scd;
            sda.Fill(ds, "dt" + table);
            comb.DataSource = ds.Tables["dt" + table];
            comb.DisplayMember = dm;
            comb.ValueMember = vm;
            dt = ds.Tables[table];
            Close();
        }
        public void FillComboWithJoinedData(
            string valueTable,
            string vm,
            string displayTable,
            string dm,
            string joinCondition,
           string whereColumn,
           string whereValue,
           Guna2ComboBox comboBox)
        {
            try
            {
                Open(); 

                string query = $@" SELECT   {valueTable}.{vm} AS ValueMember,
                {displayTable}.{dm} AS DisplayMember
                   FROM       {valueTable}
                   JOIN    {displayTable} ON {joinCondition}
                  WHERE  {whereColumn}='{whereValue}'";
          
                scd.Connection = scn;
                scd.CommandText = query;
                sda.SelectCommand = scd;

            
                string tableName = $"dt_{valueTable}_{displayTable}_{DateTime.Now.Ticks}";
                sda.Fill(ds, tableName);

                comboBox.DataSource = ds.Tables[tableName];
                comboBox.ValueMember = "ValueMember"; 
                comboBox.DisplayMember = "DisplayMember"; 

                Close(); 
            }
            catch (Exception ex)
            {
                Close();
                MessageBox.Show($"Error loading combo: {ex.Message}");
            }
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
        public  void  remplirgridview(string query, DataGridView dg)
        { Open();
            sda = new SqlDataAdapter(query, connection);
            builder = new SqlCommandBuilder(sda);
            sda.Fill(dt);
            dg.DataSource = dt;
            Close();
        }
        public void  EmptyDataGridView(DataGridView dg)
        {
           dt = new DataTable(); 
            bs.DataSource = dt;
            dg.DataSource = bs;
        }
    

    }
}
