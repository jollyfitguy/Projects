<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="reelImage1" runat="server" Height="150px" />
        <asp:Image ID="reelImage2" runat="server" Height="150px" />
        <asp:Image ID="reelImage3" runat="server" Height="150px" />
        <br />
        <br />
        Your Bet:&nbsp;
        <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="goButton" runat="server" OnClick="goButton_Click" Text="Pull the Lever!" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="moneyLabel" runat="server"></asp:Label>
        <br />
        <br />
        1 Cherry - x2 Your Bet<br />
        2 Cherries - x3 Your Bet<br />
        3 Cherries - x4 Your Bet<br />
        3 7&#39;s - Jackpot - x100 Your Bet<br />
        However ... if there is even one BAR you win nothing<br />
    
    </div>
    </form>
</body>
</html>
