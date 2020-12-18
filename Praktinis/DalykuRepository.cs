using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktinis
{

    public class DalykuRepository
    {
        private SqlConnection conn;

        public DalykuRepository()
        {
            conn = new SqlConnection(@"Server=TOBY-PC;Database=Praktinis; User ID=sa;Password=123456");
        }
        public void PridetiDalyka(string name, string grupes_id, string destytojo_id)
        {
            try
            {
                string sql = "insert into dalykai(pavadinimas, grupes_id, destytojo_id) " +
                                   "values (@pavadinimas, @grupes_id, @destytojo_id)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pavadinimas", name);
                cmd.Parameters.AddWithValue("@grupes_id", grupes_id );
                cmd.Parameters.AddWithValue("@destytojo_id", destytojo_id );
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


        public void IstrintiDalyka(int id)
        {
            try
            {
                string sql = "delete from dalykai " +
                         "where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dalykas istrintas.");
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
