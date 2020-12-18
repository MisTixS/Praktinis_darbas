using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktinis
{
  
    public class GroupRepository
    {
        private SqlConnection conn;

        public GroupRepository()
        {
            conn = new SqlConnection(@"Server=TOBY-PC;Database=Praktinis; User ID=sa;Password=123456");
        }
        public void PridetiGrupe(string name)
        {
            try
            {
                string sql = "insert into grupes(pavadinimas) " +
                                   "values (@pavadinimas)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pavadinimas", name);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public void IstrintiGrupe(int id)
        {
            try
            {
                string sql = "delete from grupes " +
                         "where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Grupe istrinta.");
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }

}
