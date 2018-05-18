<%@ WebHandler Language="C#" Class="Getimg" %>

using System;

using System.Web;

using System.Data;

using System.Data.SqlClient;

using System.Configuration;
    using System.IO;

public class Getimg : IHttpHandler {

  public void ProcessRequest (HttpContext context) {  
        int id = int.Parse(context.Request.QueryString["id"]);  
        SqlConnection conn = new SqlConnection(@"Data Source=192.192.155.111;Initial Catalog=gichigo;User ID=zxc123;Password=123");  
        SqlCommand cmd = new SqlCommand("select product_picture from product where product_id='" + id + "'", conn);  
        cmd.Parameters.Add("@id",SqlDbType.Int).Value=id;  
        conn.Open();  
        SqlDataReader dr = cmd.ExecuteReader();  
        if (dr.Read())  
        {  
            context.Response.BinaryWrite((byte[])dr["product_picture"]);  
        }  
        dr.Close();  
    }  

    public bool IsReusable {
        get {
            return false;
        }
    }

}