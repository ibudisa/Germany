<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnketaNew.aspx.cs" Inherits="Novena.AnketaNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblPitanje" runat="server" Text="Label"></asp:Label>
            </br>
            </br>
            <asp:RadioButtonList ID="rbtnlistPitanja" runat="server" DataTextField="TekstOdgovora" DataValueField="Id">
            </asp:RadioButtonList>
            </br>
            </br>
            <asp:Button ID="btnSpremi" runat="server" OnClick="btnSpremi_Click" Text="Spremi" />
            </br>

        </div>
    </form>
</body>
</html>
