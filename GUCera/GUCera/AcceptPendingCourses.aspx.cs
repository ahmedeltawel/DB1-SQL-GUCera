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
    public partial class AcceptPendingCourses : System.Web.UI.Page
    {
        
        SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString());

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

            SqlCommand AdminViewNonAcceptedCourses = new SqlCommand("AdminViewNonAcceptedCourses", conn);
            AdminViewNonAcceptedCourses.CommandType = CommandType.StoredProcedure;
            DataTable y = new DataTable("MyTable");
            y.Columns.Add("Course name");
            y.Columns.Add("Credit hour");
            y.Columns.Add("price");
            y.Columns.Add("content");
            try
            {
                conn.Open();
                SqlDataReader rdr = AdminViewNonAcceptedCourses.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {



                    String CourseName = rdr.GetString(rdr.GetOrdinal("name"));
                    Int32 creditHours = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                    Decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                    if ((rdr.IsDBNull(rdr.GetOrdinal("content"))))
                    {//contenet is null
                        y.Rows.Add(CourseName, creditHours, price, null);
                    }
                    else if (!(rdr.IsDBNull(rdr.GetOrdinal("content"))))
                    {//contenet is not null
                        String content = rdr.GetString(rdr.GetOrdinal("content"));
                        y.Rows.Add(CourseName, creditHours, price, content);
                    }







                }


                GridView1.DataSource = y;


                GridView1.DataBind();
                Button b = new Button();
                // GridView1.Rows[0].Cells[1].
                // if (!Page.IsPostBack)
                //   {

                //}
               // Response.Write(e.ToString());
                AdminViewNonAcceptedCourses.ExecuteNonQuery();

                conn.Close();


            }
            catch (Exception)
            {

            }

        }

     

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void GridView1_SelectedIndexChanged4(object sender, EventArgs e)
        {
            Response.Write("Admin.aspx");
        }
     

      
     

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {//used to accept any added courses 



            //AdminAcceptRejectCourse
            try
            {
                int i = e.RowIndex;
                String coursename = (String)Convert.ToString(GridView1.Rows[i].Cells[1].Text);

                SqlCommand getCourseID = new SqlCommand("getCourseID", conn);
                getCourseID.CommandType = CommandType.StoredProcedure;
              

                getCourseID.Parameters.Add(new SqlParameter("@coursename", coursename));
                SqlParameter courseID = getCourseID.Parameters.Add("@courseID", SqlDbType.Int);

                courseID.Direction = ParameterDirection.Output;
              
              //  getCourseID.ExecuteNonQuery();


                conn.Close();
                conn.Open();
                getCourseID.ExecuteNonQuery();
                conn.Close();


               // Response.Write(Convert.ToInt32(courseID.Value));
                conn.Open();
                SqlCommand AdminAcceptRejectCourse = new SqlCommand("AdminAcceptRejectCourse", conn);
                AdminAcceptRejectCourse.CommandType = CommandType.StoredProcedure;
                AdminAcceptRejectCourse.Parameters.Add(new SqlParameter("@adminid", (int)Session["user"])); // for current moment only
                AdminAcceptRejectCourse.Parameters.Add(new SqlParameter("@courseId", Convert.ToInt32(courseID.Value)));


                conn.Close();
                conn.Open();
                AdminAcceptRejectCourse.ExecuteNonQuery();
                Response.Write("Course Accepted Successfully!!");
                conn.Close();
                GridView1.DataBind();


                SqlCommand AdminViewNonAcceptedCourses = new SqlCommand("AdminViewNonAcceptedCourses", conn);
                AdminViewNonAcceptedCourses.CommandType = CommandType.StoredProcedure;
                DataTable y = new DataTable("MyTable");
                y.Columns.Add("Course name");
                y.Columns.Add("Credit hour");
                y.Columns.Add("price");
                y.Columns.Add("content");
                try
                {
                    conn.Open();
                    SqlDataReader rdr = AdminViewNonAcceptedCourses.ExecuteReader(CommandBehavior.CloseConnection);

                    while (rdr.Read())
                    {



                        String CourseName = rdr.GetString(rdr.GetOrdinal("name"));
                        Int32 creditHours = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                        Decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                        if ((rdr.IsDBNull(rdr.GetOrdinal("content"))))
                        {//contenet is null
                            y.Rows.Add(CourseName, creditHours, price, null);
                        }
                        else if (!(rdr.IsDBNull(rdr.GetOrdinal("content"))))
                        {//contenet is not null
                            String content = rdr.GetString(rdr.GetOrdinal("content"));
                            y.Rows.Add(CourseName, creditHours, price, content);
                        }







                    }


                    GridView1.DataSource = y;


                    GridView1.DataBind();
                    Button b = new Button();
                    // GridView1.Rows[0].Cells[1].
                    // if (!Page.IsPostBack)
                    //   {

                    //}
                    // Response.Write(e.ToString());
                    AdminViewNonAcceptedCourses.ExecuteNonQuery();

                    conn.Close();


                }
                catch (Exception)
                {

                }















            }
            catch (Exception)
            {
                Response.Write("There's no courses to Accept !!");
            }

         
        }
    }
}