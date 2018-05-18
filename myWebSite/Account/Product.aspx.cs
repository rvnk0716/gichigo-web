using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Product : System.Web.UI.Page
{
    String address;
    String add;
    protected void sqlfunc()
    {
        string user;
        Application.Lock();
        user = Application["user"].ToString();
        Application.UnLock();

        SqlDataSource SqlDataSource1 = new SqlDataSource();
        SqlDataSource1.ConnectionString = "Data Source=192.192.155.111;" + "Initial Catalog=gichigo;" + "User id=zxc123;" + "Password=123;";
        GridView1.DataSource = SqlDataSource1;

        SqlDataSource1.SelectCommand = "SELECT product_id,product_name,product_picture,product_quality,product_date,product_price,product_class FROM product WHERE product_store = '" + user + "'";
        SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataSet;

        DataSourceSelectArguments args = new DataSourceSelectArguments();
        DataView dv = (DataView)SqlDataSource1.Select(args);

        GridView1.DataSource = dv;

        GridView1.DataBind();

        SqlDataSource1.Dispose();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        string user;
        Application.Lock();
        user = Application["user"].ToString();
        Application.UnLock();

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source=192.192.155.111;" + "Initial Catalog=gichigo;" + "User id=zxc123;" + "Password=123;";
        SqlCommand myCommand = new SqlCommand("SELECT store_address FROM store WHERE store_id='" + user + "'", conn);
        conn.Open();
        SqlDataReader dr = myCommand.ExecuteReader();

        if (dr.Read())
        {
            address = dr[0].ToString();
        }
       
        conn.Close();

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
                sqlfunc();
            }
        }
        catch
        {
            Response.Redirect("Login");
        }


    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string user;
        Application.Lock();
        user = Application["user"].ToString();
        Application.UnLock();

        string name = FileUpload1.PostedFile.FileName;

        string type = name.Substring(name.LastIndexOf(".") + 1);

        Stream fs = FileUpload1.PostedFile.InputStream;

        byte[] content = new byte[FileUpload1.PostedFile.ContentLength];

        fs.Read(content, 0, content.Length);

        collAttachments.Add(name, content);

        fs.Close();

        SqlConnection conn = new SqlConnection("Data Source = 192.192.155.111; Initial Catalog = gichigo;User id = zxc123;Password = 123;");
        string sql = "INSERT INTO product(product_name,product_picture,product_quality,product_date,product_price,product_store,product_class)VALUES('" + TextBox1.Text + "'," + "@content" + ",'" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + user + "','" + DropDownList1.Text + "')";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;


            if (type == "jpg" || type == "gif" || type == "bmp" || type == "png")

            {
                SqlParameter para = cmd.Parameters.Add("@content", SqlDbType.Image);

                para.Value = content;

            }
            cmd.ExecuteNonQuery();
            sqlfunc();
            Response.Write("<Script language='Javascript'>");
            Response.Write("alert('新增成功')");
            Response.Write("</" + "Script>");
            Label1.Text = "";
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownList1.Text = "";
            SendPushNotification();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source = 192.192.155.111; Initial Catalog = gichigo;User id = zxc123;Password = 123;");
        string sql = "DELETE FROM product WHERE product_id='" + Label1.Text + "'";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sqlfunc();
            Response.Write("<Script language='Javascript'>");
            Response.Write("alert('刪除成功')");
            Response.Write("</" + "Script>");

            Label1.Text = "";
            TextBox1.Text = "";        
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownList1.SelectedIndex = 0;
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

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBox4.Text = Calendar1.SelectedDate.ToShortDateString();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        Label1.Text = row.Cells[1].Text;
        TextBox1.Text = row.Cells[3].Text;

        TextBox3.Text = row.Cells[4].Text;
        TextBox4.Text = row.Cells[5].Text;
        TextBox5.Text = row.Cells[6].Text;
        DropDownList1.SelectedValue = row.Cells[7].Text.Trim();
        Application["pname"] = TextBox1.Text;
        Image2.ImageUrl = "allimage.aspx";
       
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source = 192.192.155.111; Initial Catalog = gichigo;User id = zxc123;Password = 123;");
        string sql = "update product set product_name = '" + TextBox1.Text + "',product_quality = '" + TextBox3.Text + "',product_date = '" + TextBox4.Text + "',product_price = '" + TextBox5.Text + "',product_class = '" + DropDownList1.Text + "' where product_id = '" + Label1.Text + "'";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sqlfunc();
            Response.Write("<Script language='Javascript'>");
            Response.Write("alert('修改成功')");
            Response.Write("</" + "Script>");

            Label1.Text = "";
            TextBox1.Text = "";         
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownList1.SelectedIndex = 0;

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
    public void SendPushNotification()
    {
        
        try
        {
            //伺服器
            string applicationID = "AAAAiCpDVHA:APA91bEK980zYf-R3jVXIgaIntUCoE3FqSg-cutCWWX0vzQbNd6MU11-2w_zZGVKuJ0haTxwL-hVEJIoGMNwekNm_74BKwvX3OiuL9vdPatvIEx_m_i6HC9MmvByqLRgj_PaBvTwKtIc";

            string senderId = "584824607856";

            string deviceId = "";
            if (address.Contains("新北市"))
            {
                 deviceId = "/topics/newtaipei";
                add = "新北市";
            }
            else if (address.Contains("台北市"))
            {
                deviceId = "/topics/Taipei";
                add = "台北市";
            }
            else if (address.Contains("桃園市"))
            {
                deviceId = "/topics/Taoyuan";
                add = "桃園市";
            }
            else if (address.Contains("台中市"))
            {
                deviceId = "/topics/Taichung";
                add = "台中市";
            }
            else if (address.Contains("高雄市"))
            {
                deviceId = "/topics/Kaohsiung";
                add = "高雄市";
            }
            //string deviceId = "手機的TOKEN";


            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            var data = new
            {
                to = deviceId,
                notification = new
                {



                    body = add.ToString() + "有新商品",
                    title = "即期go",
                    sound = "Enabled"

                }
            };
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(data);
            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            string str = sResponseFromServer;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }

    }
}