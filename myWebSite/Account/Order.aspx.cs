using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Order : System.Web.UI.Page
{
    protected void ofunc()
    {
        string user;
        Application.Lock();
        user = Application["user"].ToString();
        Application.UnLock();

        SqlDataSource SqlDataSource1 = new SqlDataSource();
        SqlDataSource1.ConnectionString = "Data Source=192.192.155.111;" + "Initial Catalog=gichigo;" + "User id=zxc123;" + "Password=123;";
        GridView1.DataSource = SqlDataSource1;

        SqlDataSource1.SelectCommand = "SELECT ordernum as 訂單編號,owner as 買家帳號,order_quality as 訂購數量,product_name as 商品名稱,total_price as 總金額,product_id as 商品編號 FROM order2 WHERE product_store = '" + user + "'";
        SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataSet;

        DataSourceSelectArguments args = new DataSourceSelectArguments();
        DataView dv = (DataView)SqlDataSource1.Select(args);

        GridView1.DataSource = dv;

        GridView1.DataBind();

        SqlDataSource1.Dispose();

    }
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
            else
            {
                ofunc();
            }
        }
        catch
        {
            Response.Redirect("Login");
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string user;
        Application.Lock();
        user = Application["user"].ToString();
        Application.UnLock();

        SqlDataSource SqlDataSource1 = new SqlDataSource();
        SqlDataSource1.ConnectionString = "Data Source=192.192.155.111;" + "Initial Catalog=gichigo;" + "User id=zxc123;" + "Password=123;";
        GridView1.DataSource = SqlDataSource1;

        if(TextBox1.Text == "")
        {
            SqlDataSource1.SelectCommand = "SELECT ordernum as 訂單編號,owner as 買家帳號,order_quality as 訂購數量,product_name as 商品名稱,total_price as 總金額,product_id as 商品編號 FROM order2 WHERE product_store = '" + user + "'";
        }
        else
        {
            SqlDataSource1.SelectCommand = "SELECT ordernum as 訂單編號,owner as 買家帳號,order_quality as 訂購數量,product_name as 商品名稱,total_price as 總金額,product_id as 商品編號 FROM order2 WHERE product_store = '" + user + "' and owner = '" + TextBox1.Text + "'";
        }
        SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataSet;

        DataSourceSelectArguments args = new DataSourceSelectArguments();
        DataView dv = (DataView)SqlDataSource1.Select(args);

        GridView1.DataSource = dv;

        GridView1.DataBind();

        SqlDataSource1.Dispose();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label3.Visible = true;
        TextBox2.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;
        Label7.Visible = true;
        Button2.Visible = true;
        Button3.Visible = true;
        Button4.Visible = true;
        GridViewRow row = GridView1.SelectedRow;
        Label3.Text = "訂單編號：" + row.Cells[1].Text + "<br>" + "買家帳號：" + row.Cells[2].Text + "<br>" + "商品名稱：" + row.Cells[4].Text;
        TextBox2.Text = row.Cells[3].Text;
        Label6.Text = row.Cells[1].Text;
        Label7.Text = row.Cells[5].Text;
        Label8.Text = row.Cells[3].Text;
        Label9.Text = row.Cells[6].Text;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int newqua = int.Parse(TextBox2.Text);
        int quality = int.Parse(Label8.Text);
        int total = int.Parse(Label7.Text);
        int update = total / quality * newqua;
        SqlConnection conn = new SqlConnection("Data Source = 192.192.155.111; Initial Catalog = gichigo;User id = zxc123;Password = 123;");
        string sql = "update order2 set order_quality = '" + TextBox2.Text + "',total_price = '" + update + "' where ordernum = '" + Label6.Text + "'";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            ofunc();
            Response.Write("<Script language='Javascript'>");
            Response.Write("alert('修改成功')");
            Response.Write("</" + "Script>");

            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;

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

    protected void Button3_Click(object sender, EventArgs e)
    {
        string aaa = "";
        int newqua = int.Parse(TextBox2.Text);
        SqlConnection conn = new SqlConnection("Data Source = 192.192.155.111; Initial Catalog = gichigo;User id = zxc123;Password = 123;");
        SqlCommand myCommand = new SqlCommand("SELECT product_quality FROM product WHERE product_id='" + Label9.Text + "'", conn);
        conn.Open();
        SqlDataReader dr = myCommand.ExecuteReader();

        if (dr.Read())
        {
           aaa = dr[0].ToString();
        }
        conn.Close();
        int upqua = int.Parse(aaa);
        int fqua = upqua - newqua;
        string sql = "DELETE FROM order2 WHERE ordernum = '" + Label6.Text + "'";
        string productupdate = "update product set product_quality = '" + fqua + "' where product_id = '" + Label9.Text + "'";
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlCommand cmd2 = new SqlCommand(productupdate, conn);
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            ofunc();
            Response.Write("<Script language='Javascript'>");
            Response.Write("alert('交易完成')");
            Response.Write("</" + "Script>");

            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Delete Error:";
            msg += ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source = 192.192.155.111; Initial Catalog = gichigo;User id = zxc123;Password = 123;");
        string sql = "DELETE FROM order2 WHERE ordernum = '" + Label6.Text + "'";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            ofunc();
            Response.Write("<Script language='Javascript'>");
            Response.Write("alert('已將此筆訂單取消')");
            Response.Write("</" + "Script>");

            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Delete Error:";
            msg += ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }
}