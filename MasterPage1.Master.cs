using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enerji_İş_Sendikası
{
  
    public partial class MasterPage1 : System.Web.UI.MasterPage
    {
        private string kullanici_mail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || string.IsNullOrEmpty(Session["UserId"] as string))
            {
            
                Response.Write("<script>alert('Önce giriş yapmalısınız.'); setTimeout(function(){window.location.href='AnaSayfa.aspx';}, 0.01);</script>");
            }
            else
            {
                kullanici_mail = Session["UserId"] as string;
            }
        }



        protected void Profilim_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void CikisYap_Click(object sender, EventArgs e)
        {
            
            Session.Clear();
            Session.Abandon();

            
            Response.Redirect("Anasayfa.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

           
            Response.Redirect("Articles.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnaSayfa2.aspx");
        }
    }
}