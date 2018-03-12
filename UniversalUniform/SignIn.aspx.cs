using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace UniversalUniform
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] != null)
            {
                Session.RemoveAll();
            }

            if (Session["SignInError"] != null)
            {
                lbError.Text = "Username and password combination not found";
                Session.Remove("SignInError");
            }
            else
            {
                lbError.Text = "";
            }
            if (Session["SignUpError"] != null)
            {
                lbError.Text = Session["SignUpError"].ToString();
                Session.Remove("SignUpError");
            }
            else
            {
                lbError.Text = "";
            }


            

            if (Session["SignUp"]!=null)
            {
                txtPassword2.Visible = true;
                lbPassword2.Visible = true;
                cmdSinUp.Text = "Submit";
            }
            else
            {
                txtPassword2.Visible = false;
                lbPassword2.Visible = false;
                cmdSinUp.Text = "SignUp";
            }
            txtUsername.Focus();

        }

        protected void cbSignIn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
            using (conn)
            {

                SqlCommand sqlComm = new SqlCommand("Access.LookUp_User", conn);
                sqlComm.Parameters.Add(new SqlParameter("@UserName", txtUsername.Text));
                sqlComm.Parameters.Add(new SqlParameter("@Passoword", txtPassword.Text));
                SqlParameter returnIsFound = new SqlParameter();
                SqlParameter returnRoleID = new SqlParameter();


                returnIsFound.ParameterName = "@IsFound";
                returnIsFound.SqlDbType = System.Data.SqlDbType.Bit;
                returnIsFound.Direction = ParameterDirection.Output;
                sqlComm.Parameters.Add(returnIsFound);


                returnRoleID.ParameterName = "@RoleID";
                returnRoleID.SqlDbType = SqlDbType.Int;
                returnRoleID.Size = 100;
                returnRoleID.Direction = ParameterDirection.Output;
                sqlComm.Parameters.Add(returnRoleID);
                sqlComm.CommandType = CommandType.StoredProcedure;

                conn.Open();
                sqlComm.ExecuteNonQuery();
                conn.Close();

                bool isFound = bool.Parse(returnIsFound.Value.ToString());
                if (isFound)
                {
                    Session.Add("CurrentUser", txtUsername.Text);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session.Add("SignInError", "");
                }

            }
        }

        protected void cmdSinUp_Click(object sender, EventArgs e)
        {
            if (Session["SignUp"] != null)
            {
                if (txtPassword.Text == "" || txtPassword2.Text == "" || txtUsername.Text == "")
                {
                    Session.Add("SignUpError", "Fill in all the text boxes");
                }
                else if (txtPassword.Text != txtPassword2.Text)
                {
                    Session.Add("SignUpError", "Password missmatch");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(UniversalUniform.Properties.Settings.Default.DBCon);
                    using (conn)
                    {

                        SqlCommand sqlComm = new SqlCommand( "[Access].[Insert_User]", conn);
                        sqlComm.Parameters.Add(new SqlParameter("@UserName", txtUsername.Text));
                        sqlComm.Parameters.Add(new SqlParameter("@Passoword", txtPassword.Text));
                        SqlParameter returnIsCreated = new SqlParameter();
                        SqlParameter returnInfoMsg = new SqlParameter();


                        returnIsCreated.ParameterName = "@IsCreated";
                        returnIsCreated.SqlDbType = System.Data.SqlDbType.Bit;
                        returnIsCreated.Direction = ParameterDirection.Output;
                        sqlComm.Parameters.Add(returnIsCreated);


                        returnInfoMsg.ParameterName = "@InfoMsg";
                        returnInfoMsg.SqlDbType = SqlDbType.VarChar;
                        returnInfoMsg.Size = 256;
                        returnInfoMsg.Direction = ParameterDirection.Output;
                        sqlComm.Parameters.Add(returnInfoMsg);
                        sqlComm.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        sqlComm.ExecuteNonQuery();
                        conn.Close();

                        bool IsCreated = bool.Parse(returnIsCreated.Value.ToString());
                        if (IsCreated)
                        {
                            Session.Remove("SignUp");
                        }
                        else
                        {
                            
                            Session.Add("SignUpError", returnInfoMsg.Value.ToString());
                        }

                    }
                }

            }
            else
            {
                Session.Add("SignUp", "EnterDetails");
            }
           
            Redirect();

        }
        private void Redirect()
        {
            Response.Redirect("SignIn.aspx");
        }
    }
}