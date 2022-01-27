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
    public partial class PendingCourses : System.Web.UI.Page
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
                string connnStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

                SqlConnection connn = new SqlConnection(connnStr);

                connn.Open();
                SqlCommand command1 = new SqlCommand("SELECT id FROM dbo.Admin ", connn);
                SqlDataReader read1 = command1.ExecuteReader();
                Boolean f = false;
                while (read1.Read())
                {
                    if ((int)Session["user"] == read1.GetInt32(read1.GetOrdinal("id")))
                    {
                        f = true;
                    }

                }
                connn.Close();
                if (!f)
                {
                    Session["RegisterMessage"] = "<h3> You Must Login First!!</h3>";
                    Response.Redirect("Login.aspx");
                }
            }

            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand AdminViewNonAcceptedCourses = new SqlCommand("AdminViewNonAcceptedCourses", conn);
            AdminViewNonAcceptedCourses.CommandType = CommandType.StoredProcedure;
            DataTable y = new DataTable("MyTable");
            //   DataColumn column = new DataColumn();
            //  column.DataType = System.Type.GetType("System.Decimal");
            // column.AllowDBNull = false;
            //   column.ColumnName = "ahmed";
            y.Columns.Add("Course name");
            y.Columns.Add("Credit hour");
            y.Columns.Add("price");
            y.Columns.Add("content");
          

            // y.Columns.Add("accpeted");
            //y.Rows.Add("01", "asdasd"); //must contain at least one course to display

            // y.Columns.Add(column);
            //GridView1.DataSource = y;

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

        }

        
    }
}