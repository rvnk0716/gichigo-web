using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using myWebSite;
using System.Data.SqlClient;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {

        if (IsValid)
        {
            //第二步：建立資料庫連線物件
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=192.192.155.111;" + "Initial Catalog=gichigo;" + "User id=zxc123;" + "Password=123;";
            SqlCommand cmdDataBase = new SqlCommand("Select * from store where store_id='" + UserName.Text + "'", cn);
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
                ErrorMessage.Text = "此使用者名稱已有人使用";
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source = 192.192.155.111; Initial Catalog = gichigo;User id = zxc123;Password = 123;");
                string sql = ("INSERT INTO [dbo].[store]([store_id],[store_name],[store_password],[store_tel],[store_address])VALUES('" + UserName.Text + "','" + StoreName.Text + "','" + Password.Text + "','" + Tel.Text + "','" + DropDownList1.Text + Address.Text + "')");
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Response.Write("<Script language='Javascript'>");
                Response.Write("alert('註冊成功，將重新引導回登入頁面')");
                Response.Write("</" + "Script>");
                Response.Redirect("Login");
            }
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Address_TextChanged(object sender, EventArgs e)
    {

    }
}