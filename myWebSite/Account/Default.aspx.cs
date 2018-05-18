using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string pm;
            Application.Lock();
            pm = Application["parameter"].ToString();
            Application.UnLock();

            if (pm == "0")
            {
                Response.Redirect("Login");
            }
        }
        catch
        {
            Response.Redirect("Login");
        }
    }
}