<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" AutoEventWireup="true" CodeBehind="ProxyMaster.aspx.cs" Inherits="AutoCompleteWebAdmin.ProxyMaster" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ MasterType VirtualPath="~/DashBoard.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
            <telerik:AjaxSetting AjaxControlID="radGridIP">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl LoadingPanelID="RadAjaxLoadingPanel1" ControlID="radGridIP"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="btndelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl LoadingPanelID="RadAjaxLoadingPanel1" ControlID="radGridIP"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting> 
            <%--<telerik:AjaxSetting AjaxControlID="RadAsyncUpload1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl LoadingPanelID="RadAjaxLoadingPanel1" ControlID="radGridIP"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>
   
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>

    <div style="width:800px;float:left;">
        <div style="width:100px;float:left;">
             <span style="font-size: 14px;text-shadow: 0 0 0px #000;font-weight: bold;margin-top: 10px;position: relative;top: 5px;">Upload Excel</span>
        </div>
        <div style="width:280px;float:left;">           
            <telerik:RadAsyncUpload ID="RadAsyncUpload1"  MultipleFileSelection="Disabled" AllowedFileExtensions="xls,xlsx" runat="server">
            </telerik:RadAsyncUpload>
        </div>
        <div>
            <telerik:RadComboBox ID="ddlCountryOut" DataSourceID="CountriesDataSource" DataTextField="Country" DataValueField="Id" Width="200px" runat="server">
                                </telerik:RadComboBox>
            <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"></telerik:RadButton>
        </div>
    </div>
     
    <br />
    <br />
  <br />
    <br />
     <div style="font-weight:bold;color:red;bottom: 20px;float: right;position: relative;">
        * IS HOLD means IP is currently running
    </div>
    <div style="position:relative;top:45px;left: 80px;float:right;">
    <telerik:RadButton ID="btndelete" runat="server" Text="Delete Selected Rows" OnClick="btndelete_Click"></telerik:RadButton>

    </div>
    <telerik:RadGrid ID="radGridIP" AllowPaging="true" AllowSorting="true" PageSize="10" OnNeedDataSource="radGridIP_NeedDataSource" AutoGenerateColumns="false" OnUpdateCommand="radGridIP_UpdateCommand"
        OnDeleteCommand="radGridIP_DeleteCommand" AllowMultiRowSelection="true" AllowFilteringByColumn="true" OnInsertCommand="radGridIP_InsertCommand" MasterTableView-AllowSorting="true" OnItemDataBound="radGridIP_ItemDataBound" runat="server">

        <MasterTableView RetrieveAllDataFields="True" DataKeyNames="Id" EnableHeaderContextMenu="True" CommandItemSettings-ShowExportToExcelButton="true"
            CommandItemSettings-ShowExportToPdfButton="true" CommandItemSettings-ShowExportToWordButton="true" CommandItemDisplay="Top" EditMode="PopUp" TableLayout="Fixed">
            <PagerStyle AlwaysVisible="true" />
            <Columns>
                <telerik:GridClientSelectColumn>
                </telerik:GridClientSelectColumn>
                <telerik:GridBoundColumn HeaderText="Country" DataField="Country" UniqueName="Country"
                    SortExpression="Country">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="ProxyIP" DataField="ProxyIP" UniqueName="ProxyIP"
                    SortExpression="ProxyIP">
                </telerik:GridBoundColumn>
                 
                
                 <telerik:GridBoundColumn HeaderText="Is Hold" DataField="IsLocked"
                    UniqueName="IsLocked" SortExpression="IsLocked">
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
            <EditFormSettings InsertCaption="Add New IP" EditColumn-HeaderStyle-Height="30px"
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
                                Ip Names:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ValidateRequestMode="Enabled" ID="txtProxy"
                                    Width="250">
                                </telerik:RadTextBox>
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Country Name:
                            </div>
                            <div>
                                <telerik:RadComboBox ID="ddlCountry" DataSourceID="CountriesDataSource" DataTextField="Country" DataValueField="Id" Width="200px" runat="server">
                                </telerik:RadComboBox>
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
     <asp:ObjectDataSource ID="CountriesDataSource" runat="server" SelectMethod="GetAllCountries"
        TypeName="AutoCompleteWebAdmin.ProxyMaster"></asp:ObjectDataSource>
</asp:Content>
