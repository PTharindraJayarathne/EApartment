using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

//namespace ChiefOccupantHome
//{
//    internal class Data
//    {
//        public static string cs = ConfigurationManager.ConnectionStrings["dbcon"].ToString();

//        public static void ExecuteQuery(string sql)
//        {
//            using (SqlConnection con = new SqlConnection(cs)) 
//            {
//                con.Open();
//                SqlCommand cmd = new SqlCommand(sql, con);
//                cmd.ExecuteNonQuery();
//            }
//        }
         
//        public static DataSet getdata(string sql) 
//        {
//            using (SqlConnection con = new SqlConnection(cs)) 
//            {
//                SqlDataAdapter da = new SqlDataAdapter(sql, con);
//                DataSet ds = new DataSet();
//                da.Fill(ds);
//                return ds;
//            }
//        }
//    } 
//}
