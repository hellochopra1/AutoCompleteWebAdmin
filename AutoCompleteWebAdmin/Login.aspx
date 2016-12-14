<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" EnableEventValidation="false" Inherits="AutoCompleteWebAdmin.Login" %>

<!DOCTYPE html>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>AutoComplete Admin Login</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="/assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="/assets/css/login.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME STYLES -->
    <link href="/assets/css/components.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="/assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="/assets/css/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="/assets/css/custom.css" rel="stylesheet" type="text/css" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <script>
         

        function loginfail()
        {
            alert("Invalid Username or Password!");
        }

        function pageLoad() {
            $("#txtLogin").focus();
            MyWCFService.DoWork();
        }
           
        function handle(e) {
            if (e.keyCode === 13) {
                __doPostBack("Button2", "OnClick");
            } 
            return false;
        }

    </script>
</head>
<body class="login">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ads" runat="server">
            <Services>
                <asp:ServiceReference Path="~/WebService/AutoCompleteOMST.asmx" />
            </Services>
        </asp:ScriptManager>
        <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
        <div class="menu-toggler sidebar-toggler">
        </div>
        <!-- END SIDEBAR TOGGLER BUTTON -->
        <!-- BEGIN LOGO -->
        <div class="logo">
            <a href="http://www.omsttech.com" target="_blank"><img src="/assets/images/logo1.png" alt="" /></a>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN LOGIN FORM -->
             
                <h3 class="form-title">Sign In</h3>
                <div class="alert alert-danger display-hide">
                    <button class="close" data-close="alert"></button>
                    <span>Enter any username and password. </span>
                </div>
                <div class="form-group">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <%--<telerik:RadTextBox ID="txtLoginId" runat="server" Height="44" Width="340" CssClass="form-control form-control-solid placeholder-no-fix" EmptyMessage="Enter UserName"></telerik:RadTextBox>--%>
                    <%--<asp:TextBox ID="txtLoginId" runat="server" CssClass="form-control form-control-solid placeholder-no-fix">User Name</asp:TextBox>--%>
                    <%--<asp:RequiredFieldValidator ID="requiredUsernameLogin" runat="server" ControlToValidate="txtUserName" ForeColor="Red" Display="Dynamic" ErrorMessage="Please Enter Username" ></asp:RequiredFieldValidator>--%>
                    <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
                     <%--<label class="control-label visible-ie8 visible-ie9">Username</label>--%>
                    <input onkeypress="handle(event);" class="form-control form-control-solid placeholder-no-fix" id="txtLogin" runat="server" type="text" autocomplete="off" placeholder="Username" name="username" />
                </div>
                <div class="form-group">
                    <%--<telerik:RadTextBox ID="txtPasswords" runat="server" Height="44" Width="340" TextMode="Password" CssClass="form-control form-control-solid placeholder-no-fix" EmptyMessage="Enter UserName"></telerik:RadTextBox>--%>

                    <%--<asp:TextBox ID="txtPasswords"  runat="server" CssClass="form-control form-control-solid placeholder-no-fix" TextMode="Password">Password</asp:TextBox>--%>
                   <%--<asp:RequiredFieldValidator ID="reqiredPasswordLogin" runat="server" ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>--%>
                     <%--<asp:TextBox ID="txtUserPass" runat="server" CssClass="form-control form-control-solid placeholder-no-fix" TextMode="Password"></asp:TextBox>--%>
                    <%--<label class="control-label visible-ie8 visible-ie9">Password</label>--%>
                    <input id="txtPassword" onkeypress="handle(event);" runat="server" class="form-control form-control-solid placeholder-no-fix" type="password" autocomplete="off" placeholder="Password" name="password" />
                </div>
                <div class="form-actions">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Login" CssClass="btn btn-success uppercase"/>
                    <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" CssClass="btn btn-success uppercase"/>--%>
                    <%-- <button type="submit" class="btn btn-success uppercase">Login</button>--%>
                    <%-- <label class="rememberme check">
                        <input type="checkbox" name="remember" value="1" />Remember
                    </label>--%>
                    <%--<a href="javascript:;" id="forget-password" class="forget-password">Forgot Password?</a>--%>
                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                </div>
                <%--<div class="login-options">
                    <h4>Or login with</h4>
                    <ul class="social-icons">
                        <li>
                            <a class="social-icon-color facebook" data-original-title="facebook" href="#"></a>
                        </li>
                        <li>
                            <a class="social-icon-color twitter" data-original-title="Twitter" href="#"></a>
                        </li>
                        <li>
                            <a class="social-icon-color googleplus" data-original-title="Goole Plus" href="#"></a>
                        </li>
                        <li>
                            <a class="social-icon-color linkedin" data-original-title="Linkedin" href="#"></a>
                        </li>
                    </ul>
                </div>--%>
                <%--<div class="create-account">
                    <p>
                        <a href="Registration.aspx" id="register-btn" class="uppercase">Create an account</a>
                    </p>
                </div>--%>
           
            <!-- END LOGIN FORM -->
            <!-- BEGIN FORGOT PASSWORD FORM -->
            <!-- END FORGOT PASSWORD FORM -->
        </div>
        <div class="copyright">
            2014 © <a href="http://www.omsttech.com" target="_blank">OMST TECHNOLOGIES</a>
        </div>
        <!-- END LOGIN -->
        <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
        <!-- BEGIN CORE PLUGINS -->
        <!--[if lt IE 9]>
        <script src="/assets/js/respond.min.js"></script>
        <script src="../../assets/global/plugins/excanvas.min.js"></script> 
        <![endif]-->
        <%--<script src="/assets/js/jquery.min.js" type="text/javascript"></script>
        <script src="/assets/js/jquery-migrate.min.js" type="text/javascript"></script>--%>
       <%-- <script src="/assets/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="/assets/js/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="/assets/js/jquery.cokie.min.js" type="text/javascript"></script>
        <script src="/assets/js/jquery.uniform.min.js" type="text/javascript"></script>--%>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <%--<script src="/assets/js/jquery.validate.min.js" type="text/javascript"></script>--%>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
      <%--  <script src="/assets/js/metronic.js" type="text/javascript"></script>
        <script src="/assets/js/layout.js" type="text/javascript"></script>
        <script src="/assets/js/demo.js" type="text/javascript"></script>--%>
        <%--<script src="/assets/js/login.js" type="text/javascript"></script>--%>
        <!-- END PAGE LEVEL SCRIPTS -->
        <!-- END JAVASCRIPTS -->
    </form>
</body>
</html>
