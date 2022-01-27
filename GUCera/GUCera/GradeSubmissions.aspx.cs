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
    public partial class GradeSubmissions : System.Web.UI.Page
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

        protected void Grade_Click(object sender, EventArgs e)
        {


            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand GradeSub = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
            GradeSub.CommandType = CommandType.StoredProcedure;






            int id = (int)Session["user"];
            GradeSub.Parameters.Add(new SqlParameter("@instrId", id));


            try
            {
                if (TextBox1.Text != string.Empty)
                {
                    int sid = Int32.Parse(TextBox1.Text);
                    GradeSub.Parameters.Add(new SqlParameter("@sid ", sid));
                }
                else
                {
                    Response.Write("<h3>Student ID Can't be Empty!!</h3>");
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Student ID should be Number!</h3>");
                return;
            }




            try
            {
                if (TextBox2.Text != string.Empty)
                {
                    int cid = Int32.Parse(TextBox2.Text);
                    GradeSub.Parameters.Add(new SqlParameter("@cid ", cid));
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



            try
            {
                if (TextBox3.Text != string.Empty)
                {
                    int number = Int32.Parse(TextBox3.Text);
                    GradeSub.Parameters.Add(new SqlParameter("@assignmentNumber ", number));
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
            GradeSub.Parameters.Add(new SqlParameter("@type ", f));




            try
            {
                if (TextBox4.Text != string.Empty)
                {
                    decimal weight = Decimal.Parse(TextBox4.Text);
                    GradeSub.Parameters.Add(new SqlParameter("@grade ", weight));
                }
                else
                {
                    Response.Write("<h3>Grade Can't be Empty!</h3>");
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Grade should be Number!</h3>");
                return;
            }

      


            conn.Open();
            SqlCommand command1 =
    new SqlCommand("SELECT payedfor FROM dbo.StudentTakeCourse WHERE sid=@sid"
    , conn);
            command1.Parameters.AddWithValue("@sid", Int16.Parse(TextBox1.Text));


            SqlDataReader read1 = command1.ExecuteReader();
            if (!read1.HasRows)
            {
                Response.Write("<h3>Student ID is Invalid!!</h3>");
                return;
            }
            conn.Close();





            conn.Open();
            SqlCommand command =
    new SqlCommand("SELECT payedfor FROM dbo.StudentTakeCourse WHERE cid = @cid "
    , conn);
            command.Parameters.AddWithValue("@cid", Int16.Parse(TextBox2.Text));


            SqlDataReader read = command.ExecuteReader();
            if (!read.HasRows)
            {
                Response.Write("<h3>Course ID is Invalid!!</h3>");
                return;
            }
            conn.Close();



            conn.Open();
            SqlCommand command2 =
    new SqlCommand("SELECT payedfor FROM dbo.StudentTakeCourse WHERE cid = @cid AND sid=@sid"
    , conn);
            command2.Parameters.AddWithValue("@cid", Int16.Parse(TextBox2.Text));

            command2.Parameters.AddWithValue("@sid", Int16.Parse(TextBox1.Text));


            SqlDataReader read2 = command2.ExecuteReader();
            if (!read2.HasRows)
            {
                Response.Write("<h3>The Student is not enrolled in this Course!!</h3>");
                return;
            }
            conn.Close();




            conn.Open();
            SqlCommand command3 =
    new SqlCommand("SELECT type FROM dbo.Assignment WHERE cid = @cid AND number = @number"
    , conn);
            command3.Parameters.AddWithValue("@cid", Int16.Parse(TextBox2.Text));
            command3.Parameters.AddWithValue("@number", Int16.Parse(TextBox3.Text));


            SqlDataReader read3 = command3.ExecuteReader();
            if (!read3.HasRows)
            {
                Response.Write("<h3>Wrong Assignment Number!!</h3>");
                return;
            }
            conn.Close();


            conn.Open();
            SqlCommand command4 =
    new SqlCommand("SELECT type FROM dbo.Assignment WHERE cid = @cid AND number = @number AND type = @type "
    , conn);
            command4.Parameters.AddWithValue("@cid", Int16.Parse(TextBox2.Text));
            command4.Parameters.AddWithValue("@number", Int16.Parse(TextBox3.Text));
            command4.Parameters.AddWithValue("@type", type.SelectedValue);



            SqlDataReader read4 = command4.ExecuteReader();
            if (!read4.HasRows)
            {
                Response.Write("<h3>Wrong Type!!</h3>");
                return;
            }

            conn.Close();





















            try
            { 
                conn.Open();
                GradeSub.ExecuteNonQuery();
                conn.Close();
                Response.Write("<h3>Grade Added Successfully!</h3>");
        }
            catch (SqlException)
            {
                    Response.Write("<h3>Student haven't submit Assignment or not Assigned to this Course!!</h3>");
            }









}
    }
}