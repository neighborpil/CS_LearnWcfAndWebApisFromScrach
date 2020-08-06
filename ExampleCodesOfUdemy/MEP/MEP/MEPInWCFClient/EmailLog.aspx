<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailLog.aspx.cs" Inherits="EmailLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Uid" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="Uid" HeaderText="Uid" ReadOnly="True" SortExpression="Uid" />
                <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" SortExpression="UserEmail" />
                <asp:BoundField DataField="EmailSentFlag" HeaderText="EmailSentFlag" SortExpression="EmailSentFlag" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MEPDbConnectionString1 %>" DeleteCommand="DELETE FROM [UserRegistration] WHERE [Uid] = @Uid" InsertCommand="INSERT INTO [UserRegistration] ([UserEmail], [EmailSentFlag]) VALUES (@UserEmail, @EmailSentFlag)" ProviderName="<%$ ConnectionStrings:MEPDbConnectionString1.ProviderName %>" SelectCommand="SELECT [Uid], [UserEmail], [EmailSentFlag] FROM [UserRegistration]" UpdateCommand="UPDATE [UserRegistration] SET [UserEmail] = @UserEmail, [EmailSentFlag] = @EmailSentFlag WHERE [Uid] = @Uid">
            <DeleteParameters>
                <asp:Parameter Name="Uid" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="UserEmail" Type="String" />
                <asp:Parameter Name="EmailSentFlag" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserEmail" Type="String" />
                <asp:Parameter Name="EmailSentFlag" Type="String" />
                <asp:Parameter Name="Uid" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
