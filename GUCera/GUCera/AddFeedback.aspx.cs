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
    public partial class AddFeedback : System.Web.UI.Page
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

        protected void Addfeed_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand AddFeedback = new SqlCommand("addFeedback", conn);
            
            AddFeedback.CommandType = CommandType.StoredProcedure;
            int id = (int)Session["user"];
            AddFeedback.Parameters.Add(new SqlParameter("@sid", id));
          

            try
            {
                if (CourseID.Text != string.Empty)
                {
                    int cid = Int16.Parse(CourseID.Text);
                    AddFeedback.Parameters.Add(new SqlParameter("@cid", cid));
                }
                else
                {
                    Response.Write("<h3>Course ID Can't be Empty!</h3>");
                    return;
                }
             
            }
            catch (FormatException)
            {
                Response.Write("<h3>Course ID Can't be Alphabets!</h3>");
                return;
            }
            catch (SqlException)
            {
                Response.Write("<h3>Course ID is invalid</h3>");
                return;
            }
            try
            {
                if (Comment.Text != string.Empty)
                {
                    string comment = Comment.Text;
                    AddFeedback.Parameters.Add(new SqlParameter("@comment ", comment));
                }
                else
                {
                    Response.Write("<h3>Comment Can't be Empty!</h3>");
                    return;
                }
            }
            catch (SqlException)
            {
                Response.Write("<h3>Comment can't have more than 100 characters!!</h3>");

            }
            var messages = new List<string>();
            int i = 0;

            conn.InfoMessage += (s, a) =>
            {
                i = 1;
                if (a.Message.Contains("not"))
                {

                    messages.Add(a.Message);
                    Response.Write("<h3>You are not enrolled in this course!!</h3>");

                }


            };
            conn.Open();
            SqlCommand command1 =
    new SqlCommand("SELECT name FROM dbo.Course WHERE id=@id"
    , conn);
            command1.Parameters.AddWithValue("@id", Int16.Parse(CourseID.Text));


            SqlDataReader read1 = command1.ExecuteReader();
            if (!read1.HasRows)
            {
                Response.Write("<h3>Course ID is Invalid!!</h3>");
                return;
            }   
            conn.Close();

            conn.Open();
            SqlCommand command2 =
    new SqlCommand("SELECT payedfor FROM dbo.StudentTakeCourse WHERE cid = @cid AND sid=@sid"
    , conn);
            command2.Parameters.AddWithValue("@cid", Int16.Parse(CourseID.Text));

            command2.Parameters.AddWithValue("@sid", (int)Session["user"]);


            SqlDataReader read2 = command2.ExecuteReader();
            if (!read2.HasRows)
            {
                Response.Write("<h3>You are not enrolled in this course!!</h3>");
                return;
            }
            conn.Close();
            try
            {
                conn.Open();
                AddFeedback.ExecuteNonQuery();
               
                conn.Close();
                if (i == 0)
                {
                    Response.Write("<h3>Feedback Added!</h3>");
                    i = 0;
                }
            }
            catch (SqlException x)
            {
                Response.Write(x.Message);
                Response.Write(x.Number);

                Response.Write("<h3>Couldn't Add Feedback!</h3>");
                
            }
        }
    }
}