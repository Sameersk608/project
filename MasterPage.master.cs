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
public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection conn;
    Dbconn con;
    SqlCommand cmd;
    SqlDataReader dr;
    SqlDataAdapter da;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new Dbconn();
        conn = new SqlConnection(con.conn.ToString());
        conn.Open();
        if (this.IsPostBack == false)
        {
            prod();
        }
        if (!string.IsNullOrEmpty(Convert.ToString(Session["CustName"])))
        {
            LinkButton7.Visible = false;
            lblOr.Visible = false;
            LinkButton8.Visible = false;
            lblName.Text = Convert.ToString(Session["CustName"]);
        }
        else
        {
            LinkButton7.Visible = true;
            lblOr.Visible = true;
            LinkButton8.Visible = true;
            lblName.Text = "";
        }
    }
    void prod()
    {
        da = new SqlDataAdapter("select * from product_tb", conn);
        da.Fill(ds, "prod");
        ddlpname.DataSource = ds.Tables["prod"];
        ddlpname.DataTextField = "prodname";
        ddlpname.DataValueField = "pno";
        ddlpname.DataBind();
        ddlpname.Items.Insert(0, "--Select Categories--");
        ddlpname.Dispose();
        LinkButton11.Visible = false;
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/customer/login.aspx");
    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/customer/Register.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" && ddlpname.SelectedIndex != 0)
        {
            string pno = ddlpname.SelectedValue;
            Session["pno"] = pno;
            Session["name"] = "";
            Session["custid"] = "";
            Session["CustName"] = "";
            LinkButton11.Visible = false;
            LinkButton7.Visible = true;
            lblOr.Visible = true;
            LinkButton8.Visible = true;
            lblName.Text = "";
            Response.Redirect("~/shopproduct.aspx");
        }
        else
        {
            string pno = ddlpname.SelectedValue;
            string name = TextBox1.Text;
            Session["pno"] = pno;
            Session["name"] = name;
            Session["custid"] = "";
            LinkButton11.Visible = true;
            Response.Redirect("~/shopproduct.aspx");
        }
    }
    protected void lnksupp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/supplier/supplierhomepage.aspx");
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        Session["CustName"] = "";
        Response.Redirect("~/homepage1.aspx");
    }
    protected void LinkButton11_Click1(object sender, EventArgs e)
    {
        Session["CustName"] = "";
        Response.Redirect("~/homepage1.aspx");
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {

    }
}
