<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="TheOuterWoldShopHome.Controls.CategoryList" %>

<%= CreateHomeLinkHtml() %>

<% foreach (string category in GetCategories()) {
       Response.Write(CreateLinkHtml(category));       
}%>
