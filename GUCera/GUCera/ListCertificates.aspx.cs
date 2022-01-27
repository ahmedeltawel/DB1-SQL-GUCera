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
    public partial class ListCertificates : System.Web.UI.Page
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

        protected void Viewassign_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand ViewCert = new SqlCommand("viewCertificate", conn);
            ViewCert.CommandType = CommandType.StoredProcedure;

            try
            {
                if (TextBox1.Text != string.Empty)
                {
                    int cid = Int16.Parse(TextBox1.Text);
                    ViewCert.Parameters.Add(new SqlParameter("@cid", cid));
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
            catch (SqlException)
            {
                Response.Write("<h3>Course ID is invalid</h3>");
                return;
            }

            int sid = (int)Session["user"];
            ViewCert.Parameters.Add(new SqlParameter("@sid", sid));


            conn.Open();
            SqlCommand command1 =
    new SqlCommand("SELECT name FROM dbo.Course WHERE id=@id"
    , conn);
            command1.Parameters.AddWithValue("@id", Int16.Parse(TextBox1.Text));


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
            command2.Parameters.AddWithValue("@cid", Int16.Parse(TextBox1.Text));

            command2.Parameters.AddWithValue("@sid", (int)Session["user"]); 


            SqlDataReader read2 = command2.ExecuteReader();
            if (!read2.HasRows)
            {
                Response.Write("<h3>You are not enrolled in this course!!</h3>");
                return;
            }
            conn.Close();

           
            conn.Open();
            SqlDataReader rdr = ViewCert.ExecuteReader(CommandBehavior.CloseConnection);
            if (!rdr.HasRows)
            {
                Response.Write("<h3>Course ID has no Certificates!!</h3>");

            }
            while (rdr.Read())
            {
                int sid1 = (int)Session["user"];
                Label sidd = new Label();
                sidd.Text = "<br> Student ID:" + sid1 + "<br>";
                form1.Controls.Add(sidd);

                int cid = Int32.Parse(TextBox1.Text);
                Label cidd = new Label();
                cidd.Text = "Course ID:" + cid + "<br>";
                form1.Controls.Add(cidd);

                DateTime Assigndeadline = rdr.GetDateTime(rdr.GetOrdinal("issueDate"));
                Label deadline = new Label();
                deadline.Text = "Issue Date:" + Assigndeadline + "<br>";
                form1.Controls.Add(deadline);

            }
        }
    }
}