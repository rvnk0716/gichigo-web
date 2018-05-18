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

public partial class Account_board : System.Web.UI.Page
{
    String fcmid;
    protected void bfunc()
    {
        string user;
        Application.Lock();
        user = Application["user"].ToString();
        Application.UnLock();

        SqlDataSource SqlDataSource1 = new SqlDataSource();
        SqlDataSource1.ConnectionString = "Data Source=192.192.155.111;" + "Initial Catalog=gichigo;" + "User id=zxc123;" + "Password=123;";
        GridView1.DataSource = SqlDataSource1;

        SqlDataSource1.SelectCommand = "SELECT product_name ,board_user_id,board_user_message,time,board_store_message,fcmid FROM board WHERE board_store_id = '" + user + "'";
        SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataSet;

        DataSourceSelectArguments args = new DataSourceSelectArguments();
        DataView dv = (DataView)SqlDataSource1.Select(args);

        GridView1.DataSource = dv;

        GridView1.DataBind();
        GridView1.Columns[6].Visible = false;
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
                Response.Redirect("Login");
            else
                bfunc();
           
        }
        catch
        {
            Response.Redirect("Login");
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
       // TextBox1.Text = row.Cells[2].Text.Trim() + ":";
        Label1.Text = row.Cells[1].Text.Trim();
        Label2.Text = row.Cells[2].Text.Trim();
        Label3.Text = row.Cells[3].Text.Trim();
        Label4.Text = row.Cells[4].Text.Trim();

        Label6.Text = ((HiddenField)GridView1.SelectedRow.Cells[1].FindControl("HiddenField1")).Value;


        Label5.Visible = true;
        TextBox1.Visible = true;
        Button1.Visible = true;

        

    }
    public void SendPushNotification()
    {

        try
        {
            //伺服器
            string applicationID = "AAAAiCpDVHA:APA91bEK980zYf-R3jVXIgaIntUCoE3FqSg-cutCWWX0vzQbNd6MU11-2w_zZGVKuJ0haTxwL-hVEJIoGMNwekNm_74BKwvX3OiuL9vdPatvIEx_m_i6HC9MmvByqLRgj_PaBvTwKtIc";

            string senderId = "584824607856";


            //string deviceId = "手機的TOKEN";
            string deviceId = Label6.Text;


            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            var data = new
            {
                to = deviceId,
                notification = new
                {
                    body = "你在【"+Label1.Text+"】有新留言",
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source = 192.192.155.111; Initial Catalog = gichigo;User id = zxc123;Password = 123;");
        string sql = "update board set board_store_message = '" + TextBox1.Text + "'where product_name = '" + Label1.Text + "'and board_user_id = '" + Label2.Text + "'and board_user_message = '" + Label3.Text + "'and time = '" + Label4.Text + "'";

        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            bfunc();
            Response.Write("<Script language='Javascript'>");
            Response.Write("alert('回覆成功')");
            Response.Write("</" + "Script>");
            SendPushNotification();
            Label5.Visible = false;
            TextBox1.Visible = false;
            Button1.Visible = false;
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
   
}