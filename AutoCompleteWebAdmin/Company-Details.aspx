<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="Company-Details.aspx.cs" Inherits="AutoCompleteWebAdmin.Company_Details" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
 
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label> 
            </td>
             <td>

                 <telerik:RadTextBox ID="txtCompanyName" runat="server"></telerik:RadTextBox>

             </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Company Address"></asp:Label>
            </td>
             <td>
                 <telerik:RadTextBox ID="txtAddress" runat="server"></telerik:RadTextBox>

            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="WebSite"></asp:Label>
            </td>
             <td>
                 <telerik:RadTextBox ID="txtWebsite" runat="server"></telerik:RadTextBox>

            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Google WebMaster Login"></asp:Label>
            </td>
             <td>
                 <telerik:RadTextBox ID="txtWebmasterUsername" runat="server"></telerik:RadTextBox>

            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Google WebMaster Password( Encrypted )"></asp:Label>
            </td>
             <td>
                 <telerik:RadTextBox ID="txtWebMasterPassword" TextMode="Password" runat="server"></telerik:RadTextBox>

            </td>
        </tr>
        <tr>
            <td>
                
            </td>
             <td>
                 <telerik:RadButton ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Sumbit"></telerik:RadButton>

            </td>
        </tr>
    </table>




</asp:Content>
