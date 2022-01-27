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
    public partial class CreatePromoCodes : System.Web.UI.Page
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

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand AdminCreatePromocode = new SqlCommand("AdminCreatePromocode", conn);
            AdminCreatePromocode.CommandType = CommandType.StoredProcedure;


            SqlCommand day = new SqlCommand("SELECT  day(CURRENT_TIMESTAMP) ", conn);
            SqlCommand month = new SqlCommand("SELECT  month(CURRENT_TIMESTAMP) ", conn);
            SqlCommand year = new SqlCommand("SELECT  year(CURRENT_TIMESTAMP) ", conn);

            day.CommandType = CommandType.Text;
            month.CommandType = CommandType.Text;
            year.CommandType = CommandType.Text;
            conn.Open();
            //  AdminCreatePromocode.ExecuteNonQuery();
            int CurrentDay =Convert.ToInt16 (day.ExecuteScalar().ToString());
            int CurrentMonth = Convert.ToInt16(month.ExecuteScalar().ToString());
            int CurrentYear = Convert.ToInt16(year.ExecuteScalar().ToString());
            //Response.Write(CurrentDay);
            // Response.Write(CurrentMonth);
            // Response.Write(CurrentYear);
            int exYear2 = Int16.Parse(exYear.Text);
            int exMonth2= Int16.Parse(exMonth.Text);
            int exDay2 = Int16.Parse(exDay.Text);

            Boolean FCode = true;
            Boolean FDate = true;
             Boolean FDiscount = true;
            Boolean FAdminId = true;

            if (CurrentMonth > exMonth2)
            {
                WrongeMsg1.Text = "you cant chose this month!!";
                WrongeMsg1.Visible = true;
                FDate = false;
            }
            else if (CurrentMonth== exMonth2) {//must check that expiryday is before current current day
                if (CurrentDay > exDay2) {              
                    WrongeMsg1.Visible = true;
                    FDate = false;
                }
                else
                {
                    FDate = true;
                    WrongeMsg1.Visible = false;
                }


            }
            else
            {
                FDate = true;
                WrongeMsg1.Visible = false;
            }
            if (CurrentYear < exYear2)
            {
                FDate = true;
                WrongeMsg1.Visible = false;
            }
            
            if(Code.Text.Length==0 )
            {
                FCode = false;
                WrongeMsg2.Text = "You Must Fill This!!";
                WrongeMsg2.Visible = true;
            }
     
            else
            {
                FCode = true;
                WrongeMsg2.Visible = false;
            }
            double inputDiscount = 0;
            if (DiscountInteger.Text.Length==0 || DiscountDecimal.Text.Length == 0)
            {
                WrongeMsg3.Text = "You Must Fill Both Integer Part and Fraction Part!!";
                WrongeMsg3.Visible = true;
                FDiscount = false;
            }
            else 
            {
                
                try
                { //if the input wasnt numerical only  
                    String inputDiscount0 = DiscountInteger.Text + "." + DiscountDecimal.Text;
                     inputDiscount = Convert.ToDouble(inputDiscount0);
                    FDiscount = true;
                    WrongeMsg3.Visible = false;
                }
                catch (Exception)
                {
                    FDiscount = false;
                    WrongeMsg3.Visible = true;
                    WrongeMsg3.Text = "This Field Accept numerical values only !!";
                }
            }
            int inputAdminId = -1;
            if (AdminId.Text.Length == 0)
            {
                WrongeMsg4.Text = "You Must Fill This!!";
                FAdminId = false;
                WrongeMsg4.Visible = true;

            }
            else
            {
                try
                {

                     inputAdminId = Convert.ToInt16(AdminId.Text);
                    WrongeMsg4.Visible= false ;
                    FAdminId = true;
                }
                catch (Exception)
                {
                    WrongeMsg4.Text = "This Field Accept numerical values only !!";
                    WrongeMsg4.Visible = true;
                    FAdminId = false;
                }
            }





            conn.Close();

            if (FCode && FDate && FDiscount &&FAdminId)  //now i will search if there's problem with FDiscount and FadminId
            {
                
                String inputCode = Code.Text;
                DateTime inputIsseuDate = Convert.ToDateTime(CurrentMonth + "-" + CurrentDay + "-" + CurrentYear);
                DateTime inputExpiryDate = Convert.ToDateTime(exMonth2 + "-" + exDay2 + "-" + exYear2);
                //inputDiscount 
                //inputAdminId
                AdminCreatePromocode.Parameters.Add(new SqlParameter("@code", inputCode));
                AdminCreatePromocode.Parameters.Add(new SqlParameter("@isuueDate", inputIsseuDate));
                AdminCreatePromocode.Parameters.Add(new SqlParameter("@expiryDate", inputExpiryDate));
                AdminCreatePromocode.Parameters.Add(new SqlParameter("@discount", inputDiscount));
                AdminCreatePromocode.Parameters.Add(new SqlParameter("@adminId", (int)Session["user"]));





                int check = 1;
                Boolean joinedException = false;
                if (check == 1) //to guarantee that admin exist first
                {
                    try
                    {
                        conn.Close();
                        conn.Open();
                        AdminCreatePromocode.ExecuteNonQuery();
                        conn.Close();

                    }
                    catch (Exception w)
                    {
                        
                        joinedException = true;
                        WrongeMsg2.Text = "This Promo already Exists !!";
                        WrongeMsg2.Visible = true;
                    }
                    if (!joinedException && check == 1)
                    {
                        WrongeMsg2.Visible = false;
                        WrongeMsg4.Visible = false;
                        AdminId.Text = "";
                        DiscountDecimal.Text = "";
                        DiscountInteger.Text = "";
                        Code.Text = "";
                        MessageBox.Show("Promo Code is successfully created !!");
                    }


                }



            }











        }

        protected void issueMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DiscountInteger_TextChanged(object sender, EventArgs e)
        {

        }
    }
}