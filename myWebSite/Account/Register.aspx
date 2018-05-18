<%@ Page Title="註冊" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>建立新帳戶。</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">使用者名稱</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="必須填寫使用者名稱欄位。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">密碼</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="必須填寫密碼欄位。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">確認密碼</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="必須填寫確認密碼欄位。" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="密碼和確認密碼不相符。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="StoreName" CssClass="col-md-2 control-label">店家名稱</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="StoreName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="StoreName"
                    CssClass="text-danger" ErrorMessage="必須填寫店家名稱欄位。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Tel" CssClass="col-md-2 control-label">電話號碼</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Tel" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Tel"
                    CssClass="text-danger" ErrorMessage="必須填寫電話號碼欄位。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label">店家地址</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
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
                <asp:TextBox runat="server" ID="Address" CssClass="form-control" Width="390px" OnTextChanged="Address_TextChanged" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Address"
                    CssClass="text-danger" ErrorMessage="必須填寫店家地址欄位。" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="註冊" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

