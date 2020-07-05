using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
public partial class homepage1 : System.Web.UI.Page
{
    SqlConnection conn;
    Dbconn con;
    SqlDataAdapter da;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new Dbconn();
        conn = new SqlConnection(con.conn.ToString());
        conn.Open();
    }
}
