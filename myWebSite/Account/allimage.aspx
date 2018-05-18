<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.master" AutoEventWireup="true" CodeFile="allimage.aspx.cs" Inherits="allimage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">

      <asp:GridView ID="MyDataGrid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
           <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
  <Columns>
       <asp:TemplateField>
  <HeaderTemplate>product_picture</HeaderTemplate>
    <ItemTemplate>  <asp:Image ID="Image1" runat="server" Height="70px" ImageUrl='<%# "Getimg.ashx?id="+Eval("product_id") %>'  
        Width="100px" />  
</ItemTemplate>   
   </asp:TemplateField>

</Columns>

 </asp:GridView>

  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=192.192.155.111;Initial Catalog=gichigo;User ID=zxc123;Password=123" 
      SelectCommand="SELECT * FROM [product]"></asp:SqlDataSource>

      

</asp:Content>
