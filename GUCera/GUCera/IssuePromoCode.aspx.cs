using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace GUCera
{
    public partial class IssuePromoCode : System.Web.UI.Page
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
                SqlCommand command11 = new SqlCommand("SELECT id FROM dbo.Admin ", connn);
                SqlDataReader read11 = command11.ExecuteReader();
                Boolean f = false;
                while (read11.Read())
                {
                    if ((int)Session["user"] == read11.GetInt32(read11.GetOrdinal("id")))
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
            DataTable y = new DataTable("MyTable");
            y.Columns.Add("Student Id");
            y.Columns.Add("First name");
            y.Columns.Add("Last name");
            conn.Open();
            SqlCommand command =
    new SqlCommand("SELECT firstName,lastName,s.id FROM dbo.Users u inner join dbo.Student s on u.id = s.id"
    , conn);


            SqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                Int32 sid = rdr.GetInt32(rdr.GetOrdinal("id"));

                if (rdr.IsDBNull(rdr.GetOrdinal("firstName")) && (rdr.IsDBNull(rdr.GetOrdinal("lastName"))))
                {//both null               
                    y.Rows.Add(sid, null, null);
                }
                else if (!rdr.IsDBNull(rdr.GetOrdinal("firstName")) && (rdr.IsDBNull(rdr.GetOrdinal("lastName"))))
                { // only lastName is null
                    String firstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                    y.Rows.Add(sid, firstName, null);

                }

                else if (rdr.IsDBNull(rdr.GetOrdinal("firstName")) && (!rdr.IsDBNull(rdr.GetOrdinal("lastName"))))
                { // only firstName is null
                    String lastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                    y.Rows.Add(sid, null, lastName);

                }
                else if (!rdr.IsDBNull(rdr.GetOrdinal("firstName")) && (!rdr.IsDBNull(rdr.GetOrdinal("lastName"))))
                { //none is null
                    String firstName = rdr.GetString(rdr.GetOrdinal("firstName"));
                    String lastName = rdr.GetString(rdr.GetOrdinal("lastName"));
                    y.Rows.Add(sid, firstName, lastName);
                    //AllCourses.Text = CourseName + " " + creditHours + " " + price + " " + content + " " + accepted;
                }
            }


            GridViewStudent.DataSource = y;
            GridViewStudent.DataBind();
            conn.Close();

         


                
         



            ////////////////////////////////////////////////////////////
           
            DataTable y2 = new DataTable("MyTable");

            y2.Columns.Add("code");
            y2.Columns.Add("isuueDate");
            y2.Columns.Add("expiryDate");
            y2.Columns.Add("discount");
            y2.Columns.Add("adminId");


            
                conn.Open();


            SqlCommand command1 =
new SqlCommand("SELECT code,isuueDate,expiryDate,discount,adminId FROM dbo.Promocode"
, conn);


            SqlDataReader rdr1 = command1.ExecuteReader();

            while (rdr1.Read())
                {



                    String code = rdr1.GetString(rdr1.GetOrdinal("code"));

                    DateTime isuueDate = rdr1.GetDateTime(rdr1.GetOrdinal("isuueDate"));

                    DateTime expiryDate = rdr1.GetDateTime(rdr1.GetOrdinal("expiryDate"));

                    Decimal discount = rdr1.GetDecimal(rdr1.GetOrdinal("discount"));

                    int adminId = rdr1.GetInt32(rdr1.GetOrdinal("adminId"));

                    y2.Rows.Add(code, isuueDate, expiryDate, discount, adminId);




                }
                GridViewPromo.DataSource = y2;
                GridViewPromo.DataBind();

            
          











        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {







        }

        protected void Issue_Promo_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand adminIssue = new SqlCommand("AdminIssuePromocodeToStudent", conn);
            adminIssue.CommandType = CommandType.StoredProcedure;
           
                if (Pid.Text != string.Empty)
                {
                    string id = (Pid.Text);
                    adminIssue.Parameters.Add(new SqlParameter("@pid", id));
                }
                else
                {
                    LabelPromo.Visible = true;
                    return;
                }

           
            try
            {
                if (Sid.Text != string.Empty)
                {
                    int sid = Int16.Parse(Sid.Text);
                    adminIssue.Parameters.Add(new SqlParameter("@sid", sid));
                    
                }
                else
                {
                    LabelStudent.Visible = true;
                    return;
                }

            }
            catch (FormatException)
            {
                Response.Write("<h3>Student ID should be Number!</h3>");
                return;
            }

            try
            {
                conn.Open();
                adminIssue.ExecuteNonQuery();
                conn.Close();
                Response.Write("<h3>Promo Code Added Successfully!</h3>");
            }
            catch (SqlException x)
            {
                if(x.Number == 2627)
                    Response.Write("<h3>Student Already has this Promo Code!!</h3>");
                else if(x.Number == 547)
                    Response.Write("<h3>Invalid Student ID or Promo Code!!</h3>");

            }




        }
    }
}