using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerji_İş_Sendikası
{
    public partial class Admin : System.Web.UI.Page
    {
        private string kullanici_mail;
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
            kontrol();
        }

        protected void kontrol()
        {
            string queryString = "SELECT COUNT(*) FROM bekleyen_paylasim";

            using (SqlConnection connection = new SqlConnection("Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    int rowCount = (int)command.ExecuteScalar();

                    if (rowCount == 0)
                    {
                       
                        lblMessage.Text = "Bekleyen Paylaşım Bulunmamaktadır.";
                    }
                    else
                    {
                        
                       
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows) 
            {
           
             
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");

                if (chk.Checked)
                {
                 
                    int paylasimlar_id = Convert.ToInt32(row.Cells[2].Text);
                    int kullanici_id = Convert.ToInt32(row.Cells[1].Text);

                  
                    string queryString = "INSERT INTO kabul_edilen_paylasim ( kullanici_id,paylasimlar_id) VALUES (@kullanici_id,@paylasimlar_id )";

                 
                    using (SqlConnection connection = new SqlConnection("Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True")) 
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                      
                        command.Parameters.AddWithValue("@paylasimlar_id", paylasimlar_id);
                        command.Parameters.AddWithValue("@kullanici_id", kullanici_id);

                       
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                    string deleteQueryString = "DELETE FROM bekleyen_paylasim WHERE paylasimlar_id = @paylasimlar_id AND kullanici_id = @kullanici_id";


                    using (SqlConnection connection = new SqlConnection("Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True"))
                    {
                        SqlCommand deleteCommand = new SqlCommand(deleteQueryString, connection);

                        deleteCommand.Parameters.AddWithValue("@paylasimlar_id", paylasimlar_id);
                        deleteCommand.Parameters.AddWithValue("@kullanici_id", kullanici_id);


                        try
                        {
                            connection.Open();
                            deleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            
            GridView1.DataBind();
            kontrol();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
            
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");

               
                if (chk.Checked)
                {
                 
                    int paylasimlar_id = Convert.ToInt32(row.Cells[2].Text);
                    int kullanici_id = Convert.ToInt32(row.Cells[1].Text);

                    string queryString = "INSERT INTO kabul_edilmeyen_paylasim ( kullanici_id,paylasimlar_id) VALUES (@kullanici_id,@paylasimlar_id )";


                    using (SqlConnection connection = new SqlConnection("Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True"))
                    {
                        SqlCommand command = new SqlCommand(queryString, connection);
                       
                        command.Parameters.AddWithValue("@paylasimlar_id", paylasimlar_id);
                        command.Parameters.AddWithValue("@kullanici_id", kullanici_id);

                        
                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }

                    
                    string deleteQueryString = "DELETE FROM bekleyen_paylasim WHERE paylasimlar_id = @paylasimlar_id AND kullanici_id = @kullanici_id";


                    using (SqlConnection connection = new SqlConnection("Data Source=MUSTAFALAPTOP;Initial Catalog=sendika;Integrated Security=True"))
                    {
                        SqlCommand deleteCommand = new SqlCommand(deleteQueryString, connection);
                       
                        deleteCommand.Parameters.AddWithValue("@paylasimlar_id", paylasimlar_id);
                        deleteCommand.Parameters.AddWithValue("@kullanici_id", kullanici_id);

                       
                        try
                        {
                            connection.Open();
                            deleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                }
            }
            
            GridView1.DataBind();
            kontrol();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

        protected void exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("raporalma.aspx"); 
        }
    }
}