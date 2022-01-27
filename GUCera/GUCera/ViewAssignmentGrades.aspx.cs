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
    public partial class ViewAssignmentGrades : System.Web.UI.Page
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

        protected void ViewGrade_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand ViewGrade = new SqlCommand("viewAssignGrades", conn);
            ViewGrade.CommandType = CommandType.StoredProcedure;


            //Done:Cid,Number,Fullgrade,content,id,datetime
            //Left:type

            int id = (int)Session["user"];
            ViewGrade.Parameters.Add(new SqlParameter("@sid", id));

            try
            {
                if (CourseID.Text != string.Empty)
                {
                    int cid = Int16.Parse(CourseID.Text);
                    ViewGrade.Parameters.Add(new SqlParameter("@cid ", cid));

                }
                else
                {
                    Response.Write("<h3>Course ID Can't be Empty!</h3>");
                    return;
                }
            }
            catch (FormatException)
            {
                Response.Write("<h3>Course ID Must be Numbers!</h3>");
                return;
            }
            catch (SqlException)
            {
                Response.Write("<h3>Course ID is invalid</h3>");
                return;
            }
            try
            {
                if (Number.Text != string.Empty)
                {
                    int number = Int16.Parse(Number.Text);
                    ViewGrade.Parameters.Add(new SqlParameter("@assignnumber ", number));
                }
                else
                {
                    Response.Write("<h3>Assignment Number Can't be Empty!</h3>");
                    return;
                }
            }
            catch (FormatException)
            {
                Response.Write("<h3>Assignment Number Must be Numbers!</h3>");
                return;
            }
            catch (SqlException)
            {
                Response.Write("<h3>Assignment Number is invalid</h3>");
                return;
            }
            ViewGrade.Parameters.Add(new SqlParameter("@assignType ", type.SelectedValue));
            SqlParameter g = ViewGrade.Parameters.Add("@assignGrade",SqlDbType.Decimal);

        


            g.Precision = 5;
            g.Scale = 2;

            g.Direction = ParameterDirection.Output;

           
      
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

            conn.Open();
            SqlCommand command3 =
    new SqlCommand("SELECT type FROM dbo.Assignment WHERE cid = @cid AND number = @number"
    , conn);
            command3.Parameters.AddWithValue("@cid", Int16.Parse(CourseID.Text));
            command3.Parameters.AddWithValue("@number", Int16.Parse(Number.Text));


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
            command4.Parameters.AddWithValue("@cid", Int16.Parse(CourseID.Text));
            command4.Parameters.AddWithValue("@number", Int16.Parse(Number.Text));
            command4.Parameters.AddWithValue("@type", (type.SelectedValue));



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
                ViewGrade.ExecuteNonQuery();
                conn.Close();
               
                if (g.Value == DBNull.Value)
                {
                    Response.Write("<h3> This Assignment isn't graded</h3>");
                    return;
                }
              
                    else
                    {
                        Response.Write("<h3> Your Grade is : " + g.Value + "</h3>");
                       
                    }
                
              


            }
            catch (SqlException x)
            {

                if (x.Number == 547)
                    Response.Write("<h3>Assignment doesn't exist!!</h3>");
                else if (x.Number == 2627)
                    Response.Write("<h3>Assignment Already Submitted!</h3>");
                else
                {
                    Response.Write("<h3>Couldn't Submit Assignment!</h3>");
                }
            }
        }
        }
}