<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CompanyMaster.aspx.cs" Inherits="AutoCompleteWebAdmin.CompanyMaster" %>

<%@ MasterType VirtualPath="~/DashBoard.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        @media only screen and (min-width: 480px) and (max-width: 767px) {
            .additionalColumn {
                display: none !important;
            }
        }
    </style>

    <telerik:RadScriptBlock ID="radscript1" runat="server">
        <script>
            function requestStart(sender, args) {
                if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToPdfButton") >= 0) {
                    args.set_enableAjax(false);
                }
            }
        </script>
    </telerik:RadScriptBlock>

    <telerik:RadAjaxManager ID="RadAjaxManager1" ClientEvents-OnRequestStart="requestStart" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radGridCompany">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl LoadingPanelID="RadAjaxLoadingPanel1" ControlID="radGridCompany"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
    <br />
    <br />

    <telerik:RadGrid ID="radGridCompany" AllowPaging="true" AllowSorting="true" PageSize="10" OnNeedDataSource="radGridCompany_NeedDataSource" AutoGenerateColumns="false" OnUpdateCommand="radGridCompany_UpdateCommand"
        OnDeleteCommand="radGridCompany_DeleteCommand" OnInsertCommand="radGridCompany_InsertCommand" MasterTableView-AllowSorting="true" OnItemDataBound="radGridCompany_ItemDataBound" runat="server">

        <MasterTableView RetrieveAllDataFields="True" DataKeyNames="Id" EnableHeaderContextMenu="True" CommandItemSettings-ShowExportToExcelButton="true"
            CommandItemSettings-ShowExportToPdfButton="true" CommandItemSettings-ShowExportToWordButton="true" CommandItemDisplay="Top" EditMode="PopUp" TableLayout="Fixed">
            <PagerStyle AlwaysVisible="true" />
            <Columns>
                <telerik:GridBoundColumn HeaderText="CompanyName" DataField="CompanyName" UniqueName="CompanyName"
                    SortExpression="CompanyName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Address" DataField="Address" UniqueName="Address"
                    SortExpression="Address">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="WebSite" DataField="WebSite"
                    UniqueName="WebSite" SortExpression="WebSite">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="WebMasterLogin" DataField="WebMasterLogin"
                    UniqueName="WebMasterLogin" SortExpression="WebMasterLogin">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="WebMasterPass" DataField="WebMasterPass"
                    UniqueName="WebMasterPass" SortExpression="WebMasterPass">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="DateCreated" DataField="DateCreated"
                    UniqueName="DateCreated" SortExpression="DateCreated">
                </telerik:GridBoundColumn>

                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditImageUrl="/Styles/Images/edit.png" UniqueName="EditCommandColumn">
                    <HeaderStyle HorizontalAlign="Left" Width="30px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" CssClass="MyImageButton"></ItemStyle>
                </telerik:GridEditCommandColumn>

                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete"
                    FilterControlAltText="Filter DeleteColumn column" ImageUrl="/Styles/Images/Delete.png" Text="Delete"
                    UniqueName="DeleteColumn" Resizable="false" ConfirmText="Delete record?">
                    <HeaderStyle HorizontalAlign="Left" Width="30px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" CssClass="ButtonColumn" />
                </telerik:GridButtonColumn>
            </Columns>
            <EditFormSettings InsertCaption="Add New Company" EditColumn-HeaderStyle-Height="30px"
                EditFormType="Template" PopUpSettings-Width="480px">
                <FormCaptionStyle></FormCaptionStyle>
                <FormTemplate>
                    <div class="SettingsInputFormWrapper" style="margin-right: -35px; margin-left: 39px;">
                        <div class="lineBreakField">
                        </div>
                        <div id="divRight" style="float: left; width: 50%;" runat="server">

                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Company Names:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ValidateRequestMode="Enabled" ID="txtCompanyName"
                                    Width="250">
                                </telerik:RadTextBox>
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Address:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ValidateRequestMode="Enabled" ID="txtAddress"
                                    Width="250">
                                </telerik:RadTextBox>
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Website:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ID="txtWebsite" Width="250">
                                </telerik:RadTextBox>

                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                WebMaster Login:
                            </div>
                            <div>
                                <telerik:RadTextBox ID="txtWebMasterLogin" runat="server" Width="250"></telerik:RadTextBox>
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                WebMaster Pass:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ID="txtWebMasterPass" Width="250">
                                </telerik:RadTextBox>
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div style="clear: both;">
                            </div>
                            <br />
                            <div>
                                <div class="lineBreakField">
                                </div>
                                <div id="divButton" class="ButtonGroup" style="margin-left: 0px; float: right; width: 275px;" runat="server">
                                    <div style="float: left; left: 60px; margin-right: 2px; position: relative;">
                                        <telerik:RadButton ID="InsertUpdateButton" Text='<%# (Container is GridEditFormInsertItem) ? "Save" : "Update" %>'
                                            runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                        </telerik:RadButton>
                                    </div>
                                    <div style="float: left; left: 60px; margin-left: 10px; position: relative;">
                                        <telerik:RadButton ID="CancelButton" Text="Cancel"
                                            runat="server" CausesValidation="False" CommandName="Cancel">
                                        </telerik:RadButton>
                                    </div>
                                    <div style="clear: both;">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </FormTemplate>
            </EditFormSettings>
        </MasterTableView>
        <ClientSettings ColumnsReorderMethod="Reorder" AllowColumnsReorder="True" ReorderColumnsOnClient="True">
            <%--<ClientEvents OnRowDblClick="OnRowDblClick" OnColumnMovedToLeft="OnColumnSwapped" OnRowContextMenu="RowContextMenu"
                    OnColumnMovedToRight="OnColumnSwapped" OnFilterMenuShowing="filterMenuShowing"
                    OnPopUpShowing="PositionPopup" OnColumnHidden="OnColumnSwapped" OnColumnShown="OnColumnSwapped" />--%>
            <Resizing AllowColumnResize="True" AllowResizeToFit="True" ResizeGridOnColumnResize="True"
                AllowRowResize="False" ClipCellContentOnResize="true" EnableRealTimeResize="false" />
            <Scrolling AllowScroll="True" UseStaticHeaders="false" ScrollHeight="" />
            <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
        </ClientSettings>
    </telerik:RadGrid>


</asp:Content>
