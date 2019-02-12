<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="dev1.show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <div class="displaywares">
                <div>
                    <h2 class="category"><%# Eval ("category_name") %></h2>
                </div>
                <div>
                    <h3 class="headline"><%# Eval ("item_name") %></h3>
                </div>
                <div>
                    <img src='images/<%# Eval ("item_picture") %>' /></div>
                <div>
                    <p><%# Eval ("category_description") %></p>
                </div>
                <div style="margin-top: 5px;">
                    <p>Dagens joke: <%# Eval ("joke_quote") %></p>
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dev1ConnectionString %>" SelectCommand="SELECT item.item_id, item.item_name, item.item_description, item.item_picture, item.fk_category_id, item.fk_joke_id, item.fk_company_id, item.section, category.category_id, category.category_name, category.category_description, joke.* FROM item INNER JOIN category ON item.fk_category_id = category.category_id INNER JOIN joke ON item.fk_joke_id = joke.joke_id"></asp:SqlDataSource>

</asp:Content>
