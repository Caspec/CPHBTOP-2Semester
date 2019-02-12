<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="dev1.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="font-weight: 900; color: white; font-size: x-large; margin-top: 10px;">Admin page overview</h1>

    <table class="admincolor">
        <tr>
            <th>ID</th>
            <th>Item name</th>
            <th>Category</th>
            <th>Joke</th>
            <th>Edit / Delete item</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <tr>
                    <td style="font-weight: 600;"><%# Eval("item_id") %></a></td>
                    <td><%# Eval("item_name") %></td>
                    <td><%# Eval("category_name") %></td>
                    <td><%# Eval("joke_quote") %></td>
                    <td style="font-weight: 600;"><a href="editadmin.aspx?id=<%# Eval("item_id") %>">Edit</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>

    </table>

    <br /><br />

    <h2 style="font-weight: 900; color: white; font-size: x-large; margin-top: 10px;">Add new item</h2>

    <table style="color: white;">
        <tr>
            <td></td><td></td><td></td>
        </tr>
        <tr>
            <td>Item name</td><td><asp:TextBox ID="TextBox_insert_itemname" runat="server" ReadOnly="false"></asp:TextBox></td><td></td>
        </tr>
        <tr>
            <td>Item description</td><td><asp:TextBox ID="TextBox_insert_itemdescription" runat="server"></asp:TextBox></td><td></td>
        </tr>
        <tr>
            <td>Item picture</td><td><asp:FileUpload ID="FileUpload_insert_picture" runat="server" /></td><td></td>
        </tr>
        <tr>
            <td>Section</td><td><asp:DropDownList ID="DropDownList_insert_section" runat="server">
            <asp:ListItem Value="0">No to section</asp:ListItem>
            <asp:ListItem Value="1">Yes to section</asp:ListItem>
            </asp:DropDownList></td><td></td>
        </tr>
        <tr>
            <td><asp:Button ID="Button_insert" runat="server" Text="Create" OnClick="Button_insert_Click" /></td><td></td>
        </tr>

    </table>

     <br /><br />

    <h2 style="font-weight: 900; color: white; font-size: x-large; margin-top: 10px;">Add new joke</h2>

    <table style="color: white;">
        <tr>
            <td>Joke</td><td><asp:TextBox ID="TextBox_new_insert_joke" runat="server" ReadOnly="false"></asp:TextBox></td><td></td>
        </tr>
        <tr>
            <td><asp:Button ID="Button_insert_joke" runat="server" Text="Create" OnClick="Button_insert_joke_Click" /></td><td></td>
        </tr>

    </table>

     <br /><br />

    <h2 style="font-weight: 900; color: white; font-size: x-large; margin-top: 10px;">Add new category</h2>

    <table style="color: white;">
        <tr>
            <td>Category name</td><td><asp:TextBox ID="TextBox_insert_categoryname" runat="server" ReadOnly="false"></asp:TextBox></td><td></td>
        </tr>
        <tr>
            <td>Category description</td><td><asp:TextBox ID="TextBox_insert_categorydescription" runat="server" ReadOnly="false"></asp:TextBox></td><td></td>
        </tr>
        <tr>
            <td><asp:Button ID="Button_insert_category" runat="server" Text="Create" OnClick="Button_insert_category_Click" /></td><td></td>
        </tr>

    </table>
    

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dev1ConnectionString %>" SelectCommand="SELECT category.*, joke.*, item.* FROM category INNER JOIN item ON category.category_id = item.fk_category_id INNER JOIN joke ON item.fk_joke_id = joke.joke_id"></asp:SqlDataSource>

   

</asp:Content>
