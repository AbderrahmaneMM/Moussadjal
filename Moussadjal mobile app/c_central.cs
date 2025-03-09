using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Moussadjal_mobile_app
{
    class c_central
    {//Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjale;User ID=abdomm_Moussadjale;Password=***********;Trust Server Certificate=True
        public SqlConnection scn = new SqlConnection(@"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjale;User ID=abdomm_Moussadjale;Password=10101030");
        public SqlCommand scd = new SqlCommand();
        public SqlDataAdapter sda = new SqlDataAdapter();
        public void FillscdToInsert(string query)
        {
            scn.Open();
            scd = new SqlCommand(query, scn);
            scd.CommandType = CommandType.Text;
            scd.Connection = scn;
            scd.ExecuteNonQuery();
            scn.Close();
        }
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
    }
}
