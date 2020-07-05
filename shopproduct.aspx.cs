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
public partial class shopproduct : System.Web.UI.Page
{
    SqlConnection conn;
    Dbconn con;
    SqlDataAdapter da;
    SqlCommand cmd;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    string custid;
    int sno;
    string arg,pno,name;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new Dbconn();
        conn = new SqlConnection(con.conn.ToString());
        conn.Open();
        custid = Session["custid"].ToString();
      pno = Session["pno"].ToString();
      name = Session["name"].ToString();
        if (custid == "")
        {
          //  Panel1.Visible = "false";
        }
        if (name == "")
        {
            da = new SqlDataAdapter("select * from supplprod_tb where pno='" + pno + "'and Status='Avaliable' ", conn);
            da.Fill(ds, "sp");
            GridView1.DataSource = ds.Tables["sp"];
            GridView1.DataBind();
        }
        else
        {
            da = new SqlDataAdapter("select * from supplprod_tb where pno='" + pno + "' and pname like '" + name + "'+'%' and Status='Avaliable' ", conn);
            da.Fill(ds, "sp1");
            GridView1.DataSource = ds.Tables["sp1"];
            GridView1.DataBind();
        }
    }
    void sno1()
    {
        da = new SqlDataAdapter("select count(sno) from cart_tb", conn);
        da.Fill(ds, "ss");
        int k = int.Parse(ds.Tables["ss"].Rows[0][0].ToString());
        if (k > 0)
        {
            cmd = new SqlCommand("select max(sno) from cart_tb", conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            int i = int.Parse(dr[0].ToString());
            dr.Close();
            sno = i + 1;
        }
        else
        {
            sno = 1;
        }


    }
    protected void LinkButton1_Click(object sender, CommandEventArgs e)
    {
        if (custid != "")
        {
            sno1();
            arg = e.CommandArgument.ToString();
            da = new SqlDataAdapter("select * from supplprod_tb where sno='" + arg + "'", conn);
            da.Fill(ds, "arg");
            string pno = ds.Tables["arg"].Rows[0][2].ToString();
            string prodname = ds.Tables["arg"].Rows[0][3].ToString();
            string pname = ds.Tables["arg"].Rows[0][4].ToString();
            float price = float.Parse(ds.Tables["arg"].Rows[0][5].ToString());
            string logo = ds.Tables["arg"].Rows[0][8].ToString();
            da = new SqlDataAdapter("insert into cart_tb values('" + sno + "','" + custid + "','" + pno + "','" + prodname + "','" + pname + "','" + price + "','" + logo + "','" + System.DateTime.Now.ToString() + "','" + 1 + "','" + price + "')", conn);
            da.SelectCommand.ExecuteNonQuery();
        }
      //  else
        //{
          //  Response.Redirect("~/customer/login.aspx");
        //}
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (name == "")
        {
            da = new SqlDataAdapter("select * from supplprod_tb where pno='" + pno + "'and Status='Avaliable' ", conn);
            da.Fill(ds, "sp");
            GridView1.DataSource = ds.Tables["sp"];
            GridView1.DataBind();
        }
        else
        {
            da = new SqlDataAdapter("select * from supplprod_tb where pno='" + pno + "' and pname like '" + name + "'+'%' and Status='Avaliable' ", conn);
            da.Fill(ds, "sp1");
            GridView1.DataSource = ds.Tables["sp1"];
            GridView1.DataBind();
        }
    }
}
