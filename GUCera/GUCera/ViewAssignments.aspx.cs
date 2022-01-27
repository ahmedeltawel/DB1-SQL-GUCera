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
    public partial class ViewAssignments : System.Web.UI.Page
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

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

        protected void Viewassign_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand Viewassign = new SqlCommand("ViewAssign", conn);
            SqlCommand Avaliable = new SqlCommand("AdminViewCourseDetails", conn);
            Avaliable.CommandType = CommandType.StoredProcedure;
            Viewassign.CommandType = CommandType.StoredProcedure;

            try
            {
                if (TextBox1.Text != string.Empty)
                {
                    int cid = Int16.Parse(TextBox1.Text);
                    Viewassign.Parameters.Add(new SqlParameter("@courseId", cid));
                    Avaliable.Parameters.Add(new SqlParameter("@courseId", cid));
                }
                else
                {
                    Response.Write("<h3>Course ID Can't be Empty!</h3>");
                    return;
                }
            }
            catch (FormatException)
            {
                Response.Write("<h3>Course ID should be a Number!</h3>");
                return;
            }
            catch (SqlException)
            {
                Response.Write("<h3>Course ID is invalid</h3>");
                return;
            }

            int sid = (int)Session["user"];
            Viewassign.Parameters.Add(new SqlParameter("@Sid", sid));

            conn.Open();
            SqlDataReader av = Avaliable.ExecuteReader(CommandBehavior.CloseConnection);

            if (!av.HasRows)
            {
                Response.Write("<h3>Invalid Course ID!!</h3>");
                return;
            }


            conn.Close();

            conn.Open();
            SqlCommand command =
    new SqlCommand("SELECT payedfor FROM dbo.StudentTakeCourse WHERE cid = @cid And sid=@sid "
    , conn);
            command.Parameters.AddWithValue("@cid", Int16.Parse(TextBox1.Text));
            command.Parameters.AddWithValue("@sid",(int)Session["user"]);


            SqlDataReader read = command.ExecuteReader();
            if (!read.HasRows)
            {
                Response.Write("<h3>You are not enrolled in this Course!!</h3>");
                return;
            }
            conn.Close();

            conn.Open();
            SqlDataReader rdr = Viewassign.ExecuteReader(CommandBehavior.CloseConnection);
            if (!rdr.HasRows) {
                Response.Write("<h3>Course ID has no assignments</h3>");

            }


            while (rdr.Read()) {
                int cid = Int32.Parse(TextBox1.Text);
                Label cidd = new Label();
                cidd.Text = "<br> Course ID:" + cid + "<br>";
                form1.Controls.Add(cidd);

                int AssignNumber = rdr.GetInt32(rdr.GetOrdinal("number"));
                Label number = new Label();
                number.Text = "Number:" + AssignNumber + "<br>";
                form1.Controls.Add(number);

                String Assigntype = rdr.GetString(rdr.GetOrdinal("type"));
                Label type = new Label();
                type.Text = "Type:" + Assigntype + "<br>"; 
                form1.Controls.Add(type);

                int AssignFullgrade= rdr.GetInt32(rdr.GetOrdinal("FullGrade"));
                Label Fullgrade = new Label();
                Fullgrade.Text ="Full Grade:" + AssignFullgrade + "<br>"; 
                form1.Controls.Add(Fullgrade);

                decimal Assignweight = rdr.GetDecimal((rdr.GetOrdinal("weight")));
                Label weight = new Label();
                weight.Text ="Weight:" + Assignweight + "<br>"; 
                form1.Controls.Add(weight);

                DateTime Assigndeadline = rdr.GetDateTime(rdr.GetOrdinal("deadline"));
                Label deadline = new Label();
                deadline.Text ="Deadline:" + Assigndeadline + "<br>"; 
                form1.Controls.Add(deadline);

                String Assigncontent = rdr.GetString(rdr.GetOrdinal("content"));
                Label content = new Label();
                content.Text = "Content:" + Assigncontent + "<br>";
                form1.Controls.Add(content);









            }
        }

    }
}