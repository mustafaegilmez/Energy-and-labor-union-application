using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerji_İş_Sendikası
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                
                if (Session["KullaniciID"] == null)
                {
                   
                    Button2.Enabled = true;
                }
                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            if (Session["KullaniciID"] == null)
            {
               
                string script = "alert('Önce oturum açmalısınız.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", script, true);
            }


        }



        protected void KayitOl_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void GirisYap_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnaSayfa.aspx");
        }
    }
}