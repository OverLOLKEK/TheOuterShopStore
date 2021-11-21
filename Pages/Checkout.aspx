<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="TheOuterWoldShopHome.Pages.Checkout"
    MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">

        <div id="checkoutForm" class="checkout" runat="server">
            <h2>Оформить заказ</h2>
            Пожалуйста, введите свои данные, и вы получите этот дом через пару мгновений!

        <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display:none"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>

            <h3>Заказчик</h3>
            <div>
                <label for="name">Имя:</label>
                <SX:VInput Property="Name" runat="server" />
            </div>

            <h3>Адрес брони</h3>
             <div>
                <label for="city">Город:</label>
                <SX:VInput Property="City" runat="server" />
            </div>
            <div>
                <label for="line1">Адрес :</label>
                <SX:VInput Property="Line" runat="server" />
            </div>                                  
        <p class="actionButtons">
            <button class="actionButtons" type="submit">Обработать заказ</button>
        </p>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Спасибо!</h2>
            Спасибо что выбрали наш магазин!
        </div>
    </div>
</asp:Content>
