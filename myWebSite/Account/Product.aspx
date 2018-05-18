<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Account_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
	<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" HorizontalAlign="Right">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
         
         <Columns>
             <asp:CommandField ShowSelectButton="True" />
               
              <asp:BoundField HeaderText="商品編號" DataField="product_id" ItemStyle-Width="100px" />
               
            <asp:TemplateField HeaderText="商品圖片" ItemStyle-Width="130px" >
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%#"Getimg.ashx?id="+Eval("product_id") %>'   Width="100px"  Height="100px" /> 
            </ItemTemplate>
        </asp:TemplateField>
               
           <asp:BoundField HeaderText="商品名稱" DataField="product_name" ItemStyle-Width="130px" >
             </asp:BoundField>
           <asp:BoundField HeaderText="商品數量" DataField="product_quality" ItemStyle-Width="100px">
             </asp:BoundField>
               <asp:BoundField HeaderText="商品期限" DataField="product_date" ItemStyle-Width="200px">
             </asp:BoundField>
               <asp:BoundField HeaderText="商品價格" DataField="product_price" ItemStyle-Width="100px">
             </asp:BoundField>
               <asp:BoundField HeaderText="商品類別" DataField="product_class" ItemStyle-Width="100px">
             </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <h2>商品名稱&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        </h2>
    <p>

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    </p>
     <h2>商品圖片<asp:Image ID="Image2" runat="server" Width="100px"  Height="100px" />  </h2>
   
   
        <asp:FileUpload ID="FileUpload1" runat="server" Width="176px" />
 
    <p>

        &nbsp;</p>
    <h2>商品數量</h2>
    <p>

        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

    </p>
    <h2>商品到期日</h2>
    <p>

        <asp:Calendar ID="Calendar1" runat="server" Height="16px" Width="242px" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>

        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

    </p>
    <h2>商品價格</h2>
    <p>

        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>

    </p>
        <h2>商品種類</h2>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>飲料類</asp:ListItem>
            <asp:ListItem>食品類</asp:ListItem>
            <asp:ListItem>糕點類</asp:ListItem>
            <asp:ListItem>美妝類</asp:ListItem>
            <asp:ListItem>居家用品類</asp:ListItem>
            <asp:ListItem>娛樂類</asp:ListItem>
            <asp:ListItem>禮品類</asp:ListItem>
            <asp:ListItem>其他</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownList1"
                                CssClass="text-danger" ErrorMessage="請選擇種類。" />
    </p>
    <p>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="新增" />
        <asp:Button ID="Button2" runat="server" Text="刪除" OnClick="Button2_Click" OnClientClick="return confirm(&quot;確定刪除?&quot;);" />
        <asp:Button ID="Button3" runat="server" Text="修改" OnClick="Button3_Click" Width="47px" />

    </p>
</asp:Content>

