<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IntegrationPart.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Use of Part</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBoxNo" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="LabelNo" runat="server" Text="Part no"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="LabelName" runat="server" Text="Part name"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="LabelPrice" runat="server" Text="Price (use ,)"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBoxStock" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Label ID="LabelStock" runat="server" Text="Number in stock"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Create" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonRead" runat="server" OnClick="ButtonRead_Click" Text="Read" Width="100px" />
&nbsp;&nbsp; &nbsp;
            <asp:Button ID="ButtonReadAll" runat="server" OnClick="ButtonReadAll_Click" Text="Read all" Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonUpdate" runat="server" Text="Update" Width="100px" OnClick="ButtonUpdate_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" Width="100px" OnClick="ButtonDelete_Click" />
            <br />
            <br />
            <asp:Label ID="LabelMessage" runat="server" Text="No message"></asp:Label>
            <br />
            <br />
            <asp:ListBox ID="ListBoxList" runat="server" Height="100px" Width="500px"></asp:ListBox>
        </div>
    </form>
</body>
</html>
