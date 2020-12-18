using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using LoginApp;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginApp
{
    public class UsersRepository
    {
        private static List<User> usersList;

        private SqlConnection conn;

        public List<User> GetUsers()
        {
            return usersList;
        }

        public UsersRepository()
        {
            conn = new SqlConnection(@"Server=TOBY-PC;Database=Praktinis;User ID=sa;Password=123456");
        }

        public User Login(string username, string password)
        {
            try
            {
                string sql = "select vardas, pavarde, gimimo_data, slapyvardis, slaptazodis, tipas, grupes_id from [vartotojai] " +
                        "where slapyvardis=@slapyvardis and slaptazodis=@slaptazodis";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@slapyvardis", username);
                cmd.Parameters.AddWithValue("@slaptazodis", password);
                conn.Open();



                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["vardas"].ToString();
                        string surname = reader["pavarde"].ToString();
                        DateTime date = DateTime.Parse(reader["gimimo_data"].ToString());
                        string usrname = reader["slapyvardis"].ToString();
                        string pass = reader["slaptazodis"].ToString();       
                        string type = reader["tipas"].ToString();
                        string groupid = reader ["grupes_id"].ToString();
                        return new User(name, surname, date, usrname, pass, type, groupid);
                    }
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            throw new Exception("Blogai ivesti duomenis");
        }

        public string GetUserId(string username)
        {
            try
            {
                string userid = "";
                conn.Open();
                string sql = "select id, vardas, pavarde, gimimo_Data, slapyvardis, slaptazodis, tipas, grupes_id from [vartotojai] " +
                         "where slapyvardis=@slapyvardis";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sReader;
                cmd.Parameters.AddWithValue("@slapyvardis", username);
                sReader = cmd.ExecuteReader();
                if (sReader.Read())
                {
                    userid = sReader["id"].ToString();
                }
                return userid;

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



        public void PatikrintiPrisijungima(string username)
        {
            try
            {
                string sql = "select vardas, pavarde, gimimo_data, slapyvardis, slaptazodis, tipas, grupes_id from [vartotojai] " +
                        "where slapyvardis=@slapyvardis";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@slapyvardis", username);
                conn.Open();


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string usrname = reader["slapyvardis"].ToString();
                        if (username == usrname)
                        {
                            throw new Exception("Vartotojas su tokiu slapyvardziu jau egzistuoja.");
                        }
                    }
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }


        public void UzregistruotiDestytoja(User user)
        {
            try
            {
                string sql = "insert into [vartotojai](vardas, pavarde, gimimo_data, slapyvardis, slaptazodis, tipas) " +
                    "values (@vardas, @pavarde, @gimimo_data, @slapyvardis, @slaptazodis, @tipas)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@vardas", user.GetName());
                cmd.Parameters.AddWithValue("@pavarde", user.GetSurname());
                cmd.Parameters.AddWithValue("@slapyvardis", user.GetUserName());
                cmd.Parameters.AddWithValue("@slaptazodis", user.GetPassword());
                cmd.Parameters.AddWithValue("@tipas", "Teacher");
                cmd.Parameters.AddWithValue("@gimimo_data", user.GetBirthdate());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }


        public void IstrintiDestytoja(string id)
        {
            try
            {
                string sql = "delete from [vartotojai] " +
                         "where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Destytojas istrintas.");
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


        public void UzregistruotiStudenta(User user)
        {
            try
            {
                string sql = "insert into [vartotojai](vardas, pavarde, gimimo_data, slapyvardis, slaptazodis, tipas, grupes_id) " +
                    "values (@vardas, @pavarde, @gimimo_data, @slapyvardis, @slaptazodis, @tipas, @grupes_id)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@vardas", user.GetName());
                cmd.Parameters.AddWithValue("@pavarde", user.GetSurname());
                cmd.Parameters.AddWithValue("@slapyvardis", user.GetUserName());
                cmd.Parameters.AddWithValue("@slaptazodis", user.GetPassword());
                cmd.Parameters.AddWithValue("@tipas", "Student");
                cmd.Parameters.AddWithValue("@gimimo_data", user.GetBirthdate());
                cmd.Parameters.AddWithValue("@grupes_id", user.GetGroupId());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public void IstrintiStudenta(string id)
        {
            try
            {
                string sql = "delete from [vartotojai] " +
                         "where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Studentas sekmingai pasalintas");
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

        public void PatikrintiStudenta(string id)
        {
            try
            {
                string sql = "select count(*) from [vartotojai] " +
                         "where id=@id and tipas='Student'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    throw new Exception("Toks studentas neegzistuoja");
                }

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


        public void PatikrintiDestytoja(string id)
        {
            try
            {
                string sql = "select count(*) from [vartotojai] " +
                         "where id=@id and tipas='Teacher'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    throw new Exception("Toks destytojas neegzistuoja");
                }
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