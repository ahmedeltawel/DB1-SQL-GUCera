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
    public partial class EnrollCourse : System.Web.UI.Page
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            try { 
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand enrollInCourse = new SqlCommand("enrollInCourse", conn);
            enrollInCourse.CommandType = CommandType.StoredProcedure;
            int i = 0;
            var messages = new List<string>();

            conn.InfoMessage += (s, a) =>
            {
                i = 1;
                if (a.Message.Contains("not"))
                {

                    messages.Add(a.Message);
                    Response.Write("<h3>" + messages.First() + "</h3>");

                }


            };

                try
                {

                //id in session ok but is cid & Ins_ID in session also or input for now we do it as input?
                
                
                enrollInCourse.Parameters.Add(new SqlParameter("@sid", (int)Session["user"]));

                    if (cid.Text != string.Empty)
                    {
                        int Cid = Int16.Parse(cid.Text);
                        enrollInCourse.Parameters.Add(new SqlParameter("@cid", Cid));
                    }
                    else
                    {
                        Response.Write("<h3>Course ID Can't be Empty!</h3>");
                        return;
                    }
                }
                catch (FormatException)
                {
                    Response.Write("<h3>Course ID should be a Number!</h3>");
                    return;
                }

                try
                {
                
                    if (InsID.Text != string.Empty)
                    {
                    int Ins_ID = Int16.Parse(InsID.Text);
                    enrollInCourse.Parameters.Add(new SqlParameter("@instr", Ins_ID));
                    }
                    else
                    {
                        Response.Write("<h3>Instructor ID Can't be Empty!</h3>");
                        return;
                    }
                 }
                 catch (FormatException)
                {
                    Response.Write("<h3>Instructor ID should be a Number!</h3>");
                    return;
                }

                conn.Open();
                SqlCommand command1 =
        new SqlCommand("SELECT name FROM dbo.Course WHERE id=@id"
        , conn);
                command1.Parameters.AddWithValue("@id", Int16.Parse(cid.Text));


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
                command2.Parameters.AddWithValue("@cid", Int16.Parse(cid.Text));

                command2.Parameters.AddWithValue("@sid",(int)Session["user"]);


                SqlDataReader read2 = command2.ExecuteReader();
                if (read2.HasRows)
                {
                    Response.Write("<h3>You are enrolled in this Course!!</h3>");
                    return;
                }
                conn.Close();



                conn.Open();
                enrollInCourse.ExecuteNonQuery();
                if (i == 0)
                {
                    Response.Write("<h3> Enrolled Successfully!! </h3>");
                    i = 0;
                }
                conn.Close();


            }

            
            catch (SqlException) {

                Response.Write("You are already enrolled in this Course!!");

            }

        }
    }
}