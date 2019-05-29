using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace IntegrationPart
{
    public partial class Index : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"data source = .\sqlexpress; integrated security = true; database = TestPartDB");
        PartMapper pm = new PartMapper();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Part p = new Part(Convert.ToInt32(TextBoxNo.Text), TextBoxName.Text, Convert.ToDecimal(TextBoxPrice.Text), Convert.ToInt32(TextBoxStock.Text));
                int rowsupdated = pm.InsertPart(p, conn);
                if (rowsupdated != 0)
                {
                    ListBoxList.Items.Clear();
                    ListBoxList.Items.Add(p.ToString());
                    LabelMessage.Text = "Part " + p.partno + " added";
                }
                else
                {
                    ListBoxList.Items.Clear();
                    LabelMessage.Text = "Part " + TextBoxNo.Text + " not added";
                }
            }
            catch (Exception ex)
            {
                ListBoxList.Items.Clear();
                LabelMessage.Text = "Wrong data format";
            }
        }

        protected void ButtonRead_Click(object sender, EventArgs e)
        {
            try
            {
                Part p = pm.GetPart(Convert.ToInt32(TextBoxNo.Text), conn);
                if (p != null)
                {
                    TextBoxName.Text = p.partname;
                    TextBoxPrice.Text = p.price.ToString();
                    TextBoxStock.Text = p.instock.ToString();
                    ListBoxList.Items.Clear();
                    ListBoxList.Items.Add(p.ToString());
                    LabelMessage.Text = "Part " + p.partno + " read";
                }
                else
                {
                    TextBoxName.Text = "";
                    TextBoxPrice.Text = "";
                    TextBoxStock.Text = "";
                    ListBoxList.Items.Clear();
                    LabelMessage.Text = "Part " + TextBoxNo.Text + " not found";
                }
            }
            catch(Exception ex)
            {
                TextBoxName.Text = "";
                TextBoxPrice.Text = "";
                TextBoxStock.Text = "";
                ListBoxList.Items.Clear();
                LabelMessage.Text = "Write a number for the part no";
            }
        }

        protected void ButtonReadAll_Click(object sender, EventArgs e)
        {
            ArrayList a = pm.GetAllParts(conn);
            if (a.Count >= 0)
            {
                ListBoxList.Items.Clear();
                for (int i = 0; i < a.Count; i++)
                {
                    ListBoxList.Items.Add(a[i].ToString());
                }
                LabelMessage.Text = a.Count + " parts read";
            }
            else
            {
                LabelMessage.Text = "No parts found";
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Part p = new Part(Convert.ToInt32(TextBoxNo.Text), TextBoxName.Text, Convert.ToDecimal(TextBoxPrice.Text), Convert.ToInt32(TextBoxStock.Text));
                int rowsupdated = pm.UpdatePart(p, conn);
                if (rowsupdated != 0)
                {
                    ListBoxList.Items.Clear();
                    ListBoxList.Items.Add(p.ToString());
                    LabelMessage.Text = "Part " + p.partno + " updated";
                }
                else
                {
                    ListBoxList.Items.Clear();
                    LabelMessage.Text = "Part " + TextBoxNo.Text + " not found; no update";
                }
            }
            catch (Exception ex)
            {
                ListBoxList.Items.Clear();
                LabelMessage.Text = "Wrong data format";
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int rowsupdated = pm.DeletePart(Convert.ToInt32(TextBoxNo.Text), conn);
                if (rowsupdated != 0)
                {
                    TextBoxName.Text = "";
                    TextBoxPrice.Text = "";
                    TextBoxStock.Text = "";
                    ListBoxList.Items.Clear();
                    LabelMessage.Text = "Part " + Convert.ToInt32(TextBoxNo.Text) + " deleted";
                }
                else
                {
                    TextBoxName.Text = "";
                    TextBoxPrice.Text = "";
                    TextBoxStock.Text = "";
                    ListBoxList.Items.Clear();
                    LabelMessage.Text = "Part " + TextBoxNo.Text + " not found; no delete";
                }
            }
            catch (Exception ex)
            {
                TextBoxName.Text = "";
                TextBoxPrice.Text = "";
                TextBoxStock.Text = "";
                ListBoxList.Items.Clear();
                LabelMessage.Text = "Write a number for the part no";
            }
        }
        
    }
}