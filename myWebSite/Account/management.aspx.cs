using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using myWebSite;
using System.Data.SqlClient;

public partial class Account_management : System.Web.UI.Page
{
    protected void Page_Load()
    {
        string user;
        Application.Lock();
        user = Application["user"].ToString();
        Application.UnLock();
        userlabel.Text = user;
    }

    protected void AddrChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source = 192.192.155.111; Initial Catalog = gichigo;User id = zxc123;Password = 123;");
        string sql = "update store set store_address = '" + DropDownList1.Text + Address.Text + "'where store_id = '" + userlabel.Text + "'";

        if (Address.Text == Addrconfirm.Text && DropDownList1.Text == DropDownList2.Text)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Response.Write("<Script language='Javascript'>");
                Response.Write("alert('更新成功')");
                Response.Write("</" + "Script>");
                Server.Transfer("Default.aspx");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Update Error:";
                msg += ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        else
        {
            Response.Write("<Script language='Javascript'>");
            Response.Write("alert('確認新地址與輸入之新地址不符!')");
            Response.Write("</" + "Script>");
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}