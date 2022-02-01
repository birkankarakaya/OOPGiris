using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Bilgi", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["Id"].ToString());
                ent.Ad = dr["Ad"].ToString();
                ent.Soyad = dr["Soyad"].ToString();
                ent.Gorev = dr["Gorev"].ToString();
                ent.Sehir = dr["Sehir"].ToString();
                ent.Maas = short.Parse(dr["Maas"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }



        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut1 = new SqlCommand("INSERT INTO Tbl_Bilgi (Ad,Soyad,Gorev,Sehir,Maas) VALUES (@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@p1", p.Ad);
            komut1.Parameters.AddWithValue("@p2", p.Soyad);
            komut1.Parameters.AddWithValue("@p3", p.Gorev);
            komut1.Parameters.AddWithValue("@p4", p.Sehir);
            komut1.Parameters.AddWithValue("@p5", p.Maas);
            return komut1.ExecuteNonQuery();
        }



        public static bool PersonelSil(int p)
        {
            SqlCommand komut2 = new SqlCommand("DELETE FROM Tbl_Bilgi WHERE ID=@p1", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", p);
            return true;
        }


        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand komut3 = new SqlCommand("Update Tbl_Bilgi SET Ad=@p1,Soyad=@p2,Maas=@p3,Sehir=@p4,Gorev=@p5 WHERE ID=@p6", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", ent.Ad);
            komut3.Parameters.AddWithValue("@p2", ent.Soyad);
            komut3.Parameters.AddWithValue("@p3", ent.Maas);
            komut3.Parameters.AddWithValue("@p4", ent.Sehir);
            komut3.Parameters.AddWithValue("@p5", ent.Gorev);
            komut3.Parameters.AddWithValue("@p6", ent.Id);
            return true;
        }
    }
}
