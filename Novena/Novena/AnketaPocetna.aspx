<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnketaPocetna.aspx.cs" Inherits="Novena.AnketaPocetna" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Administracija:
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Admin/UrediAnketu.aspx">Uređivanje ankete</asp:HyperLink>
            <br />
            <br />
            Anketa: <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="AnketaNew.aspx">Prikaz ankete</asp:HyperLink>
        </div>
    </form>
</body>
</html>
