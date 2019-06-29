<%@ Page Language="C#" AutoEventWireup="true"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demo02JP</title>
</head>
    <h1>Personal Information ASP.Net App </h1>
<body>
    <form id="form1" runat="server">
        <div  style="margin: 3px">
            <asp:Label ID="LabelName1"  runat="server"
                Text="Type your Name here:" />  <br />
            <asp:TextBox ID="TextBox1" runat="server" />
            <asp:Button ID="Button1"  runat="server" Text="Button" />


        </div>
    </form>
</body>
</html>
