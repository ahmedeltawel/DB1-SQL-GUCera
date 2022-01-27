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
    public partial class ViewSubmissions : System.Web.UI.Page
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


            SqlCommand View = new SqlCommand("InstructorViewAssignmentsStudents", conn);
            SqlCommand Avaliable = new SqlCommand("AdminViewCourseDetails", conn);
            SqlCommand Check = new SqlCommand("InstructorViewAcceptedCoursesByAdmin", conn);
            View.CommandType = CommandType.StoredProcedure;
            Avaliable.CommandType = CommandType.StoredProcedure;
            Check.CommandType = CommandType.StoredProcedure;



            View.Parameters.Add(new SqlParameter("@instrId", (int)Session["user"]));
            Check.Parameters.Add(new SqlParameter("@instrId",(int) Session["user"]));


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
                Response.Write("<h3>No Assignments Submitted Yet!!</h3>");
             }


            while (rdr.Read())
            {

                int sid = rdr.GetInt32(rdr.GetOrdinal("sid"));
                Label sidd = new Label();
                sidd.Text = "<br> Student ID:" + sid + "<br>";
                form2.Controls.Add(sidd);

                int cid = rdr.GetInt32(rdr.GetOrdinal("cid"));
                Label cidd = new Label();
                cidd.Text = " Course ID:" + cid + "<br>";
                form2.Controls.Add(cidd);

                int AssignNumber = rdr.GetInt32(rdr.GetOrdinal("assignmentNumber"));
                Label number = new Label();
                number.Text = "Number:" + AssignNumber + "<br>";
                form2.Controls.Add(number);


                String Assigntype = rdr.GetString(rdr.GetOrdinal("assignmenttype"));
                Label type = new Label();
                type.Text = "Type:" + Assigntype + "<br>";
                form2.Controls.Add(type);

                if (rdr["grade"] != DBNull.Value)
                {
                    decimal grade = rdr.GetDecimal(rdr.GetOrdinal("grade"));
                    Label Fullgrade = new Label();
                    Fullgrade.Text = "Grade:" + grade + "<br>";
                    form2.Controls.Add(Fullgrade);
                }






            }

        }


    }
}
    