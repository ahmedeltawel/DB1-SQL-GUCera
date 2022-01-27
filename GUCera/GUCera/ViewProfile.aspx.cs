using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace GUCera
{
    public partial class ViewProfile : System.Web.UI.Page
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

            try { 
            //Mahmoud was here 
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand ViewProfile = new SqlCommand("viewMyProfile", conn);

            ViewProfile.CommandType = CommandType.StoredProcedure;

            ViewProfile.Parameters.Add(new SqlParameter("@id", (int)(Session["user"])));

            conn.Open();

            SqlDataReader rdr = ViewProfile.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    int ID = (int)(Session["user"]);
                    string fn = rdr.GetString(rdr.GetOrdinal("firstName"));
                    string ln = rdr.GetString(rdr.GetOrdinal("lastName"));
                    string pass = rdr.GetString(rdr.GetOrdinal("password"));

                    Boolean gender = rdr.GetBoolean(rdr.GetOrdinal("gender"));
                    string gen = gender == false ? "Man" : "Female";

                    string email = rdr.GetString(rdr.GetOrdinal("email"));
                    string addrese = rdr.GetString(rdr.GetOrdinal("address"));

                    Label Id = new Label();
                    Label Fn = new Label();
                    Label Ln = new Label();
                    Label Pass = new Label();
                    Label gendr = new Label();
                    Label mail = new Label();
                    Label addrs = new Label();

                    Id.Text = "ID: " + ID + "<br>";
                    Fn.Text = "First name: " + fn + "<br>";
                    Ln.Text = "Last name " + ln + "<br>";
                    Pass.Text = "Password: " + pass + "<br>";
                    gendr.Text = "Gender: " + gen + "<br>";
                    mail.Text = "Email: " + email + "<br>";
                    addrs.Text = "Address: " + addrese + "<br>";

                    form1.Controls.Add(Id);
                    form1.Controls.Add(Fn);
                    form1.Controls.Add(Ln);
                    form1.Controls.Add(Pass);
                    form1.Controls.Add(gendr);
                    form1.Controls.Add(mail);
                    form1.Controls.Add(addrs);

                    //-----------

                }
            }
               
            catch (SqlException) 
            {

                Response.Write("Error occured please try again");
            
            }



           
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
    }
}