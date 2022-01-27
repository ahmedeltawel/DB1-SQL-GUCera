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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Response.Write( Session["RegisterMessage"]);
        }
        protected void RegisterInstructor(object sender, EventArgs e)
        {
            Response.Redirect("Instructor Registration.aspx");

        }
        protected void RegisterStudent(object sender, EventArgs e)
        {
            Response.Redirect("Student Registration.aspx");

        }
   
        protected void login(object sender, EventArgs e)
        {
           
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            
            SqlCommand loginProc = new SqlCommand("userLogin", conn);
            loginProc.CommandType = CommandType.StoredProcedure;

     
            try
            {

                int id = Int32.Parse(txt_username.Text);
                HttpContext.Current.Session["user"] = id;
                
                string password = txt_password.Text;

                loginProc.Parameters.Add(new SqlParameter("@id", id));
                loginProc.Parameters.Add(new SqlParameter("@password", password));


                SqlParameter success = loginProc.Parameters.Add("@success", SqlDbType.Bit);
                SqlParameter type = loginProc.Parameters.Add("@type", SqlDbType.Int);

                success.Direction = ParameterDirection.Output;
                type.Direction = ParameterDirection.Output;

                conn.Open();
                loginProc.ExecuteNonQuery();
                conn.Close();

                if (type.Value.ToString().Equals("2") && success.Value.ToString().Equals("True"))
                {
                    Response.Redirect("Student.aspx", true);
                }
                else if (type.Value.ToString().Equals("0") && success.Value.ToString().Equals("True"))
                {
                    Response.Redirect("Instructor.aspx", true);
                }
                else if (type.Value.ToString().Equals("1") && success.Value.ToString().Equals("True"))
                {
                    Response.Redirect("Admin.aspx", true);
                }
                else if (type.Value.ToString().Equals("-1"))
                {
                    Response.Write("<h3>Incorrect ID or Password!</h3>");
                }
                else
                {
                    Response.Write("Failed");
                }
            }
            catch (SqlException )
            {   
                Response.Write("<h3>User not registered!</h3>");
            }
            catch (FormatException)
            {
                if(txt_username.Text == "")
                Response.Write("<h3>ID can not be Empty!</h3>");
                else if(txt_password.Text == "")
                    Response.Write("<h3>Password can not be Empty!</h3>");
                else
                    Response.Write("<h3>ID should be a number</h3>");
            }
        }

    }
}