using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace GUCera
{
    public partial class Student_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }

        protected void register(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand reg = new SqlCommand("studentRegister", conn);
    
            reg.CommandType = CommandType.StoredProcedure;
            
          
            // 0 male , 1 female
            bool gender = bool.Parse(SelectGender.SelectedValue);
            

               
              
                reg.Parameters.Add(new SqlParameter("@gender", gender));
          

            if (fname.Text != string.Empty)
            {
                string fn = fname.Text;
                reg.Parameters.Add(new SqlParameter("@first_name", fn));
            }
            else
            {
                Response.Write("<h3>First Name Can't be Empty!</h3>");
                return;
            }
            if (lname.Text != string.Empty)
            {
                string ln = lname.Text;
                reg.Parameters.Add(new SqlParameter("@last_name", ln));
            }
            else
            {
                Response.Write("<h3>Last Name Can't be Empty!</h3>");
                return;
            }
            if (Password1.Text != string.Empty)
            {
                string pass = Password1.Text;
                reg.Parameters.Add(new SqlParameter("@password", pass));
            }
            else
            {
                Response.Write("<h3>Password Can't be Empty!</h3>");
                return;
            }
            if (email.Text != string.Empty)
            {
                string mail = email.Text;
                reg.Parameters.Add(new SqlParameter("@email", mail));
            }
            else
            {
                Response.Write("<h3>Email Can't be Empty!</h3>");
                return;
            }

            if (address.Text != string.Empty)
            {
                string Ins_address = address.Text;
                reg.Parameters.Add(new SqlParameter("@address", Ins_address));
            }
            else
            {
                Response.Write("<h3>Address Can't be Empty!</h3>");
                return;
            }







            try
            {
                SqlCommand cmdzs = new SqlCommand("SELECT MAX (id) as ID FROM Users ", conn);
                cmdzs.CommandType = CommandType.Text;
                conn.Open();
                reg.ExecuteNonQuery();
                MessageBox.Show("Your ID is : "  +  cmdzs.ExecuteScalar().ToString());
                Session["RegisterMessage"] = "<h3> Registration Successful with ID : " + cmdzs.ExecuteScalar().ToString() + "</h3> ";
                conn.Close();


             

                Response.Redirect("Login.aspx", true);
            }
            catch(SqlException)
            {

                Response.Write("<h3> This Email already exists!! </h3>");

            }
        }
    }
}