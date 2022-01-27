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
    public partial class IssueCertificate : System.Web.UI.Page
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

        protected void Issue_Click(object sender, EventArgs e)
        {

            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand Avaliable = new SqlCommand("AdminViewCourseDetails", conn);
            SqlCommand IssueCertificate = new SqlCommand("InstructorIssueCertificateToStudent", conn);
            
            IssueCertificate.CommandType = CommandType.StoredProcedure;
            Avaliable.CommandType = CommandType.StoredProcedure;



        

            try
            {
                if (TextBox1.Text != string.Empty)
                {
                    int cid = Int16.Parse(TextBox1.Text);
                    IssueCertificate.Parameters.Add(new SqlParameter("@cid", cid));
                    Avaliable.Parameters.Add(new SqlParameter("@courseId", cid));
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
                if (TextBox2.Text != string.Empty)
                {
                    int sid = Int16.Parse(TextBox2.Text);
                    IssueCertificate.Parameters.Add(new SqlParameter("@sid", sid));
                }
                else
                {
                    Response.Write("<h3>Student ID Can't be Empty!</h3>");
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Student ID should be Number!</h3>");
                return;
            }



            IssueCertificate.Parameters.Add(new SqlParameter("@insId", Session["user"]));



            try
            {
                if (TextBox4.Text != string.Empty)
                {
                     DateTime Date = DateTime.Parse(TextBox4.Text);
                    var CheckDate = DateTime.Parse(TextBox4.Text);
                    var todaysDate = DateTime.Today;
                    if (CheckDate > todaysDate)
                    IssueCertificate.Parameters.Add(new SqlParameter("@deadline ", Date));
                    else
                    {
                        Response.Write("<h3>Deadline Must be After Today's Date!!</h3>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<h3>Issue Date Can't be Empty!</h3>");
                    return;
                }
            }
            catch (FormatException)
            {
                Response.Write("<h3>Issue Date should be a Date in the Form (YYYY-MM-DD)!</h3>");
                return;
            }


            conn.Open();
            SqlDataReader av = Avaliable.ExecuteReader(CommandBehavior.CloseConnection);
            
            if (!av.HasRows)
            {
                Response.Write("<h3>Invalid Course ID or Course not Yet Accepted by Admin!!</h3>");
                return;
            }


            conn.Close();

            try { 
                conn.Open();
                IssueCertificate.ExecuteNonQuery();
                conn.Close();
                Response.Write("<h3>You have successfully issued the Certificate </h3>");
            }
            catch (SqlException x)
            {
                //Response.Write(x.Number);
                if(x.Number==2627)
                Response.Write("<h3> You have already issued the Certificate</h3>");
                else if (x.Number==50000)
                  Response.Write("<h3>Can not Issue Certificate! <br> Student not enrolled in Course or Grade less than 2!! </h3>");
           else
        Response.Write("<h3>Can not Issue Certificate!  </h3>");
            }
        }



        }

    }



