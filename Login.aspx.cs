using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerji_İş_Sendikası
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string email = TextBox1.Text;
            string password = TextBox2.Text;

           
            string connectionString = "Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True";

           
            string query = "SELECT COUNT(*) FROM kullanicilar WHERE kullanici_email = @kullanici_email AND kullanici_sifre = @kullanici_sifre";

           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@kullanici_email", email);
                    command.Parameters.AddWithValue("@kullanici_sifre", password);

                   
                    connection.Open();

                    
                    int result = (int)command.ExecuteScalar();

                   
                    if (result > 0)
                    {
                        
                        Session["UserId"] = email;

                        
                        Response.Redirect("Anasayfa2.aspx");
                    }
                    else
                    {
                        
                        Label3.Visible = true;
                        Label3.Text = "E-posta veya parola hatalı. Kayıtlı değilseniz kayıt olun :)";
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string email = TextBox1.Text;
            string password = TextBox2.Text;


            string connectionString = "Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True";


            string query = "SELECT COUNT(*) FROM admin WHERE admin_email = @admin_email AND admin_sifre = @admin_sifre";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@admin_email", email);
                    command.Parameters.AddWithValue("@admin_sifre", password);


                    connection.Open();


                    int result = (int)command.ExecuteScalar();


                    if (result > 0)
                    {

                        Session["UserId"] = email;


                        Response.Redirect("Admin.aspx");
                    }
                    else
                    {

                        Label3.Visible = true;
                        Label3.Text = "E-posta veya parola hatalı. Kayıtlı değilseniz kayıt olun :)";
                    }
                }
            }
        }
    }
}