using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ErtevMasaustu
{
    public class db
    {
        public SqlConnection baglanti = new SqlConnection("workstation id=BasvuruErtev.mssql.somee.com;packet size=4096;user id=burak-07_SQLLogin_1;pwd=fb8ulbzpbu;data source=BasvuruErtev.mssql.somee.com;persist security info=False;initial catalog=BasvuruErtev");
        public void ac()
        {
            baglanti.Open();
        }
        public void kapat()
        {
            baglanti.Close();
        }
    }
}