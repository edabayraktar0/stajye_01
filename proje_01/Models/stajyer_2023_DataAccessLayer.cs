using System.Data;
using System.Data.SqlClient;

namespace proje_01.Models
{
    public class stajyer_2023_DataAccessLayer
    {
        // adonet

        //connection - hangi veritabanı kullanacağımıza dair bağlantı kodumuz:
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=stajyer_2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        // kişilerin ayrıntılarını görüntülemek için
        public IEnumerable<kisi> GetAllEmployees()
        {
            List<kisi> lstkisi = new List<kisi>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    kisi kkisi = new kisi();

                    kkisi.kisi_id = Convert.ToInt32(rdr["kisi_id"]);
                    kkisi.ad_soyad = rdr[" Ad Soyad"].ToString();
                    kkisi.dogum_tarihi = DateTime.Parse(rdr["dogum tarihi"].ToString());
                    kkisi.yasadigi_il = Convert.ToInt32(rdr["yasadiği il"]);
                    kkisi.sinif_id = Convert.ToInt32(rdr["sınıf id"]);

                    lstkisi.Add(kkisi);
                }
                con.Close();
            }
            return lstkisi;
        }

        //yeni kişi eklemek için
        public void AddEmployee(kisi kkisi)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddkisi", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@kisi_id", kkisi.kisi_id);
                cmd.Parameters.AddWithValue("@ad_soyad", kkisi.ad_soyad);
                cmd.Parameters.AddWithValue("@dogum_tarihi", kkisi.dogum_tarihi);
                cmd.Parameters.AddWithValue("@yasadigi_il", kkisi.yasadigi_il);
                cmd.Parameters.AddWithValue("@sinif_id", kkisi.sinif_id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //kişilerin kaydını güncellemek için 
        public void UpdateEmployee(kisi kkisi)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@kisi_id", kkisi.kisi_id);
                cmd.Parameters.AddWithValue("@ad_soyad", kkisi.ad_soyad);
                cmd.Parameters.AddWithValue("@dogum_tarihi", kkisi.dogum_tarihi);
                cmd.Parameters.AddWithValue("@yasadigi_il", kkisi.yasadigi_il);
                cmd.Parameters.AddWithValue("@sinif_id", kkisi.sinif_id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //kişilerin ayrıntılarını al 
        public kisi GetkisiData(int? id)
        {
            kisi kkisi = new kisi();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM kisi WHERE kisi_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    kkisi.kisi_id = Convert.ToInt32(rdr["EmployeeID"]);
                    kkisi.ad_soyad = rdr["Name"].ToString();
                    kkisi.dogum_tarihi = kkisi.dogum_tarihi = DateTime.Parse(rdr["dogum tarihi"].ToString());
                    kkisi.yasadigi_il = Convert.ToInt32(rdr["EmployeeID"]);
                    kkisi.sinif_id = Convert.ToInt32(rdr["EmployeeID"]);
                }
            }
            return kkisi;
        }

        //kişilerin kaydını silmek için
        public void Deletekisi(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@kisi_id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //command


    }
}
