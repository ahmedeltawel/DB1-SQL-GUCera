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
    public partial class ViewFeedback : System.Web.UI.Page
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

        protected void View_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand View = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
            SqlCommand Avaliable = new SqlCommand("AdminViewCourseDetails", conn);
            SqlCommand Check = new SqlCommand("InstructorViewAcceptedCoursesByAdmin", conn);
            View.CommandType = CommandType.StoredProcedure;
            Avaliable.CommandType = CommandType.StoredProcedure;
            Check.CommandType = CommandType.StoredProcedure;
        


            try
            {
                if (CourseID.Text != string.Empty)
                {
                    int id = Int16.Parse(CourseID.Text);
                    View.Parameters.Add(new SqlParameter("@cid", id));
                    Avaliable.Parameters.Add(new SqlParameter("@courseId", id));
                }
                else
                {
                    Response.Write("<h3>Course ID Can't be Empty!</h3>");
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Course ID should be Number!</h3>");
                return;
            }


            View.Parameters.Add(new SqlParameter("@instrId", Session["user"]));
            Check.Parameters.Add(new SqlParameter("@instrId", Session["user"]));


            conn.Open();
            SqlDataReader av = Avaliable.ExecuteReader(CommandBehavior.CloseConnection);
            

            if (!av.HasRows)
            {
                Response.Write("<h3>Invalid Course ID!!</h3>");
                return;
            }



            conn.Close();
            conn.Open();
            SqlDataReader chk = Check.ExecuteReader(CommandBehavior.CloseConnection);

            bool flag = false;
            while (chk.Read())
            {
                int cid = chk.GetInt32(chk.GetOrdinal("id"));
                if (cid == Int16.Parse(CourseID.Text))
                {
                    flag = true;
                }

            }

            if (!flag)
            {
                Response.Write("<h3>Course Not Yet Accepted or taught by Another Instructor </h3>");
                return;
            }


            conn.Close();
            conn.Open();
            SqlDataReader rdr = View.ExecuteReader(CommandBehavior.CloseConnection);



            if (!rdr.HasRows)
            {
                Response.Write("<h3>No Feedbacks Submitted Yet!!</h3>");
            }




            while (rdr.Read())
            {
                


                int FeedbackNumber = rdr.GetInt32(rdr.GetOrdinal("number"));
                Label number = new Label();
                number.Text = "<br> Feedback Number:" + FeedbackNumber + "<br>";
                form1.Controls.Add(number);


                String Comment = rdr.GetString(rdr.GetOrdinal("comment"));
                Label C = new Label();
                C.Text = "Comment:" + Comment + "<br>";
                form1.Controls.Add(C);

                int numberOfLikes = rdr.GetInt32(rdr.GetOrdinal("numberOfLikes"));
                Label Likes = new Label();
                Likes.Text = "Number of Likes:" + numberOfLikes + "<br>";
                form1.Controls.Add(Likes);



            }

        }


    }
}
