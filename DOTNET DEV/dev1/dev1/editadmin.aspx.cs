using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace dev1
{
    public partial class showadmin : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dev1ConnectionString"].ConnectionString);
                connection.Open();

                string SQL = string.Format("SELECT category.*, joke.*, item.* FROM category INNER JOIN item ON category.category_id = item.fk_category_id INNER JOIN joke ON item.fk_joke_id = joke.joke_id WHERE item_id=" + id + ";");

                SqlCommand command = new SqlCommand(SQL, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TextBox_id.Text = reader["item_id"].ToString();
                    TextBox_name.Text = reader["item_name"].ToString();
                    TextBox_desc.Text = reader["item_description"].ToString();
                    TextBox_image.Text = reader["item_picture"].ToString();
                    TextBox_section.Text = reader["section"].ToString();

                    ListItem listItemCategory = new ListItem();
                    listItemCategory.Value = reader["category_id"].ToString();
                    listItemCategory.Text = reader["category_name"].ToString();
                    DropDownList_category.Items.Add(listItemCategory);

                    ListItem listItemJoke = new ListItem();
                    listItemJoke.Value = reader["joke_id"].ToString();
                    listItemJoke.Text = reader["joke_quote"].ToString();
                    DropDownList_joke.Items.Add(listItemJoke);
                }

                reader.Close();
                connection.Close();
            }

          
        }

        protected void Button_update_Click(object sender, EventArgs e)
        {
            int item_id = Convert.ToInt32(TextBox_id.Text);
            string item_name = TextBox_name.Text;
            string item_description = TextBox_desc.Text;
            int fk_category_id = Convert.ToInt32(DropDownList_update_category.SelectedValue);
            int fk_joke_id = Convert.ToInt32(DropDownList_update_joke.SelectedValue);
            int section = Convert.ToInt32(DropDownList_update_section.SelectedValue);

            if (FileUpload_update.HasFile)
            {
                string str = FileUpload_update.FileName;
                FileUpload_update.PostedFile.SaveAs(Server.MapPath("~/images/" + str));
                string image = str.ToString();

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dev1ConnectionString"].ConnectionString);
                connection.Open();
                SqlCommand com = new SqlCommand("UPDATE item SET item_name = @item_name, item_description = @item_description, item_picture = @item_picture, fk_category_id = @fk_category_id, fk_joke_id = @fk_joke_id, fk_company_id = @fk_company_id, section = @section " + "WHERE item_id = @item_id", connection);
                com.Parameters.Add(new SqlParameter("@item_id", item_id));
                com.Parameters.Add(new SqlParameter("@item_name", item_name));
                com.Parameters.Add(new SqlParameter("@item_description", item_description));
                com.Parameters.Add(new SqlParameter("@item_picture", image));
                com.Parameters.Add(new SqlParameter("@fk_category_id", fk_category_id));
                com.Parameters.Add(new SqlParameter("@fk_joke_id", fk_joke_id));
                com.Parameters.Add(new SqlParameter("@fk_company_id", 1));
                com.Parameters.Add(new SqlParameter("@section", section));
                com.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("admin.aspx");
            }
        }

        protected void Button_delete_Click(object sender, EventArgs e)
        {
            int item_id = Convert.ToInt32(TextBox_id.Text);
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dev1ConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand com = new SqlCommand("DELETE FROM item " + "WHERE item_id = @item_id", connection);
            com.Parameters.Add(new SqlParameter("@item_id", item_id));
            com.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("admin.aspx");
        }
    }
}