using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Admin : System.Web.UI.Page
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
                SqlCommand command1 = new SqlCommand("SELECT id FROM dbo.Admin ", conn);
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

        protected void ListAllCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListAllCourses.aspx");
        }

        protected void PendingCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendingCourses.aspx");
        }

        protected void AcceptPendingCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcceptPendingCourses.aspx");
        }

        protected void CreatePromoCodes_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreatePromoCodes.aspx");
        }
        protected void IssuePromoCode_Click(object sender, EventArgs e)
        {
            Response.Redirect("IssuePromoCode.aspx");
        }
        protected void AddMobileNumber_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMobile.aspx");
        }
    }
}