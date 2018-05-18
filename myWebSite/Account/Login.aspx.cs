using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using myWebSite;
using System.Data.SqlClient;

public partial class Account_Login : Page
{
    public int count = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Application["parameter"] = count;
    }

    protected void LogIn(object sender, EventArgs e)
    {
        try
        {
            if (IsValid)
            {
                //第二步：建立資料庫連線物件
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=192.192.155.111;" + "Initial Catalog=gichigo;" + "User id=zxc123;" + "Password=123;";
                SqlCommand cmdDataBase = new SqlCommand("Select * from store where store_id='" + UserName.Text + "' and store_password='" + Password.Text + "';", cn);
                SqlDataReader myReader;


                //第三步：開啟資料庫連線
                cn.Open();


                //★ 第四步：利用 OleDbCommand 執行 SQL 語法

                myReader = cmdDataBase.ExecuteReader();

                int count = 0;

                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    Application["parameter"] = count;
                    Application["user"] = UserName.Text;
                    Server.Transfer("Default.aspx");
                    //Response.Redirect("Default");
                }
                else
                {
                    Application["parameter"] = count;
                    FailureText.Text = "帳號或密碼錯誤。";
                    ErrorMessage.Visible = true;
                }
            }
        }
        catch
        {
            FailureText.Text = "網路連線狀況不穩，請稍後再試。";
            ErrorMessage.Visible = true;
        }
    }
}