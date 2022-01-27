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
    public partial class DefineAssignment : System.Web.UI.Page
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

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instructor.aspx");
        }

        protected void Define_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand DefAssign = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
            DefAssign.CommandType = CommandType.StoredProcedure;





            int id = (int)Session["user"];
            DefAssign.Parameters.Add(new SqlParameter("@instId", id));


            try
            {
                if (TextBox1.Text != string.Empty)
                {
                    int cid = Int32.Parse(TextBox1.Text);
                    DefAssign.Parameters.Add(new SqlParameter("@cid ", cid));
                }
                else
                {
                    Response.Write("<h3>Course ID Can't be Empty!!</h3>");
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Course ID should be Number!</h3>");
                return;
            }




            try
            {
                if (TextBox2.Text != string.Empty)
                {
                    int number = Int32.Parse(TextBox2.Text);
                    DefAssign.Parameters.Add(new SqlParameter("@number ", number));
                }
                else
                {
                    Response.Write("<h3>Assignment Number Can't be Empty!</h3>");
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Assignment Number should be Number!</h3>");
                return;
            }



            string f = (type.SelectedValue);
            DefAssign.Parameters.Add(new SqlParameter("@type ", f));



            try
            {
                if (TextBox3.Text != string.Empty)
                {
                    int fullGrade = Int32.Parse(TextBox3.Text);
                    DefAssign.Parameters.Add(new SqlParameter("@fullGrade ", fullGrade));
                }
                else
                {
                    Response.Write("<h3>Full Grade Can't be Empty!</h3>");
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Full Grade should be Number!</h3>");
                return;
            }




            try
            {
                if (TextBox4.Text != string.Empty)
                {
                    double weight = Double.Parse(TextBox4.Text);
                    DefAssign.Parameters.Add(new SqlParameter("@weight ", weight));
                }
                else
                {
                    Response.Write("<h3>Weight Can't be Empty!</h3>");
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Weight should be Number!</h3>");
                return;
            }




            if (TextBox5.Text != string.Empty)
            {
                string content = TextBox5.Text;
                DefAssign.Parameters.Add(new SqlParameter("@content ", content));
            }
            else
            {
                Response.Write("<h3>Content Can't be Empty!</h3>");
                return;
            }




            try
            {
                if (TextBox6.Text != string.Empty)
                {
                    DateTime Date = DateTime.Parse(TextBox6.Text);
                    var CheckDate = DateTime.Parse(TextBox6.Text);
                    var todaysDate = DateTime.Today;
                    if (CheckDate > todaysDate)
                    DefAssign.Parameters.Add(new SqlParameter("@deadline ", Date));
                    else
                    {
                        Response.Write("<h3>Deadline Must be After Today's Date!!</h3>");
                        return;
                    }

                }
                else
                {
                    Response.Write("<h3>Deadline Can't be Empty!</h3>");
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
                DefAssign.ExecuteNonQuery();
                conn.Close();
                Response.Write("<h3>Assignment Added!</h3>");
            }
            catch (SqlException x)
            {
                if(x.Number == 2627)
                    Response.Write("<h3>Assignment Already Added Before!!</h3>");
                else
                Response.Write("<h3>Course Not in Your Assigned Courses!</h3>");

            }




        }
    }
}
