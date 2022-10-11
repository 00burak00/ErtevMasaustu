using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ErtevMasaustu
{
    public class basvurCRUD
    {
        db Db = new db();
        public bool kaydet(basvur bsv)
        {
            bool cvp=true;
            int a;
            Db.ac();
            SqlCommand cmd = new SqlCommand("insert into Basvuru values (@a,@b,@c,@d,@e) ", Db.baglanti);
            cmd.Parameters.AddWithValue("@a", bsv.Ad);
            cmd.Parameters.AddWithValue("@b", bsv.Soyad);
            cmd.Parameters.AddWithValue("@c", bsv.Mail);
            cmd.Parameters.AddWithValue("@d", bsv.Tel);
            cmd.Parameters.AddWithValue("@e", DateTime.Now);
            a = cmd.ExecuteNonQuery();
            if (a == 0)
                return false;

            Db.kapat();
            return cvp;
        }
        public DataTable listeleme()
        {
            DataTable dt = new DataTable();
            Db.ac();
            SqlCommand cmd = new SqlCommand("select * from Basvuru",Db.baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            Db.kapat();
            return dt;
        }
        public bool sil(object prm)
        {

            bool cevap=true;
            int a;
            Db.ac();

            SqlCommand cmd = new SqlCommand("delete from Basvuru where tel=@tel ", Db.baglanti);
            cmd.Parameters.AddWithValue("@tel", prm);
            a= cmd.ExecuteNonQuery();
            if(a == 0)
                cevap=false;
            Db.kapat();
            return cevap;
        }
        public DataTable getir()
        {
           Db.ac();
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand("select* from Basvuru where bsvTarih = CONVERT(date, GETDATE()) ", Db.baglanti);
           
           SqlDataAdapter adp= new SqlDataAdapter(cmd);
            adp.Fill(dt);
            Db.kapat();
            return dt;
        }
        public DataTable getir(string a)
        {
            Db.ac();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select* from Basvuru where tel ="+a, Db.baglanti);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            Db.kapat();
            return dt;
        }
        public DataTable getirall()
        {
            Db.ac();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select* from Basvuru", Db.baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            Db.kapat();
            return dt;
        }
        public bool guncelle(basvur bsv)
        {
            bool cevap=true;
            int a;
            Db.ac();
            SqlCommand cmd = new SqlCommand("update Basvuru set Ad=@a, Soyad=@b, mail=@c where tel=@tel" , Db.baglanti);
            cmd.Parameters.AddWithValue("@a", bsv.Ad);
            cmd.Parameters.AddWithValue("@b", bsv.Soyad);
            cmd.Parameters.AddWithValue("@c", bsv.Mail);
            cmd.Parameters.AddWithValue("@tel", bsv.Tel);
            a = cmd.ExecuteNonQuery();
            if (a == 0)
                cevap = false;
            Db.kapat();

            return cevap;

        } 
    }
}