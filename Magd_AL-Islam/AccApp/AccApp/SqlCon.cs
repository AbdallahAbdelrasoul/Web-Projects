using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace AccApp
{
    class SqlCon
    {
        //static string USER = "root";
        //static string PASS = "m3anayarab-mysql";
        static string dbNAME = "acc";
        static string MachineName = Environment.MachineName; 
        private SqlConnection con;

        public SqlConnection CreateConnection()
        {
            try
            {
                if(con is null)
                {
                    con = new SqlConnection(@"Data Source=" + string.Format(@"{0}\SQLEXPRESS", MachineName) + ";Initial Catalog=" + dbNAME + ";Integrated Security=True");
                }
                else { return con; }
                //System.Windows.Forms.MessageBox.Show("Connected database successfully...");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }

            return con;
        }

        public SqlConnection IsConnection(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            return con;
        }
        
    }
}
    