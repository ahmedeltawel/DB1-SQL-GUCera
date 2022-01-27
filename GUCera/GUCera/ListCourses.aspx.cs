using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Web.Configuration;





namespace GUCera
{
    public partial class ListCourses : System.Web.UI.Page
    {
        private int CID;
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

            try
            {
            
                //Mahmoud was here
                string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand availableCourses = new SqlCommand("availableCourses", conn);

                availableCourses.CommandType = CommandType.StoredProcedure;

                conn.Open();

              SqlDataReader rdr = availableCourses.ExecuteReader(CommandBehavior.CloseConnection);
                if (!rdr.HasRows)
                {
                    Response.Write("No courses yet accepted by the admin !");
                }
                else
                {
                    
                    while (rdr.Read())
                    {
                        
                        string courseName = rdr.GetString(rdr.GetOrdinal("name"));
                        Label Fn = new Label();
                        Fn.Text = " <h3><br><br> Course Name: " + courseName + " </h3>";
                        form1.Controls.Add(Fn);

                        CID = rdr.GetInt32(rdr.GetOrdinal("id"));
                        Label cid = new Label();
                        cid.Text = "<h3> Course ID: " + CID + "</h3>";
                        form1.Controls.Add(cid);

                        Label Text = new Label();
                        Text.Text = "<h3> To Enroll, Click Enroll page and enter the course ID. <br> If you want to view the information of this course enter its ID </h3>";
                        form1.Controls.Add(Text);
                    }
                }
                
            }
            
            catch (FormatException)
            {
                Response.Write("No courses in accpted by the admin !");
            }
            catch (SqlException )
            {
                Response.Write("User not registered!");
            }
            catch (ThreadAbortException)
            {

                Response.Write("No courses in accpted by the admin !");


            }



        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

        protected void Enroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnrollCourse.aspx");
        }

        protected void View_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand courseInformation = new SqlCommand("courseInformation", conn);
            courseInformation.CommandType = CommandType.StoredProcedure;
            try
            {
                if (TextBox1.Text != string.Empty)
                {
                    int sid = Int32.Parse(TextBox1.Text);
                    courseInformation.Parameters.Add(new SqlParameter("@id", sid));
                }
                else
                {
                    Response.Write("<h3>Course ID Can't be Empty!!</h3>");
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Course ID should be a Number!</h3>");
                return;
            }

            

                   
                    conn.Open();
                    SqlDataReader rdr2 = courseInformation.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rdr2.Read())
                    {
                        Decimal price = rdr2.GetDecimal(rdr2.GetOrdinal("price"));
                        Label Price_label = new Label();
                        Price_label.Text = "<br> Price: " + price + "<br>";
                        form1.Controls.Add(Price_label);

                        int instructorId = rdr2.GetInt32(rdr2.GetOrdinal("instructorId"));
                        Label instructorId_lbl = new Label();
                        instructorId_lbl.Text = "Instructor ID: " + instructorId + "<br>";
                        form1.Controls.Add(instructorId_lbl);

                        int creditHours = rdr2.GetInt32(rdr2.GetOrdinal("creditHours"));
                        Label Credithours_Label = new Label();
                        Credithours_Label.Text = " Credit Hours: " + creditHours + "<br>";
                        form1.Controls.Add(Credithours_Label);

                        string courseDescription = rdr2.GetString(rdr2.GetOrdinal("courseDescription"));
                        Label Cd = new Label();
                        Cd.Text = "Course Description: " + courseDescription + "<br>";
                        form1.Controls.Add(Cd);

                        string Content = rdr2.GetString(rdr2.GetOrdinal("content"));
                        Label content_lbl = new Label();
                        content_lbl.Text = "Content: " + Content + "<br>";
                        form1.Controls.Add(content_lbl);

                        Boolean acceptState = rdr2.GetBoolean(rdr2.GetOrdinal("accepted"));
                        Label Accept_lbl = new Label();
                        Accept_lbl.Text = "Accepted: " + acceptState + "<br>";
                        form1.Controls.Add(Accept_lbl);

                        //}

                    }
                
               
            










        }

       
    }
}