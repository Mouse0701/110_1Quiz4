﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _110_1Quiz4
{
    public partial class Quize4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { 
           

             string s_ConnS = "Data Source=(localdb)\\MSSQLLocalDB;" +
                                "Initial Catalog = test;" +
                                "Integrated Security = True;" +
                                "Connect Timeout = 30;" +
                                "Encrypt = False;" +
                                "TrustServerCertificate=False;" +
                                "ApplicationIntent =ReadWrite;" +
                                "MultiSubnetFailover =False;" +
                                "User ID = sa;Password = Mouse0701;";

            try
            {
                SqlConnection o_Conn = new SqlConnection(s_ConnS);
                SqlCommand o_Com = new SqlCommand("Select * from Users", o_Conn);
                o_Conn.Open();
                SqlDataReader o_R = o_Com.ExecuteReader();
                for (; o_R.Read();)
                {
                    for (int i = 0; i < o_R.FieldCount; i++)
                    {
                        Response.Write("&nbsp;&nbsp;" + o_R[i].ToString());
                    }
                    Response.Write("<br/>");
                }
                o_Conn.Close();
            }
            catch(Exception o_Exc)
            {
                Response.Write(o_Exc.ToString());
            }

        }
    }
}