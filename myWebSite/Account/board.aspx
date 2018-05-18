<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.master" AutoEventWireup="true" CodeFile="board.aspx.cs" Inherits="Account_board" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server" >
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField SelectText="回覆" ShowSelectButton="True" />  
              <asp:BoundField HeaderText="商品名稱" DataField="product_name" ItemStyle-Width="100px">
<ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="留言者" DataField="board_user_id" ItemStyle-Width="100px" >
<ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="留言" DataField="board_user_message" ItemStyle-Width="100px">
<ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="留言時間" DataField="time" ItemStyle-Width="100px">
<ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="我的留言" DataField="board_store_message" ItemStyle-Width="100px">
<ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>

            <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
            <asp:HiddenField runat="server" ID="HiddenField1" Value='<%#Eval("fcmid")%>'></asp:HiddenField>
            <asp:Label runat="server" ID="Label2" Text ='<%#Eval("product_name")%>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
        <asp:Label ID="Label5" runat="server" CssClass="h3" Text="回覆:" Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Visible="False" Width="625px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" OnClick="Button1_Click" Text="確定" Visible="False" />

    </h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
</asp:Content>

