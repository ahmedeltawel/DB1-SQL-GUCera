using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GUCera
{
    public partial class AddCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Session["RegisterMessage"] = "<h3> You Must Login First!!</h3>";
                Response.Redirect("Login.aspx");

            }
            else
            {
                string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

                SqlConnection conn = new SqlConnection(connStr);

                conn.Open();
                SqlCommand command1 = new SqlCommand("SELECT id FROM dbo.Student ", conn);
                SqlDataReader read1 = command1.ExecuteReader();
                Boolean f = false;
                while (read1.Read())
                {
                    if ((int)Session["user"] == read1.GetInt32(read1.GetOrdinal("id")))
                    {
                        f = true;
                    }

                }
                conn.Close();
                if (!f)
                {
                    Session["RegisterMessage"] = "<h3> You Must Login First!!</h3>";
                    Response.Redirect("Login.aspx");
                }
            }

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand addCreditCard = new SqlCommand("addCreditCard", conn);
            addCreditCard.CommandType = CommandType.StoredProcedure;


            addCreditCard.Parameters.Add(new SqlParameter("@sid", (int)Session["user"]));
            
            if (TextBox2.Text.Length == 15) {
               
                string CardNumber = TextBox2.Text;
                addCreditCard.Parameters.Add(new SqlParameter("@number", CardNumber));
            }
            else
            {
                Response.Write("<h3>Credit Card Number Must be 15 digits</h3>");
                return;
            }
            if (TextBox3.Text != string.Empty)
            {
                string CardHolderName = TextBox3.Text;
                addCreditCard.Parameters.Add(new SqlParameter("@cardHolderName", CardHolderName));
            }
            else
            {
                Response.Write("<h3>Credit Card Name Can't be Empty!</h3>");
                return;
            }
            if (TextBox5.Text != string.Empty)
            {
                string CVV = TextBox5.Text;
                addCreditCard.Parameters.Add(new SqlParameter("@cvv", CVV));
            }
            else
            {
                Response.Write("<h3>CVV Can't be Empty!</h3>");
                return;
            }
            try
            {
                if (TextBox4.Text != string.Empty)
                {
                    DateTime Date = DateTime.Parse(TextBox4.Text);
                    addCreditCard.Parameters.Add(new SqlParameter("@expiryDate ", Date));
                }
                else
                {
                    Response.Write("<h3>Expiry Date Can't be Empty!</h3>");
                    return;
                }
            }
            catch (FormatException)
            {
                Response.Write("<h3>Deadline should be a Date in the Form (YYYY-MM-DD)!</h3>");
                return;
            }







            try
            {
                conn.Open();
                addCreditCard.ExecuteNonQuery();
                Response.Write("<h3>Credit Card Added!</h3>");
                conn.Close();


            }
            catch (SqlException)
            {
             

               Response.Write("<h3>This Credit Card already exists!</h3>");

            }


        }
    }
}