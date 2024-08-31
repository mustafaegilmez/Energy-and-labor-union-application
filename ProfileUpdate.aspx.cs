using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerji_İş_Sendikası
{
    public partial class ProfileUpdate : System.Web.UI.Page
    {
        private string kullanici_mail;
        string yeni_isim;
        string yeni_soyisim;
        string yeni_mail;
        string yeni_tel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                kullanici_mail = Session["UserId"] as string;
            }
            else
            {
                Response.Redirect("AnaSayfa.aspx");
            }

            ilkGosterim();


        }
        protected void update(string isim, string soy, string mail, string tel)
        {
            string connectionString = "Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True";

            string query = "UPDATE kullanicilar SET kullanici_adi = @isim, kullanici_soyadi = @soy, kullanici_telefon = @tel,kullanici_email=@mail WHERE kullanici_email = @mail";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@isim", isim);
                    cmd.Parameters.AddWithValue("@soy", soy);
                    cmd.Parameters.AddWithValue("@tel", tel);
                    cmd.Parameters.AddWithValue("@mail", mail);

                    int sonuc = cmd.ExecuteNonQuery();

                    if (sonuc > 0)
                    {

                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Profil başarıyla güncellendi');", true);
                        Response.AppendHeader("Refresh", "1;url=Profile.aspx"); 
                        Mesaj.Text = "Güncelleme başarıyla gerçekleşti.";
                    }
                    else
                    {
                    }

                }

            }

        }
        protected void ilkGosterim()
        {
            string connectionString = "Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True";

            string isim = null;
            string soyisim = null;
            string mail = null;
            string telefon = null;

            string query = "SELECT * FROM kullanicilar WHERE kullanici_email=@kullanici_mail";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@kullanici_mail", kullanici_mail);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Veritabanından gelen verileri al
                            isim = reader["kullanici_adi"].ToString();
                            soyisim = reader["kullanici_soyadi"].ToString();
                            mail = reader["kullanici_email"].ToString();
                            if (reader["kullanici_telefon"] != null)
                            {
                                telefon = reader["kullanici_telefon"].ToString();
                            }
                            else
                            {
                                telefon = "0";
                            }
                        }
                    }

                    lbl_isim.Text = isim;
                    lbl_soy.Text = soyisim;
                    lbl_mail.Text = mail;
                    lbl_tel.Text = telefon;
                }
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnaSayfa2.aspx");
        }

        protected void Onayla_Click(object sender, EventArgs e)
        {
            yeni_isim = isim.Text;
            yeni_soyisim = soy.Text;
            yeni_mail = mail.Text;
            yeni_tel = tel.Text;

            if (!string.IsNullOrEmpty(yeni_isim) && !string.IsNullOrEmpty(yeni_soyisim) && !string.IsNullOrEmpty(yeni_mail))
            {
                update(yeni_isim, yeni_soyisim, yeni_mail, yeni_tel);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('BOŞ ');", true);
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articles.aspx");
        }

        protected void Profilim_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void CikisYap_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnaSayfa.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            yeni_isim = isim.Text.ToString();

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            yeni_soyisim = soy.Text.ToString();
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            yeni_mail = mail.Text.ToString();

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            yeni_tel = tel.Text;
        }
    }
}