<%@ Page Title="管理帳戶" Language="C#" MasterPageFile="~/mySite.master" AutoEventWireup="true" CodeFile="management.aspx.cs" Inherits="Account_management" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="manageForm">
                <div class="form-horizontal">
                    <h4>使用者:<asp:Label ID="userlabel" runat="server" Text="Label"></asp:Label>
                    </h4>    
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label">輸入新地址</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Text ="請選擇縣市" Value="-1"></asp:ListItem>
                    <asp:ListItem Text ="臺北市" Value="臺北市"></asp:ListItem>
                    <asp:ListItem Text ="新北市" Value="新北市"></asp:ListItem>
                    <asp:ListItem Text ="臺中市" Value="臺中市"></asp:ListItem>
                    <asp:ListItem Text ="臺南市" Value="臺南市"></asp:ListItem>
                    <asp:ListItem Text ="高雄市" Value="高雄市"></asp:ListItem>
                    <asp:ListItem Value="桃園市">桃園市</asp:ListItem>
                    <asp:ListItem Text ="基隆市" Value="基隆市"></asp:ListItem>
                    <asp:ListItem Text ="新竹市" Value="新竹市"></asp:ListItem>
                    <asp:ListItem Text ="嘉義市" Value="嘉義市"></asp:ListItem>
                    <asp:ListItem>新竹縣</asp:ListItem>
                    <asp:ListItem>苗栗縣</asp:ListItem>
                    <asp:ListItem>彰化縣</asp:ListItem>
                    <asp:ListItem>南投縣</asp:ListItem>
                    <asp:ListItem>雲林縣</asp:ListItem>
                    <asp:ListItem>嘉義縣</asp:ListItem>
                    <asp:ListItem>屏東縣</asp:ListItem>
                    <asp:ListItem>宜蘭縣</asp:ListItem>
                    <asp:ListItem>花蓮縣</asp:ListItem>
                    <asp:ListItem>臺東縣</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox runat="server" ID="Address" CssClass="form-control" Width="385px" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Address"
                                CssClass="text-danger" ErrorMessage="必須填寫地址欄位。" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Addrconfirm" CssClass="col-md-2 control-label">確認新地址</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem Text ="請選擇縣市" Value="-1"></asp:ListItem>
                    <asp:ListItem Text ="臺北市" Value="臺北市"></asp:ListItem>
                    <asp:ListItem Text ="新北市" Value="新北市"></asp:ListItem>
                    <asp:ListItem Text ="臺中市" Value="臺中市"></asp:ListItem>
                    <asp:ListItem Text ="臺南市" Value="臺南市"></asp:ListItem>
                    <asp:ListItem Text ="高雄市" Value="高雄市"></asp:ListItem>
                    <asp:ListItem Value="桃園市">桃園市</asp:ListItem>
                    <asp:ListItem Text ="基隆市" Value="基隆市"></asp:ListItem>
                    <asp:ListItem Text ="新竹市" Value="新竹市"></asp:ListItem>
                    <asp:ListItem Text ="嘉義市" Value="嘉義市"></asp:ListItem>
                    <asp:ListItem>新竹縣</asp:ListItem>
                    <asp:ListItem>苗栗縣</asp:ListItem>
                    <asp:ListItem>彰化縣</asp:ListItem>
                    <asp:ListItem>南投縣</asp:ListItem>
                    <asp:ListItem>雲林縣</asp:ListItem>
                    <asp:ListItem>嘉義縣</asp:ListItem>
                    <asp:ListItem>屏東縣</asp:ListItem>
                    <asp:ListItem>宜蘭縣</asp:ListItem>
                    <asp:ListItem>花蓮縣</asp:ListItem>
                    <asp:ListItem>臺東縣</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox runat="server" ID="Addrconfirm" CssClass="form-control" Width="385px" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Addrconfirm" CssClass="text-danger" ErrorMessage="必須填寫地址欄位。" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="AddrChanged" Text="確定" CssClass="btn btn-default" />
                        </div>
                    </div>
                 </div>
              </section>
            </div>
        </div>
</asp:Content>
