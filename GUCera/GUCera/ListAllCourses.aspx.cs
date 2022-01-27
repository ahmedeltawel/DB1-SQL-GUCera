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
    public partial class ListAllCourses : System.Web.UI.Page
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
                string connStrr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

                SqlConnection connn = new SqlConnection(connStrr);

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
            SqlCommand viewAllCourses = new SqlCommand("AdminViewAllCourses", conn);
            viewAllCourses.CommandType = CommandType.StoredProcedure;
            DataTable y = new DataTable("MyTable");
         //   DataColumn column = new DataColumn();
          //  column.DataType = System.Type.GetType("System.Decimal");
           // column.AllowDBNull = false;
         //   column.ColumnName = "ahmed";
             y.Columns.Add("Course name");
             y.Columns.Add("Credit hour");
            y.Columns.Add("price");
             y.Columns.Add("content");
              y.Columns.Add("accpeted");
              //y.Rows.Add("01", "asdasd"); //must contain at least one course to display
            
           // y.Columns.Add(column);
            //GridView1.DataSource = y;
           
            try
            {
                conn.Open();
                SqlDataReader rdr = viewAllCourses.ExecuteReader(CommandBehavior.CloseConnection);
               
                while (rdr.Read())
                {



                    String CourseName = rdr.GetString(rdr.GetOrdinal("name"));
                    Int32 creditHours = rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                    Decimal price = rdr.GetDecimal(rdr.GetOrdinal("price"));
                    if (rdr.IsDBNull(rdr.GetOrdinal("accepted")) && (rdr.IsDBNull(rdr.GetOrdinal("content"))))
                    {//both null               
                     // AllCourses.Text = CourseName + " " + creditHours + " " + price + " null" + " " + "null";


                        y.Rows.Add(CourseName,creditHours,price,null,null);

                    }
                    else if (!rdr.IsDBNull(rdr.GetOrdinal("accepted")) && (rdr.IsDBNull(rdr.GetOrdinal("content"))))
                    { // only content is null
                        Boolean accepted = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                        // AllCourses.Text = CourseName + " " + creditHours + " " + price + " null" + " " + accepted;
                        y.Rows.Add(CourseName, creditHours, price, null, accepted);

                    }

                    else if (rdr.IsDBNull(rdr.GetOrdinal("accepted")) && (!rdr.IsDBNull(rdr.GetOrdinal("content"))))
                    { // only accepted is null
                        String content = rdr.GetString(rdr.GetOrdinal("content"));
                        //AllCourses.Text = CourseName + " " + creditHours + " " + price +" "+content + " " + "null";
                        y.Rows.Add(CourseName, creditHours, price, content, null);

                    }
                    else if (!rdr.IsDBNull(rdr.GetOrdinal("accepted")) && (!rdr.IsDBNull(rdr.GetOrdinal("content"))))
                    { //none is null
                        Boolean accepted = rdr.GetBoolean(rdr.GetOrdinal("accepted"));
                        String content = rdr.GetString(rdr.GetOrdinal("content"));
                        y.Rows.Add(CourseName, creditHours, price, content, accepted);

                        //AllCourses.Text = CourseName + " " + creditHours + " " + price + " " + content + " " + accepted;
                    }

                }
                GridView1.DataSource = y;
                GridView1.DataBind();
                viewAllCourses.ExecuteNonQuery();
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


 //<p>
       //   <asp:Label ID = "AllCourses" runat="server" Text=""></asp:Label>
       // </p>