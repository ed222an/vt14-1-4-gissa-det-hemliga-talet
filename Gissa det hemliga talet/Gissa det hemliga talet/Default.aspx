<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gissa_det_hemliga_talet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link href="Content/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="errorList">
                <%-- Felmeddelandelista --%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Ett fel inträffade. Korrigera felet och gör ett nytt försök." />
            </div>

            <%-- Inputfält och skicka-knapp --%>
            <div>
                <asp:Literal ID="InputLiteral" runat="server" Text="Ange ett tal mellan 1-100: "></asp:Literal>
                <asp:TextBox ID="InputTextBox" runat="server" Enabled="false"></asp:TextBox>
                <asp:Button ID="GuessButton" runat="server" Text="Skicka gissning" OnClick="SendButton_Click" Visible="false" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Fyll i ett heltal."
                    ControlToValidate="InputTextBox"
                    Display="None"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server"
                    ErrorMessage="Ange ett heltal mellan 1-100."
                    ControlToValidate="InputTextBox"
                    MaximumValue="100" MinimumValue="1" Type="Integer"
                    Display="None"></asp:RangeValidator>
            </div>

            <%-- Presentation av resultat --%>
            <div>
                <asp:Label ID="GuessLabel" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="StatusLabel" runat="server"></asp:Label>
                <asp:Label ID="EndLabel" runat="server" Visible="False"></asp:Label>
            </div>

            <%-- Knapp för ny gissning --%>
            <div>
                <asp:Button ID="ResetButton" runat="server" Text="Slumpa nytt hemligt tal" Visible="true" OnClick="ResetButton_Click" CausesValidation="False" />
            </div>
        </div>
    </form>

    <%-- Scripts --%>
    <script src="Scripts/formScript.js"></script>
</body>
</html>
