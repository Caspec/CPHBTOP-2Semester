<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="dev1.WebForm1" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Shakal CMS DEV 1</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="assets/css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header -->
        <header id="header">
            <div class="logo"><a href="default.aspx">CMS DEV 1</a></div>
        </header>

        <!-- Main -->
        <section id="main">
            <div>

                <!-- One -->
                <section id="one" class="wrapper style1">

                    <div class="image fit flush">
                    </div>
                    <header class="special">
                        <nav>
                            <ul class="my-row">
                                <li><a href="index.aspx">Index</a></li>
                                <li><a href="show.aspx">Show all wares</a></li>
                                <li><a href="admin.aspx">Admin page</a></li>
                            </ul>
                        </nav>
                    </header>
                   
                    
                    
                </section>

                <asp:Panel ID="Panel2" runat="server" Visible="true">

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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dev1ConnectionString %>" SelectCommand="SELECT TOP (1) item.item_id, item.item_name, item.item_description, item.item_picture, item.fk_category_id, item.fk_joke_id, item.fk_company_id, item.section, category.category_id, category.category_name, category.category_description, joke.* FROM section INNER JOIN item ON section.fk_item_id = item.item_id INNER JOIN category ON item.fk_category_id = category.category_id INNER JOIN joke ON item.fk_joke_id = joke.joke_id WHERE (item.section = 1)"></asp:SqlDataSource>

                <asp:Button ID="Button1" runat="server" Text="... Show more" OnClick="Button1_Click" style="margin: 10px;" />

                    </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Visible="false">

                    <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
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
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dev1ConnectionString %>" SelectCommand="SELECT item.item_id, item.item_name, item.item_description, item.item_picture, item.fk_category_id, item.fk_joke_id, item.fk_company_id, item.section, category.category_id, category.category_name, category.category_description, joke.* FROM category INNER JOIN item ON category.category_id = item.fk_category_id INNER JOIN section ON item.item_id = section.fk_item_id INNER JOIN joke ON item.fk_joke_id = joke.joke_id WHERE (item.section = 1)"></asp:SqlDataSource>


                    <asp:Button ID="Button2" runat="server" Text="... Show less" OnClick="Button2_Click" style="margin: 10px;" />

                    </asp:Panel>

            </div>
        </section>

        <!-- Footer -->
        <footer id="footer">
            <div class="container">
                <ul class="icons">
                </ul>
            </div>
            <div class="copyright">
                &copy; Shakal. All rights reserved.
            </div>
        </footer>


    </form>

    <!-- Scripts -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/jquery.poptrox.min.js"></script>
    <script src="assets/js/skel.min.js"></script>
    <script src="assets/js/util.js"></script>
    <script src="assets/js/main.js"></script>
</body>
</html>
