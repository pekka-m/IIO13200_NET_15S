using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JAMK.IT
{
    public static class DBDemoxOy
    {

        public static DataTable GetDataSimple()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Rows.Add("Kalle", "Joku");
            dt.Rows.Add("Mala", "Jeppe");
            return dt;
        }

        public static DataTable GetDataReal(string connStr)
        {
            // DB-kerros, haetaan DemoxOy-tietokannan talun lasnaolot tietueet
            try
            {
                string sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // avataan yhteys
                    conn.Open();
                    // luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "lasnaolot");
                        return ds.Tables["lasnaolot"];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SearchData(string connStr, string search)
        {
            // DB-kerros, haetaan DemoxOy-tietokannan talun lasnaolot tietueet
            try
            {
                string sql;
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE asioid LIKE '%" + search + "%'";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // avataan yhteys
                    conn.Open();
                    // luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "lasnaolot");
                        return ds.Tables["lasnaolot"];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
