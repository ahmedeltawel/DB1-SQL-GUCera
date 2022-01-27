using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class AddCourse : System.Web.UI.Page
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
                SqlCommand command1 = new SqlCommand("SELECT id FROM dbo.Instructor ", conn);
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

            InstrID.Text = "(Current ID = " + Session["user"] + ")";
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instructor.aspx");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand AddCourse = new SqlCommand("InstAddCourse", conn);
            AddCourse.CommandType = CommandType.StoredProcedure;




            if (TextBox1.Text != string.Empty)
            {
                    string name = TextBox1.Text;
                     AddCourse.Parameters.Add(new SqlParameter("@name", name));
            }
            else
            {
                Response.Write("<h3>Course Name Can't be Empty!</h3>");
                return;
            }

            try
            {
                if (TextBox2.Text != string.Empty)
                {
                    int creditHours = Int16.Parse(TextBox2.Text);
                    AddCourse.Parameters.Add(new SqlParameter("@creditHours", creditHours));
                }
                else
                {
                    Response.Write("<h3>CreditHour Can't be Empty!</h3>");
                    return;
                }
                
            }
            catch (FormatException)
            {
                Response.Write("<h3>creditHours should be Number!</h3>");
                return;
            }

            try
            {
                if (TextBox3.Text != string.Empty)
                {
                    decimal price = Decimal.Parse(TextBox3.Text);
                    AddCourse.Parameters.Add(new SqlParameter("@price", price));
                }
                else
                {
                    Response.Write("<h3>Price Can't be Empty!</h3>");
                    return;
                }
                
            }
            catch (FormatException)
            {
                Response.Write("<h3>Price should be a Number!</h3>");
                return;
            }

            try
            {
                if (TextBox4.Text != string.Empty)
                {
                    int id = Int16.Parse(TextBox4.Text);
                    AddCourse.Parameters.Add(new SqlParameter("@instructorId", id));
                    InstrID.Text = "Current Id = " + Session["user"];
                }
                else
                {
                    Response.Write("<h3>InstrID Can't be Empty!</h3>");
                    return;
                }
            }
            catch (FormatException)
            {
                Response.Write("<h3>InstrId should be a Number!</h3>");
                return;
            }


           



            try { 
                conn.Open();
                AddCourse.ExecuteNonQuery();
                conn.Close();
                Response.Write("<h3>Course Added Successfully!!</h3>");

            }
            catch (SqlException x)
            {
               // Response.Write(x.Number);
                if(x.Number == 515)
                    Response.Write("<h3>Couldn't Add Course! <br>Instructor ID doesn't exist</h3>");
                if (x.Number == 2627)
                    Response.Write("<h3>Course Already Added!</h3>");
                else
                {
                    Response.Write("<h3>Couldn't Add Course!</h3>");
                }
            }
           
             
        }

    }


}
