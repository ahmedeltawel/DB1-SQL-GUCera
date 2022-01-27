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
    public partial class ViewPromo : System.Web.UI.Page
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
                SqlCommand command1 = new SqlCommand("SELECT id FROM dbo.Student ", connn);
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

            //mahmoud was here 
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand viewPromocode = new SqlCommand("viewPromocode", conn);
            viewPromocode.CommandType = CommandType.StoredProcedure;

            
            

                //id in session

                viewPromocode.Parameters.Add(new SqlParameter("@sid", (int)Session["user"]));
                conn.Open();

                SqlDataReader rdr = viewPromocode.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {


                string code = rdr.GetString(rdr.GetOrdinal("code"));
                Label C = new Label();
                C.Text = "<br> Code: " + code + "<br>";
                form1.Controls.Add(C);

                  DateTime issuedate = rdr.GetDateTime(rdr.GetOrdinal("isuueDate"));
                  Label date = new Label();
                  date.Text = "Issue Date: " + issuedate + "<br>";
                  form1.Controls.Add(date);

                   DateTime expiry = rdr.GetDateTime(rdr.GetOrdinal("expiryDate"));
                 Label Exdate = new Label();
                 Exdate.Text = "Expiry Date: " + expiry + "<br>";
                  form1.Controls.Add(Exdate);

                if (rdr["discount"] != DBNull.Value)
                {

                
                decimal discount = rdr.GetDecimal(rdr.GetOrdinal("discount"));
                Label dis = new Label();
                dis.Text = "Discount: " + discount + "<br>";
                form1.Controls.Add(dis);
                 }

                

               
            }

            


                    //Response.Write("Failed");

                
            

            
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

       
    }
}