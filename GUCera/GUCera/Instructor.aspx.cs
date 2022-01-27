using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Instructor : System.Web.UI.Page
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

        protected void AddCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }

        protected void DefineAssignment_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefineAssignment.aspx");
        }

        protected void ViewSubmissions_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewSubmissions.aspx");
        }

        protected void ViewFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewFeedback.aspx");
        }

        protected void IssueCertificate_Click(object sender, EventArgs e)
        {
            Response.Redirect("IssueCertificate.aspx");
        }

        protected void GradeSubmissions_Click(object sender, EventArgs e)
        {
            Response.Redirect("GradeSubmissions.aspx");
        }

        protected void AddMobileNumber_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMobile.aspx");
        }
    }
}