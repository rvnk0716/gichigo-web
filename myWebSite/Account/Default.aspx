<%@ Page Title="即期GO" Language="C#" MasterPageFile="~/mySite.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>即期GO</h1>
        <p class="lead">即期GO是一個即期品的交易平台，透過網站上傳商品的資訊，讓使用者在手機APP進行瀏覽與訂購</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>維護商品</h2>
            <p>
                這裡維護商品
            </p>
            <p>
                <a class="btn btn-default" href="Product.aspx">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>留言板</h2>
            <p>
                這裡查看並回復商品留言
            </p>
            <p>
                <a class="btn btn-default" href="board.aspx">Learn more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
