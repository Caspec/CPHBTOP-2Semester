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
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_insert_Click(object sender, EventArgs e)
        {
            string item_name = TextBox_insert_itemname.Text;
            string item_description = TextBox_insert_itemdescription.Text;
            int fk_category_id = 1;
            int fk_joke_id = 1;
            int fk_company_id = 1;
            int section = Convert.ToInt32(DropDownList_insert_section.SelectedValue);

            if (FileUpload_insert_picture.HasFile)
            {
                string str = FileUpload_insert_picture.FileName;
                FileUpload_insert_picture.PostedFile.SaveAs(Server.MapPath("~/images/" + str));
                string image = str.ToString();

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dev1ConnectionString"].ConnectionString);
                connection.Open();

                SqlCommand com = new SqlCommand("INSERT INTO item (item_name, item_description, item_picture, fk_category_id, fk_joke_id, fk_company_id, section) VALUES (@item_name, @item_description, @item_picture, @fk_category_id, @fk_joke_id, @fk_company_id, @section)", connection);
                com.Parameters.Add(new SqlParameter("@item_name", item_name));
                com.Parameters.Add(new SqlParameter("@item_description", item_description));
                com.Parameters.Add(new SqlParameter("@item_picture", image));
                com.Parameters.Add(new SqlParameter("@fk_category_id", fk_category_id));
                com.Parameters.Add(new SqlParameter("@fk_joke_id", fk_joke_id));
                com.Parameters.Add(new SqlParameter("@fk_company_id", fk_company_id));
                com.Parameters.Add(new SqlParameter("@section", section));
                com.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("admin.aspx");
            }
        }

        protected void Button_insert_joke_Click(object sender, EventArgs e)
        {
            string joke_name = TextBox_new_insert_joke.Text;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dev1ConnectionString"].ConnectionString);
            connection.Open();

            SqlCommand com = new SqlCommand("INSERT INTO joke (joke_quote) VALUES (@joke_quote)", connection);
            com.Parameters.Add(new SqlParameter("@joke_quote", joke_name));
            com.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("admin.aspx");
        }

        protected void Button_insert_category_Click(object sender, EventArgs e)
        {
            string category_name = TextBox_insert_categoryname.Text;
            string category_desc = TextBox_insert_categorydescription.Text;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dev1ConnectionString"].ConnectionString);
            connection.Open();

            SqlCommand com = new SqlCommand("INSERT INTO category (category_name, category_description) VALUES (@category_name, @category_description)", connection);
            com.Parameters.Add(new SqlParameter("@category_name", category_name));
            com.Parameters.Add(new SqlParameter("@category_description", category_desc));
            com.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("admin.aspx");
        }
    }
}