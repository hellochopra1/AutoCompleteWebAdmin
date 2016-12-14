<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="BingSettings.aspx.cs" Inherits="AutoCompleteWebAdmin.BingSettings" %>
<%@ MasterType VirtualPath="~/DashBoard.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .form-control {
            width: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Setting Page for Bing</h2>
    <hr/>
    <div class="form-group">
        <span style="font-size: 14px; text-shadow: 0 0 0px #000; font-weight: bold;">Home Page wait</span>
        <asp:TextBox runat="server" CssClass="form-control" ID="txtHomePageWait"></asp:TextBox>
    </div>
    <div class="form-group">
        <span style="font-size: 14px; text-shadow: 0 0 0px #000; font-weight: bold;">Enter Number of change For Browser:</span>
        <asp:TextBox runat="server" CssClass="form-control" ID="txtBrowserChange"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button runat="server" OnClick="btnSubmit_OnClick" CssClass="btn btn-success" ID="btnSubmit" Text="Save" />
    </div>
</asp:Content>
