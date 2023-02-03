using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;


namespace proje_arsiv
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-Q6F1S5H;Initial Catalog=proje_arsiv;Integrated Security=True");
            baglanti.Open();
            return baglanti;
        }
    }
}
