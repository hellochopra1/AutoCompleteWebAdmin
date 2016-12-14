<%@ Page Title="" Language="C#" MasterPageFile="~/DashBoard.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="KeywordMasterForTesting.aspx.cs" Inherits="AutoCompleteWebAdmin.KeywordMasterForTesting" %>

<%@ MasterType VirtualPath="~/DashBoard.Master" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadScriptBlock ID="radscript1" runat="server">
        <script>
            function requestStart(sender, args) {
                if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToPdfButton") >= 0) {
                    args.set_enableAjax(false);
                }
            }

            function OnClientClicking(sender, args) {
                if (!confirm("This will reset the search Counter for all Searches done. Confirm?")) {
                    args.set_cancel(true);
                }
            }

            function MessageB() {
                alert("Counter Reset Successfully!");
            }

            function GetCount() {
                AutoCompleteOMST.GetTotalCountForKeywords(true, GetTotalCount);
            }

            function GetTotalCount(result) {
                //alert("asd");
                // alert(result[0]["Count"]);
                document.getElementById("txtTotalCount").value = result[0]["Count"];

            }

        </script>
    </telerik:RadScriptBlock>
    <style>
        html .RadMenu_Glow {
            color: #fff !important;
            font: 13px/30px Arial,Helvetica,sans-serif !important;
        }
    </style>
    <style>
        @media screen and (min-width: 320px) {
            .additionalColumn {
                display: none !important;
            }

            .addSpaceHorizontal {
                margin-top: 10px !important;
            }
        }
    </style>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" ClientEvents-OnRequestStart="requestStart" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radGridKeyword">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl LoadingPanelID="RadAjaxLoadingPanel1" ControlID="radGridKeyword"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btndelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl LoadingPanelID="RadAjaxLoadingPanel1" ControlID="radGridKeyword"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
    <div class="col-md-12">
        <div class="col-md-2">
            <span style="font-size: 14px; text-shadow: 0 0 0px #000; font-weight: bold;">Upload Excel</span>
        </div>
        <div class="col-md-3">
            <telerik:RadAsyncUpload ID="RadAsyncUpload1" MultipleFileSelection="Disabled" AllowedFileExtensions="xls,xlsx" runat="server">
            </telerik:RadAsyncUpload>
        </div>
        <div class="col-md-2">
            <span style="font-size: 14px; text-shadow: 0 0 0px #000; font-weight: bold;">Company Names:</span>
        </div>
        <div class="col-md-5">
            <telerik:RadComboBox ID="ddlCompanyOut" DataSourceID="CompanySource" DataTextField="CompanyName" DataValueField="Id" Width="200px" runat="server">
            </telerik:RadComboBox>
        </div>
    </div>
    <div class="col-md-12">
        <div class="col-md-2">
            <span style="font-size: 14px; text-shadow: 0 0 0px #000; font-weight: bold;">Country:</span>
        </div>
        <div class="col-md-3">
            <telerik:RadComboBox ID="ddlCountryOut" DataSourceID="CountriesDataSource" DataTextField="Country" DataValueField="Id" Width="200px" runat="server">
            </telerik:RadComboBox>
        </div>
        <div class="col-md-7">
            <telerik:RadButton ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"></telerik:RadButton>
        </div>
    </div>
    <br />
    <div class="col-md-12 addSpaceHorizontal">
        <div class="col-md-2">
            <span>Get Total Search Count</span>
        </div>
        <div class="col-md-3">
            <input type="text" id="txtTotalCount" />
        </div>
        <div class="col-md-3 addSpaceHorizontal">
            <input type="button" id="btnGetCount" title="Get Keyword Total Count" value="Get Keyword Total Count" onclick="GetCount();" />
        </div>
       
        <div class="col-md-4 addSpaceHorizontal">
            <telerik:RadButton ID="btnResetCounter" Width="200" OnClientClicking="OnClientClicking" runat="server" Text="Reset Counter for Keywords" OnClick="btnResetCounter_Click"></telerik:RadButton>
        </div>
    </div>
    <br />
    <div class="col-md-12">
        <telerik:RadButton ID="btndelete" runat="server" Text="Delete Selected Rows" OnClick="btndelete_Click"></telerik:RadButton>
    </div>
    <br /><br /><br /><br /><br /><br /> 

    <telerik:RadGrid ID="radGridKeyword" AutoGenerateColumns="false" AllowPaging="true" OnUpdateCommand="radGridKeyword_UpdateCommand"
        OnDeleteCommand="radGridKeyword_DeleteCommand" EnableHeaderContextMenu="true" AllowFilteringByColumn="true"
        AllowMultiRowSelection="true" OnInsertCommand="radGridKeyword_InsertCommand" AllowSorting="true" PageSize="10" OnNeedDataSource="radGridKeyword_NeedDataSource" OnItemDataBound="radGridKeyword_ItemDataBound" runat="server">

        <ExportSettings IgnorePaging="true" ExportOnlyData="true" Excel-Format="ExcelML" HideStructureColumns="true"></ExportSettings>
        <MasterTableView RetrieveAllDataFields="True" DataKeyNames="Id" EnableHeaderContextMenu="True" CommandItemSettings-ShowExportToExcelButton="true"
            CommandItemSettings-ShowExportToPdfButton="true" CommandItemSettings-ShowExportToWordButton="true" CommandItemDisplay="Top" EditMode="PopUp" TableLayout="Fixed">
            <PagerStyle AlwaysVisible="true" />
            <Columns>
                <telerik:GridClientSelectColumn>
                    <ItemStyle Width="30px" />
                    <HeaderStyle Width="30px" />
                </telerik:GridClientSelectColumn>
                <telerik:GridBoundColumn HeaderText="CompanyName" FilterControlWidth="100" DataField="CompanyName" UniqueName="CompanyName"
                    SortExpression="CompanyName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Country" Display="false" FilterControlWidth="45px" DataField="Country" UniqueName="Country"
                    SortExpression="Country">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Keyword" DataField="Keyword" UniqueName="Keyword"
                    SortExpression="Keyword">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="WebSite Link" DataField="Link"
                    UniqueName="Link" SortExpression="Link">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Link1" Display="false" DataField="Contact"
                    UniqueName="Contact" SortExpression="Contact">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Link2" Display="false" DataField="Other"
                    UniqueName="Other" SortExpression="Other">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Link3" Display="false" DataField="Link3"
                    UniqueName="Link3" SortExpression="Link3">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Link4" Display="false" DataField="Link4"
                    UniqueName="Link4" SortExpression="Link4">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Link5" Display="false" DataField="Link5"
                    UniqueName="Link5" SortExpression="Link5">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Link6" Display="false" DataField="Link6"
                    UniqueName="Link6" SortExpression="Link6">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Searches to be Done" FilterControlWidth="25px" DataField="Searches"
                    UniqueName="Searches" SortExpression="Searches">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Searches Done" FilterControlWidth="25px" DataField="SerchesCounter"
                    UniqueName="SerchesCounter" SortExpression="SerchesCounter">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Status" DataField="Active"
                    UniqueName="Active" SortExpression="Active">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Is Hold" Display="false" DataField="IsLocked"
                    UniqueName="IsLocked" SortExpression="IsLocked">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn HeaderText="Is Bing" Display="true" DataField="IsBing"
                    UniqueName="IsBing" SortExpression="IsBing">
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
            <EditFormSettings InsertCaption="Add New Keyword"
                EditFormType="Template" PopUpSettings-Width="900px">
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
                                <telerik:RadComboBox ID="ddlCompany" DataSourceID="CompanySource" DataTextField="CompanyName" DataValueField="Id" Width="200px" runat="server">
                                </telerik:RadComboBox>
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

                            <div class="FieldLabel">
                                Keyword:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ValidateRequestMode="Enabled" ID="txtKeyword"
                                    Width="250">
                                </telerik:RadTextBox>

                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Link:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ID="txtLink" Width="250">
                                </telerik:RadTextBox>

                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Contact:
                            </div>
                            <div>
                                <telerik:RadTextBox ID="txtContact" runat="server" Width="250"></telerik:RadTextBox>

                                <%--<telerik:RadDateTimePicker runat="server" ID="radDateDOB" Width="250">
                                </telerik:RadDateTimePicker>--%>
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Other:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ID="txtOther" Width="250">
                                </telerik:RadTextBox>
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Link3:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ID="txtLink3" Width="250">
                                </telerik:RadTextBox>
                            </div>
                            <div class="FieldLabel">
                                Link4:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ID="txtLink4" Width="250">
                                </telerik:RadTextBox>

                            </div>

                        </div>
                        <div id="div1" style="float: left; width: 50%;" runat="server">
                            <div class="lineBreakField ">
                            </div>

                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Link5:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ID="txtLink5" Width="250">
                                </telerik:RadTextBox>

                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Link6:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ID="txtLink6" Width="250">
                                </telerik:RadTextBox>

                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Status:
                            </div>
                            <div>
                                <input type="checkbox" id="chkActive" runat="server" />
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                IsBing:
                            </div>
                            <div>
                                <input type="checkbox" id="chkIsBing" runat="server" />
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Reset Search Lock:
                            </div>
                            <div>
                                <input type="checkbox" id="chkReset" runat="server" />
                            </div>
                            <div class="lineBreakField ">
                            </div>
                            <div class="FieldLabel">
                                Searches:
                            </div>
                            <div>
                                <telerik:RadTextBox runat="server" ID="txtSearches" Width="250">
                                </telerik:RadTextBox>
                            </div>
                            <div class="lineBreakField ">
                            </div>

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
                </FormTemplate>
            </EditFormSettings>
        </MasterTableView>
        <ClientSettings AllowDragToGroup="True" ColumnsReorderMethod="Reorder" AllowColumnsReorder="True" ReorderColumnsOnClient="True">
            <%--<ClientEvents OnRowDblClick="OnRowDblClick" OnColumnMovedToLeft="OnColumnSwapped" OnRowContextMenu="RowContextMenu"
                    OnColumnMovedToRight="OnColumnSwapped" OnFilterMenuShowing="filterMenuShowing"
                    OnPopUpShowing="PositionPopup" OnColumnHidden="OnColumnSwapped" OnColumnShown="OnColumnSwapped" />--%>
            <Resizing AllowColumnResize="True" AllowResizeToFit="True" ResizeGridOnColumnResize="True"
                AllowRowResize="False" ClipCellContentOnResize="true" EnableRealTimeResize="false" />
            <Scrolling AllowScroll="True" UseStaticHeaders="false" ScrollHeight="" />
            <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
        </ClientSettings>
    </telerik:RadGrid>

    <asp:ObjectDataSource ID="CompanySource" runat="server" SelectMethod="GetAllCompanies"
        TypeName="AutoCompleteWebAdmin.KeywordMaster"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CountriesDataSource" runat="server" SelectMethod="GetAllCountries"
        TypeName="AutoCompleteWebAdmin.KeywordMaster"></asp:ObjectDataSource>

</asp:Content>
