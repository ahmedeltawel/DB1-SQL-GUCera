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
    public partial class AddMobile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Session["RegisterMessage"] = "<h3> You Must Login First!!</h3>";
                Response.Redirect("Login.aspx");

            }
            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            object refUrl = ViewState["RefUrl"];
            if (refUrl != null)
            {
                Response.Redirect((string)refUrl);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            try
            {
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand addMobile = new SqlCommand("addMobile", conn);
                addMobile.CommandType = CommandType.StoredProcedure;

                int mobile = Int32.Parse(mobileNumber.Text);


                addMobile.Parameters.Add(new SqlParameter("@ID", Session["user"]));
                addMobile.Parameters.Add(new SqlParameter("@mobile_number", mobile));

                conn.Open();
                addMobile.ExecuteNonQuery();
                conn.Close();
                Response.Write("<h3>Mobile Number Added Successfully!!</h3>");
            }
            catch (FormatException)
            {
                Response.Write("<h3>Must Add a Number!</h3>");
            }
            
            catch (SqlException)
            {
                Response.Write("<h3>Phone Number Already Added!</h3>");
            }


        }
    }
}