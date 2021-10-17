using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekt
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("https://localhost:44386/");
                }
            }
        }

        protected void rblNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblNumber.SelectedIndex == 0)
            {
                gvKupci.PageSize = 10;
            }  
            else if(rblNumber.SelectedIndex == 1)
            {
                gvKupci.PageSize = 25;
            }
            else if(rblNumber.SelectedIndex == 2)
            {
                gvKupci.PageSize = 50;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44386/");
        }
    }
}