<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox>
        <br />
    
        <asp:Button ID="btnSignUp" runat="server" OnClick="btnSignUp_Click" Text="SignUp" />
        <br />
        <br />
        <a href="EmailLog.aspx">EmailLog.aspx</a><br />
    </div>
    </form>
</body>
</html>
