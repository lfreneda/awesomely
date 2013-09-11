<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Awesomely.OAuth.Sample.WebForms._Default" %>
<%@ Import Namespace="Awesomely.OAuth.Facebook" %>
<%@ Import Namespace="Awesomely.OAuth.Orkut" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <a href="<%= new FacebookUriAuthentication().GetUriInitializeAuthentication() %>">
        Facebook Authentication</a>
    <br />
    <a href="<%= new OrkutUriAuthentication().GetUriInitializeAuthentication() %>">
        Orkut Authentication</a>
</asp:Content>
