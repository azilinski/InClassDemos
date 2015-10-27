using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Name Spaces
using eResturauntSystem.BLL;
using eResturauntSystem.DAL;
using eResturauntSystem.Entities;
using eResturauntSystem.Entities.POCOs;
#endregion
public partial class UXPages_FrontDesk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void MockLastBillingDateTime_Click(object sender, EventArgs e)
    {
        AdminController sysmgr = new AdminController();
        DateTime info = sysmgr.GetLastBillDateTime();
        SearchDate.Text = info.ToString("yyyy-mm-dd");
        SearchTime.Text = info.ToString("hh:mm:ss");
    }
}