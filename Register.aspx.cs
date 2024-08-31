using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerji_İş_Sendikası
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sayfa yüklendiğinde Label1'i gizle
            Label1.Visible = false;
        }



        protected void btnKayitOl_Click(object sender, EventArgs e)
        {
            // Tüm giriş alanlarının dolu olup olmadığını ve e-posta ile telefon numarasının benzersiz olup olmadığını kontrol et
            if (!string.IsNullOrEmpty(txtIsim.Text) && !string.IsNullOrEmpty(txtSoyisim.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtSifre.Text))
            {
                // E-posta ve telefon numarasının benzersiz olup olmadığını kontrol et
                if (!EmailVeyaTelefonBenzersizMi(txtEmail.Text, txtTelefon.Text))
                {
                    // E-posta veya telefon numarası zaten kayıtlıysa hata mesajını göster
                    Label1.Text = "Girdiğiniz e-posta veya telefon numarası zaten kayıtlı!";
                    Label1.Visible = true;
                    return;
                }

                // Tüm alanlar doluysa kayıt işlemini gerçekleştir
                string connectionString = "Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True";
                string query = "INSERT INTO kullanicilar (kullanici_adi, kullanici_soyadi, kullanici_email, kullanici_sifre, kullanici_telefon) " +
                               "VALUES (@kullanici_adi, @kullanici_soyadi, @kullanici_email, @kullanici_sifre, @kullanici_telefon)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kullanici_adi", txtIsim.Text);
                        command.Parameters.AddWithValue("@kullanici_soyadi", txtSoyisim.Text);
                        command.Parameters.AddWithValue("@kullanici_email", txtEmail.Text);
                        command.Parameters.AddWithValue("@kullanici_sifre", txtSifre.Text);
                        command.Parameters.AddWithValue("@kullanici_telefon", txtTelefon.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // Başarılı kayıt mesajını göster
                Label1.Text = "Kayıt başarıyla tamamlandı!";
                Label1.Visible = true;

                // 2 saniye sonra Login.aspx sayfasına yönlendir
                Response.AddHeader("REFRESH", "2;URL=Login.aspx");
            }
            else
            {
                // Alanlardan biri veya birkaçı boşsa uyarı mesajı göster
                Label1.Text = "Lütfen tüm alanları doldurun!";
                Label1.Visible = true;
            }
        }

        // Veritabanında e-posta veya telefon numarasının zaten kayıtlı olup olmadığını kontrol eden fonksiyon
        private bool EmailVeyaTelefonBenzersizMi(string email, string telefon)
        {
            string connectionString = "Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM kullanicilar WHERE kullanici_email = @email OR kullanici_telefon = @telefon";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@telefon", telefon);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count == 0; // Eğer 0 ise e-posta veya telefon numarası benzersizdir
                }
            }
        }
    }
}