using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerji_İş_Sendikası
{
    public partial class Articles : System.Web.UI.Page
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
        }
        protected void CikisYap_Click(object sender, EventArgs e)
        {
            
            Session.Clear();
            Session.Abandon();

            Response.Redirect("Anasayfa.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnaSayfa2.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articles.aspx");
        }

        protected void Profilim_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void MakaleYaz_Click(object sender, EventArgs e)
        {
            Response.Redirect("MakaleYaz.aspx");
        }
    }
}