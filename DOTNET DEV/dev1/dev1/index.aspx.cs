using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dev1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Button1.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button2.Visible = false;
            Panel1.Visible = false;
            Button1.Visible = true;
            Panel2.Visible = true;
        }
    }
}