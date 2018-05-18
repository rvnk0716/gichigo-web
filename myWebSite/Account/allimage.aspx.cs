using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class allimage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string pname;
        Application.Lock();
        pname = Application["pname"].ToString();
        Application.UnLock();

        SqlConnection conn1 = new SqlConnection(@"Data Source = 192.192.155.111; Initial Catalog = gichigo; User ID = zxc123; Password = 123");

        SqlCommand cmd1 = new SqlCommand("select product_picture from product where product_name = '" + pname + "'", conn1); //固定顯示Image_ID為3的圖片

        conn1.Open();

        SqlDataReader sdr = cmd1.ExecuteReader();

        if (sdr.Read())

        {

            Response.BinaryWrite((byte[])sdr["product_picture"]);

        }

        Response.End();

    }
}