<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="editadmin.aspx.cs" Inherits="dev1.showadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1 style="font-weight: 900; color: white; font-size: x-large; margin-top: 10px;">Edit selected item or delete it</h1>

    <table style="color: white;">
        <tr>
            <td>ID</td><td><asp:TextBox ID="TextBox_id" runat="server" ReadOnly="true"></asp:TextBox></td><td></td>
        </tr>
        <tr>
            <td>Name</td><td><asp:TextBox ID="TextBox_name" runat="server"></asp:TextBox></td><td></td>
        </tr>
        <tr>
            <td>Description</td><td><asp:TextBox ID="TextBox_desc" runat="server"></asp:TextBox></td><td></td>
        </tr>
         <tr>
            <td>Image</td><td><asp:TextBox ID="TextBox_image" runat="server" ReadOnly="true"></asp:TextBox></td><td><asp:FileUpload ID="FileUpload_update" runat="server" /></td>
        </tr>
         <tr>
            <td>Category</td><td> Selected category: <asp:DropDownList ID="DropDownList_category" runat="server" AutoPostBack="true"></asp:DropDownList></td><td>Choose a new category: <asp:DropDownList ID="DropDownList_update_category" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource_category" DataTextField="category_name" DataValueField="category_id"></asp:DropDownList></td>
        </tr>
         <tr>
            <td>Joke</td><td> Selected joke: <asp:DropDownList ID="DropDownList_joke" runat="server" AutoPostBack="true"></asp:DropDownList></td><td>Choose a new joke: <asp:DropDownList ID="DropDownList_update_joke" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource_joke" DataTextField="joke_quote" DataValueField="joke_id"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Section</td><td> Selected section: <asp:TextBox ID="TextBox_section" runat="server" ReadOnly="true"></asp:TextBox></td><td>Yes or No to section<asp:DropDownList ID="DropDownList_update_section" runat="server" AutoPostBack="True">
            <asp:ListItem Value="0">No to section</asp:ListItem>
            <asp:ListItem Value="1">Yes to section</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
         <tr>
            <td>Update</td><td><asp:Button ID="Button_update" runat="server" Text="Update" OnClick="Button_update_Click" /></td><td><asp:Button ID="Button_delete" runat="server" Text="Delete" OnClick="Button_delete_Click" /></td>
        </tr>
    </table>

    <asp:SqlDataSource ID="SqlDataSource_joke" runat="server" ConnectionString="<%$ ConnectionStrings:dev1ConnectionString %>" SelectCommand="SELECT * FROM [joke]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource_category" runat="server" ConnectionString="<%$ ConnectionStrings:dev1ConnectionString %>" SelectCommand="SELECT * FROM [category]"></asp:SqlDataSource>

</asp:Content>
