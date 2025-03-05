using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;

namespace Moussadjal
{
    public class Database
    {
        public SqlConnection scn = new SqlConnection(@"Data Source=sql.bsite.net\MSSQL2016;Initial Catalog=abdomm_Moussadjalsql;User ID=abdomm_Moussadjalsql;Password=9876543210987");
        public SqlCommand scd = new SqlCommand();
        public SqlDataAdapter sda= new SqlDataAdapter();
        public void Fillscd(string q)
        {   scn.Open();
             scd = new SqlCommand(q, scn);

           scd.CommandType = CommandType.Text;
          scd.Connection = scn;
        }
    }
}
