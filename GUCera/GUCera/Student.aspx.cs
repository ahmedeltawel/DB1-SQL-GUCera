using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Student : System.Web.UI.Page
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

        protected void ViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProfile.aspx");
        }

        protected void ListCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListCourses.aspx");
        }

        protected void EnrollCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnrollCourse.aspx");
        }

        protected void AddCreditCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCreditCard.aspx");
        }

        protected void ViewPromo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPromo.aspx");
        }

        protected void ViewAssignments_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignments.aspx");
        }

        protected void SubmitAssignment_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubmitAssignment.aspx");
        }

        protected void ViewAssignmentGrades_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssignmentGrades.aspx");
        }

        protected void AddFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFeedback.aspx");
        }

        protected void ListCertificates_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListCertificates.aspx");
        }

        protected void AddMobile_Click(object sender, EventArgs e)
        {
                Response.Redirect("AddMobile.aspx");
        }
    }
}