<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Account_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="請輸入買家帳號："></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="確定" OnClick="Button1_Click" />
    <br />
    <asp:Label ID="Label2" runat="server" CssClass="text-danger" Text="※如要查看所有訂單，請將輸入欄清空，再按下確定即可"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="訂購數量：" Visible="False"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="修改" Visible="False" />
    <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label5" runat="server" Text="總金額：" Visible="False"></asp:Label>
    <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="完成訂單" Visible="False" />
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="取消訂單" Visible="False" />
</asp:Content>

