using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MSITJSLab_Lab07_get : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string str = Request.QueryString["txtName"];  //method=get
        //string str = Request.Form["txtName"];  //method=post      
        string str = Request.Params["txtName"];  //method=get or method=post
        Response.Write(str);
    }
}